using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars.Ribbon;
using System.Threading;
using Contra.Properties;
using System.Runtime.InteropServices;
using DevExpress.XtraEditors;
using DevExpress.XtraGauges.Win;
using DevExpress.XtraGauges.Win.Gauges.Digital;
using System.IO;
using System.Diagnostics;
using ContraLibrary;
using System.Linq;
using Contra.Info;
using ContraReg2;

namespace Contra
{
    public unsafe partial class FormMain : FormBase
    {
        FormWait waitFrm;
        Process program;
        public CardHelper card;
        Settings setting = Settings.Default;
        PortHelper plcHelper;
        PortHelper _232Helper;
        ButtonWatch watch;
        private bool isChanged = false;

        private bool isBackToZChange;
        private decimal backToChangePosition;

        private bool isCtrlDown = false;

        private bool isChangeDaoMove = false;
        private bool isChangeDao = false;
        private bool isChangeDaoCheckFailureHeight = true;

        public List<JiagongHistoryInfo> jiagongHistory;

        public DateTime jiagongZeroStartTime;

        public PortHelper PlcHelpr
        {
            get { return plcHelper; }
        }

        public AxisSetInfo AxisSet
        {
            get { return Settings.Default.Set.AxisSet; }
        }

        public IOSetInfo IOSet
        {
            get { return Settings.Default.Set.IOSet; }
        }

        public OtherSetInfo OtherSet
        {
            get { return Settings.Default.Set.OtherSet; }
        }

        public ButtonSetInfo ButtonSet
        {
            get { return Settings.Default.Set.ButtonSet; }
        }

        public AbsolutePosSetInfo AbsolutePosSet
        {
            get { return Settings.Default.Set.AbsolutePosSet; }
        }

        public IOHelper IOHelper
        {
            get;
            set;
        }
        /// <summary>
        /// 自动分中
        /// </summary>
        public bool isAutoCenter = false;

        /// <summary>
        /// 雷尼绍检测
        /// </summary>
        public bool isLNSCheck = false;

        public int lnsCheckType = 0;

        public int lnsCheckCount = 0;

        public int lnsCheckCurrentLine = 0;

        public bool isLnsMoved = false;

        public bool isLnsMove = true;

        public List<PCKInfo> pckList;

        private int centerAttemps = 0;

        private int centerType = 0;

        private decimal firstValue;

        private decimal secondValue;

        private decimal thirdValue;

        private decimal centerXPlus;

        private decimal centerXMinus;

        private decimal centerYPlus;

        private decimal centerYMinus;

        private decimal centerX;

        private decimal centerY;

        /// <summary>
        /// 执行
        /// </summary>
        public bool isContinue = false;

        /// <summary>
        /// 当前轴
        /// </summary>
        private int currPostion = 0;
        /// <summary>
        /// 断点重启
        /// </summary>
        private bool isRestart = false;

        /// <summary>
        /// 是否回零
        /// </summary>
        private bool isZero = false;

        private int isZeroAttemp = 0;
        /// <summary>
        /// 单步运行
        /// </summary>
        private bool isSingle = false;

        private bool isSingleM21 = false;

        /// <summary>
        /// 手动执行条件
        /// </summary>
        private BaseInfo inputInfo;
        private HoleInfo inputHole;
        /// <summary>
        /// 手动执行
        /// </summary>
        private bool isInput = false;

        public bool isM21 = false;
        internal bool isSkipProtect = false;

        //False表示已清零状态 但是还未对Z轴清零
        private bool isM21Zero = false;
        //False
        private bool isM21ZDown = false;

        /// <summary>
        /// 当前坐标系
        /// </summary>
        private string axisType = HeadType.G54;

        private int paramIndex = 0;
        private DateTime paramStopStartTime = DateTime.MinValue;
        private bool isWaitParamStopTime = false;
        private int paramStopSecond = 0;

        private decimal zeroHeight = 0;
        private decimal machineHeight = 0;
        private decimal backHeight = 0;
        private bool isM21ZUpRotate = false;

        private bool isM21FinishCloseShuibeng = false;
        /// <summary>
        /// 控制开始时候的等待窗体
        /// </summary>
        AutoResetEvent ar;
        Thread thread;

        #region 构造函数
        public FormMain()
        {
            card = new CardHelper(this);
            plcHelper = new PortHelper("COM1");
            if (AbsolutePosSet.UseAbsolutePos || AbsolutePosSet.UseFushiAbsolutePos)
                _232Helper = new PortHelper("COM2");
            jiagongHistory = new List<JiagongHistoryInfo>();
            IOHelper = new IOHelper(card, setting.Set.IOSet, setting.Set.AxisSet, setting.Set.AbsolutePosSet, plcHelper, _232Helper, this);
            ar = new AutoResetEvent(false);
            thread = new Thread(() => OnShowWait());
            thread.Start();
            Thread.Sleep(100);
            InitializeComponent();
            RefreshButton();
            this.KeyPreview = true;
            waitFrm.Ar.Set();
            ar.WaitOne();
        }

        private void RefreshButton()
        {
            int posX = 5;
            int posY = 26;
            int count = 0;
            btnLight.Visible = ButtonSet.UseLight;
            if (ButtonSet.UseLight)
            {
                btnLight.Location = new Point(posX + count * 72, posY);
                count++;
            }
            btnAxisR.Visible = ButtonSet.UseRotate;
            if (ButtonSet.UseRotate)
            {
                btnAxisR.Location = new Point(posX + count * 72, posY);
                count++;
            }
            btnChongShui.Visible = ButtonSet.UseChongshui;
            if (ButtonSet.UseChongshui)
            {
                btnChongShui.Location = new Point(posX + count * 72, posY);
                count++;
            }
            btnFushi.Visible = ButtonSet.UseFushi;
            if (ButtonSet.UseFushi)
            {
                btnFushi.Location = new Point(posX + count * 72, posY);
                count++;
            }
            btnMen.Visible = ButtonSet.UseMen;
            if (ButtonSet.UseMen)
            {
                btnMen.Location = new Point(posX + count * 72, posY);
                count++;
            }
            btnBuzzing.Visible = ButtonSet.UseBuzzing;
            if (ButtonSet.UseBuzzing)
            {
                btnBuzzing.Location = new Point(posX + count * 72, posY);
                count++;
            }
            btnFanjixing.Visible = ButtonSet.UseFanjixing;
            if (ButtonSet.UseFanjixing)
            {
                btnFanjixing.Location = new Point(posX + count * 72, posY);
                count++;
            }
            btnDuidao.Visible = ButtonSet.UseDuidao;
            if (ButtonSet.UseDuidao)
            {
                btnDuidao.Location = new Point(posX + count * 72, posY);
                count++;
            }
            btnDaoKu.Visible = OtherSet.UseChangeDao;
            btnZZero.Location = new Point(posX + count * 72, posY);
            count++;
            btnZThrow.Location = new Point(posX + count * 72, posY);
            count++;
            btnWHit.Location = new Point(posX + count * 72, posY);
            count++;
            btnWHitIgnore.Visible = ButtonSet.UseWHitIgnore;
            if (ButtonSet.UseWHitIgnore)
            {
                btnWHitIgnore.Location = new Point(posX + count * 72, posY);
                count++;
            }
            btnSpeed.Location = new Point(posX + count * 72, posY);

            count++;
            btnWarning.Location = new Point(posX + count * 72, posY);
            count++;
        }

        private void OnShowWait()
        {
            string language = Settings.Default.Set.OtherSet.LanguageType;
            LanguageHelper.SetLanguage(language);
            waitFrm = new FormWait();
            waitFrm.WaitEvent += new WaitEventHandler(waitFrm_WaitEvent);
            waitFrm.ShowDialog();
            ar.Set();
        }

        void waitFrm_WaitEvent()
        {
            waitFrm.Ar.WaitOne();
            this.WindowState = FormWindowState.Maximized;
            setting.Contra = setting.Contra ?? new ContraInfo();
            this.bindingSource.DataSource = setting.Contra;
            this.bindingSourceAxisSet.DataSource = new AxisModifyInfo();
            card.InitBoard();
            try
            {
                IOHelper.StartShifu();
            }
            catch (Exception)
            {

            }
            card.SetOutCheck();
            IOHelper.SetHitProtect(1);
            ZeroInfo = new ToZeroInfo();
            DrawKuaijie();
        }

        private void DrawKuaijie()
        {
            btnHelper.Paint += new PaintEventHandler(Kuaijie_Paint);
            btnManual.Paint += new PaintEventHandler(Kuaijie_Paint);
            btnProgram.Paint += new PaintEventHandler(Kuaijie_Paint);
            btnShuibang.Paint += new PaintEventHandler(Kuaijie_Paint);
            btnJiagong.Paint += new PaintEventHandler(Kuaijie_Paint);
            btnShineng.Paint += new PaintEventHandler(Kuaijie_Paint);
            btnSet.Paint += new PaintEventHandler(Kuaijie_Paint);
            btnShutdown.Paint += new PaintEventHandler(Kuaijie_Paint);

            btnStart.Paint += new PaintEventHandler(Kuaijie_Paint);
            btnNext.Paint += new PaintEventHandler(Kuaijie_Paint);
            btnStop.Paint += new PaintEventHandler(Kuaijie_Paint);
            btnReset.Paint += new PaintEventHandler(Kuaijie_Paint);
        }

        void Kuaijie_Paint(object sender, PaintEventArgs e)
        {
            Control contrl = sender as Control;
            string kuaijie = null;
            switch (contrl.Name)
            {
                case "btnHelper": kuaijie = "F1"; break;
                case "btnManual": kuaijie = "F2"; break;
                case "btnProgram": kuaijie = "F3"; break;
                case "btnShuibang": kuaijie = "F4"; break;
                case "btnJiagong": kuaijie = "F5"; break;
                case "btnShineng": kuaijie = "F6"; break;
                case "btnSet": kuaijie = "F7"; break;
                case "btnShutdown": kuaijie = "F8"; break;

                case "btnStart": kuaijie = "F9"; break;
                case "btnStop": kuaijie = "F10"; break;
                case "btnReset": kuaijie = "F11"; break;
                case "btnNext": kuaijie = "F12"; break;
            }
            if (!string.IsNullOrEmpty(kuaijie))
            {
                e.Graphics.DrawString(kuaijie, new Font("宋体", 9f), new SolidBrush(Color.FromArgb(21, 66, 139)), 3, 3, new StringFormat());
            }
        }

        #endregion

        #region 属性
        /// <summary>
        /// 当前界面信息
        /// </summary>
        public ContraInfo CurrInfo
        {
            get { return this.bindingSource.DataSource as ContraInfo; }
        }

        public AxisModifyInfo AxisModify
        {
            get { return this.bindingSourceAxisSet.DataSource as AxisModifyInfo; }
        }

        /// <summary>
        /// 归零选项
        /// </summary>
        private ToZeroInfo ZeroInfo
        {
            get;
            set;
        }

        public HoleCollection HoleCollection
        {
            get { return this.bindingSourceCnc.DataSource as HoleCollection; }
        }

        public HoleInfo HoleInfo
        {
            get { return this.bindingSourceCnc.Current as HoleInfo; }
        }

        public ParamCollection ParamCollection
        {
            get { return this.bindingSourceParam.DataSource as ParamCollection; }
        }

        public ThrowSetInfo ThrowSet
        {
            get { return this.bindingSourceThrowSet.DataSource as ThrowSetInfo; }
        }


        public ParamList GetParamList(string param)
        {
            return ParamCollection[param];
        }
        #endregion

        #region 窗体加载
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadPnc();
            string path = Path.Combine(Application.StartupPath, "OverrideLogo.jpg");
            if (File.Exists(path))
            {
                this.picLogo.Image = this.picLogo.Image = Image.FromFile(path);
            }
            this.timer.Enabled = true;
            this.timerWheel.Enabled = true;
            this.timerCOrigin.Enabled = true;
            this.timerTime.Enabled = true;
            this.timerPlcCheck.Enabled = true;
            this.timerPlcCheck2.Enabled = true;
            this.btnLight.Checked = true;
            this.btnBuzzing.Checked = true;
            this.watch = new ButtonWatch();
            this.watch.WatchButtons = 7;
            watch.ButtonEvent += new Action<ButtonWatchEventArgs>(watch_ButtonEvent);
            DataTable throwModeTable = new DataTable();
            throwModeTable.Columns.Add("ID");
            throwModeTable.Columns.Add("Name");

            throwModeTable.Rows.Add("0", L.R("FormMain.ThrowMode.NotThrow", "不使用"));
            throwModeTable.Rows.Add("1", L.R("FormMain.ThrowMode.Mode1", "模式1"));
            throwModeTable.Rows.Add("2", L.R("FormMain.ThrowMode.Mode2", "模式2"));

            this.axisControl1.SetBinding(this.bindingSource, "G54");
            this.axisControl1.SetVisible(this.AxisSet);

            this.repositoryItemThrowMode.DataSource = throwModeTable;

            btnSpeed.CheckedChanged += new EventHandler(btnSpeed_CheckedChanged);
            btnSpeed.Checked = AxisSet.UseHighSpeed;
            btnFushi.Value = AxisSet.UseFushi;
            btnMen.Value = AxisSet.UseMen;
            btnSpeed.DataBindings.Add(new Binding("Checked", AxisSet, "UseHighSpeed", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));

            if (OtherSet.ShowStartZeroForm)
            {
                FormStartZero form = new FormStartZero();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var toZeroInfo = new ToZeroInfo();
                    DialogResult result = System.Windows.Forms.DialogResult.OK;
                    if (form.ZeroInfo.IsZeroAll)
                    {
                        toZeroInfo.IsZeroZ = true;
                        toZeroInfo.IsZeroX = true;
                        toZeroInfo.IsZeroY = true;
                        toZeroInfo.IsZeroW = true;
                        toZeroInfo.IsZeroB = true;
                        toZeroInfo.IsZeroC = true;
                        toZeroInfo.IsZeroA = true;
                        result = System.Windows.Forms.DialogResult.Yes;
                    }
                    else
                    {
                        toZeroInfo.IsZeroZ = true;
                    }
                    ToZero(toZeroInfo, result);
                }
            }
            //watch.ButtonEvent += new Action<ButtonWatchEventArgs>(watch_ButtonEvent);
        }

        private void timerTime_Tick(object sender, EventArgs e)
        {
            this.biTime.Caption = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        #endregion

        #region 窗体关闭
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            if (isChanged && ContraHelper.ShowQuestion(L.R("FormMain.ScriptNotSave", "加工孔位或加工参数还未保存,是否要保存？")))
            {
                btnSaveScript_Click(null, null);
            }
            base.OnFormClosed(e);
            timer.Enabled = false;
            timerWheel.Enabled = false;
            CloseAllOutput();
            card.CloseAllMove();
            plcHelper.SendMsg(PortHelper.RotateOff);
            IOHelper.CloseShifu();
            IOHelper.SetMen(0);
            Settings.Default.Set.AbsolutePosSet.PartXData = null;
            Settings.Default.Set.AbsolutePosSet.PartYData = null;
            Settings.Default.Set.AbsolutePosSet.PartWData = null;
            Settings.Default.Set.AbsolutePosSet.PartBData = null;
            Settings.Default.Set.AbsolutePosSet.PartCData = null;
            Settings.Default.Save();
        }
        #endregion

        #region Timer
        private bool isLastWMoved = false;
        private void timer_Tick(object sender, EventArgs e)
        {
            //读取所有输入信号供下方判断
            IOHelper.ReadInputs();
            //检查轴正限位
            CheckWPlus();
            //检查伺服报警
            CheckAlarm();
            //检查Z轴正限位
            //CheckZPlus();
            CheckZPlus();
            //检测刀库
            CheckDaoKu();
            //检查Z负限位
            CheckZMinus();
            //检查急停
            CheckUrgencyStop();
            //输出清零状态
            SetZeroState();
            //输出穿透状态
            SetThrowState();
            //输出W撞击状态
            SetWHitState();
            //读取各轴位置
            card.ReadPos();
            if (isBackToZChange && card.Contra.GetActPosZ(axisType) > backToChangePosition)
            {
                isBackToZChange = false;
                plcHelper.SendMsg(PortHelper.ZUpOff);
            }
            //检查扶丝
            CheckFusi();
            //没有移动，没有执行M21
            bool flag = !card.IsRunning();
            if (flag)
            {
                if (isZeroAttemp < 20)
                {
                    isZeroAttemp++;
                }
                if (isZeroAttemp >= 20)
                {
                    isZero = false;
                }
                card.JianxiTiaozheng();
                isChangeDianji = false;
            }
            #region 按钮可用控制
            btnAutoCenter.Enabled = !isAutoCenter && !isContinue && OtherSet.UseAutoCenter;
            btnStopCenter.Enabled = isAutoCenter && !isContinue;
            //顶部
            this.btnMovePanel.Enabled = flag && !isContinue;
            this.btnDaoKu.Enabled = flag && !isContinue;
            //右侧按钮
            this.btnStart.Enabled = flag && !isContinue && !isM21;
            this.btnStop.Enabled = (!flag || isContinue || isM21);
            this.btnReset.Enabled = flag && !isContinue && !isM21;
            this.btnToZero.Enabled = flag && !isContinue && !isM21;
            this.btnNext.Enabled = flag && !isContinue && !isM21;
            this.btnZeroRestart.Enabled = flag && !isContinue && !isM21;

            this.btnDuidao.Enabled = flag && !isContinue && !isM21;

            //列表
            //this.gridViewParam.OptionsBehavior.ReadOnly = !(flag && !isContinue );

            //孔位按钮
            this.btnLoadFile.Enabled = flag && !isContinue && !isM21;
            //this.btnAddHole.Enabled = flag && !isContinue && !isM21;
            //this.btnDeleteHole.Enabled = flag && !isContinue && !isM21;
            this.btnSaveScript.Enabled = flag && !isContinue && !isM21;
            this.btnMoreOperate.Enabled = flag && !isContinue && !isM21;
            this.btnNewHoles.Enabled = flag && !isContinue && !isM21;
            this.cbEmptyRun.Enabled = flag && !isContinue && !isM21;

            //this.btnNew.Enabled = flag && !isContinue && isZero;
            //this.miEdit.Enabled = flag && !isContinue && isZero;

            //参数按钮
            this.btnAddParam.Enabled = this.btnStart.Enabled;
            this.btnDeleteParam.Enabled = this.btnStart.Enabled;
            //this.btnLoadParam.Enabled = this.btnStart.Enabled;
            //this.btnSaveParam.Enabled = this.btnStart.Enabled;

            this.btnZeroX.Enabled = flag && !isContinue && !AxisSet.IgnoreX && !isM21;
            this.btnZeroY.Enabled = flag && !isContinue && !AxisSet.IgnoreY && !isM21;
            this.btnZeroW.Enabled = flag && !isContinue && !AxisSet.IgnoreW && !isM21;
            this.btnZeroB.Enabled = flag && !isContinue && !AxisSet.IgnoreB && !isM21;
            this.btnZeroC.Enabled = flag && !isContinue && !AxisSet.IgnoreC && !isM21;
            this.btnZeroZ.Enabled = flag && !isContinue && !AxisSet.IgnoreZ && !isM21;

            this.btnSetX.Enabled = flag && !isContinue && !AxisSet.IgnoreX && !isM21;
            this.btnSetY.Enabled = flag && !isContinue && !AxisSet.IgnoreY && !isM21;
            this.btnSetW.Enabled = flag && !isContinue && !AxisSet.IgnoreW && !isM21;
            this.btnSetB.Enabled = flag && !isContinue && !AxisSet.IgnoreB && !isM21;
            this.btnSetC.Enabled = flag && !isContinue && !AxisSet.IgnoreC && !isM21;
            this.btnSetZ.Enabled = flag && !isContinue && !AxisSet.IgnoreZ && !isM21;

            this.btnHalfX.Enabled = flag && !isContinue && !AxisSet.IgnoreX && !isM21;
            this.btnHalfY.Enabled = flag && !isContinue && !AxisSet.IgnoreY && !isM21;
            this.btnHalfW.Enabled = flag && !isContinue && !AxisSet.IgnoreW && !isM21;
            this.btnHalfZ.Enabled = flag && !isContinue && !AxisSet.IgnoreZ && !isM21;
            this.btnHalfB.Enabled = flag && !isContinue && !AxisSet.IgnoreB && !isM21;
            this.btnHalfC.Enabled = flag && !isContinue && !AxisSet.IgnoreC && !isM21;

            this.btnSet.Enabled = flag && !isContinue && !isM21;
            this.btnShutdown.Enabled = flag && !isContinue && !isM21;

            this.txtInput1.Enabled = flag && !isContinue && !isM21;
            this.btnInput1.Enabled = flag && !isContinue && !isM21;


            this.spSafeHeight.Enabled = flag && !isContinue && !isM21;
            this.chkUseWSafeHeight.Enabled = flag && !isContinue && !isM21;

            this.rgThrowMode.Enabled = flag && !isContinue && !isM21;
            this.txtThrowStartHeight.Enabled = flag && !isContinue && !isM21;
            this.cmbThrowResponse.Enabled = flag && !isContinue && !isM21;
            this.txtThrowLeft.Enabled = flag && !isContinue && !isM21;
            this.txtThrowStartHeight2.Enabled = flag && !isContinue && !isM21;
            this.cmbThrowResponse2.Enabled = flag && !isContinue && !isM21;
            this.txtThrowLeft2.Enabled = flag && !isContinue && !isM21;
            //this.gridViewCnc.GridControl.Enabled = flag && !isContinue && !isM21;
            #endregion

            if (isM21)
            {
                if (flag)//如果轴停下来了,在Z轴有了穿透再下降过程中
                {
                    if (isThrowZEndStoped)
                    {
                        if (IOHelper.IsWHit())  //如果有短路信号，那么代表还没移动到位，需要等待判断是否短路信号清了继续移动
                        {
                            isThrowZWHitDetected = true;
                        }
                        else if (isThrowZWHitDetected && !IOHelper.IsWHit())  //如果检查到过有短信信号并且 短路信号又没有了，把剩下的位置走完
                        {
                            isThrowZWHitDetected = false;
                            this.CurrInfo.LogPosZ = card.GetActPos(AxisSet.ZReadAxis) * AxisSet.ZResolution;
                            var position = this.CurrInfo.GetActPosZ(axisType);
                            card.SingleMoveZ(new HoleInfo() { Z = throwZReachPosition }, this.axisType, AxisSet.ThrowSpeed);
                            plcHelper.SendMsg(PortHelper.ZDownOn);
                        }
                        else
                        {
                            isThrowZStoped = true; //如果不是短路信号 那么代表穿透已经到位，停止穿透
                            isThrowZEndStoped = false;
                        }
                    }
                    else if (isM21ZDown) //
                    {
                        if (IOHelper.IsWHit())
                        {
                            isM21ZUpWHit = true;
                        }
                        else if (isM21ZUpWHit)
                        {
                            isM21ZUpWHit = false;
                            card.SingleMoveZ(new HoleInfo() { Z = backHeight * OtherSet.BackHeightRate, IsJiaGong = false }, this.axisType);
                            PlcHelpr.SendMsg(PortHelper.ZUpOn);
                        }
                    }
                }
                CheckWaitForJiaong();
                CheckChangeDaoFailureHeight();
                CheckDuanlu();
                WaitForM21ZDown();
                WaitForM21ZUp();
            }
            this.bindingSource.ResetBindings(false);

            #region 手动执行
            //手动执行

            //继续执行
            if (isContinue && !IOHelper.IsWHit())
            {
                if (isRestart)
                {
                    isRestart = false;
                    isContinue = true;
                    StartMove();
                }
                else if (flag && !isM21)
                {
                    if (card.moveState == 1 || card.moveState == 2 || isEndStartMove)
                    {
                        StartMove();
                        if ((card.moveState == 1 || card.moveState == 2) && !isLastWMoved)
                        {
                            isLastWMoved = true;
                        }
                        else if (isEndStartMove && isLastWMoved && card.moveState == 0)
                        {
                            isLastWMoved = false;
                            isEndStartMove = false;
                        }
                    }
                    else if (isEndM21)
                    {
                        if (isSingle && isSingleM21 == false)
                        {
                            isSingleM21 = true;
                            isContinue = false;
                            isSingle = false;
                        }
                        else
                        {
                            M21();
                            isSingleM21 = false;
                        }
                    }
                    else if (isEndStop)
                    {
                        if (isChangeDaoMove && IOHelper.IsZPlusLimit())
                        {
                            isChangeDaoMove = false;
                            plcHelper.SendMsg(PortHelper.ChangePie);
                        }
                        if (!isChangeDaoMove)
                        {
                            inputHole = null;
                            inputInfo = null;
                            isEndStop = false;
                            isContinue = false;
                        }
                        if (isLnsMove)
                        {
                            inputInfo = null;
                            inputHole = null;
                            isLnsMove = false;
                            isLnsMoved = true;
                            isContinue = false;
                        }
                    }
                    else
                    {
                        currPostion += 1;
                        if (!isSingle)
                        {
                            if (currPostion >= this.gridViewCnc.RowCount || isM21FinishCloseShuibeng)//加工完成后
                            {
                                CloseAllOutput();
                                isM21FinishCloseShuibeng = false;
                                timerTotal.Enabled = false;
                                isContinue = false;
                                this.btnMen.Value = this.btnMen.Value == 2 ? 2 : 1;
                                IOHelper.SetMen(0);
                                if (currPostion >= this.gridViewCnc.RowCount)
                                    miRestart_ItemClick(null, null);
                                return;
                            }
                            StartMove();
                        }
                        else
                        {
                            isContinue = false;
                            isSingle = false;
                        }
                    }
                    if (this.gridViewCnc.RowCount > 0)
                    {
                        if (currPostion == -1)
                            this.gridViewCnc.FocusedRowHandle = 0;
                        else if (currPostion < this.gridViewCnc.RowCount)
                            this.gridViewCnc.FocusedRowHandle = currPostion;
                        else
                            this.gridViewCnc.FocusedRowHandle = this.gridViewCnc.RowCount - 1;
                        if (currPostion >= this.gridViewCnc.RowCount)
                        {
                            isContinue = false;
                            isSingle = false;
                        }
                    }
                }



            }


            if (isInput)
            {
                isInput = false;

                if (inputInfo != null)
                {
                    if (inputInfo is SingleMoveInfo)
                    {
                        var singleInfo = inputInfo as SingleMoveInfo;
                        inputHole = new HoleInfo()
                        {
                            IsJiaGong = false,
                            X = singleInfo.X,
                            Y = singleInfo.Y,
                            W = singleInfo.W,
                            B = singleInfo.B,
                            C = singleInfo.C,
                            Z = singleInfo.A,
                            AxisType = singleInfo.AxisType ?? this.axisType
                        };
                        StartMove();
                    }
                    else if (inputInfo is M21Info)
                    {
                        var m21Info = inputInfo as M21Info;
                        inputHole = new HoleInfo()
                        {
                            IsJiaGong = true,
                            Param = m21Info.E
                        };
                        StartMove();
                    }
                }
                isEndStop = true;
                isContinue = true;
            }

            #region 自动分中
            if (!isContinue && isAutoCenter && !IOHelper.IsStopButton())
            {
                //200速度X正方向
                if (centerType == 0)
                {
                    MoveCenter(AxisSet.AxisX, 1, () =>
                    {
                        centerXPlus = (firstValue + secondValue + thirdValue) / 2;
                        centerAttemps = 0;
                        centerType = 1;
                    });
                }
                else if (centerType == 1)
                {
                    MoveCenter(AxisSet.AxisX, -1, () =>
                    {
                        centerXMinus = (firstValue + secondValue + thirdValue) / 2;
                        centerX = (centerXPlus + centerXMinus) / 2;
                        centerAttemps = 0;
                        centerType = 3;
                        listBoxControl1.Items.Insert(0, string.Format(L.R("FormMain.AutoCenter.XCenter", "X中心点:{0:0.000}"), centerX));
                        card.SingleMoveX(new HoleInfo() { X = centerX }, this.axisType);
                    });
                }
                else if (centerType == 3 && flag)
                {
                    MoveCenter(AxisSet.AxisY, 1, () =>
                    {
                        centerYPlus = (firstValue + secondValue + thirdValue) / 2;
                        centerAttemps = 0;
                        centerType = 4;
                    });
                }
                else if (centerType == 4)
                {
                    MoveCenter(AxisSet.AxisY, -1, () =>
                    {
                        centerYMinus = (firstValue + secondValue + thirdValue) / 2;
                        centerY = (centerYPlus + centerYMinus) / 2;
                        centerAttemps = 0;
                        listBoxControl1.Items.Insert(0, string.Format(L.R("FormMain.AutoCenter.YCenter", "Y中心点:{0:0.000}"), centerY));
                        card.SingleMoveY(new HoleInfo() { Y = centerY }, this.axisType);
                        centerType = 5;
                    });
                }
                else if (centerType == 5 && flag)
                {
                    isSkipProtect = false;
                    IOHelper.SetHitProtect(1);
                    Thread.Sleep(50);
                    centerAttemps = 0;
                    centerType = 0;
                    isAutoCenter = false;
                }
                else if (centerType == 10)
                {
                    isSkipProtect = false;
                    IOHelper.SetHitProtect(1);
                    Thread.Sleep(50);
                    centerType = 0;
                    centerAttemps = 0;
                    card.CloseAllMove();
                    isAutoCenter = false;
                }
            }
            #endregion

            #region 雷尼绍检测
            if (!isContinue && isLNSCheck && !IOHelper.IsStopButton())
            {
                if (lnsCheckCurrentLine < pckList.Count)
                {
                    if (lnsCheckCurrentLine == 0 && lnsCheckCount == 0)
                    {
                        PlcHelpr.SendMsg(PortHelper.LNSOn);
                        Thread.Sleep(10);
                    }
                    var current = pckList[lnsCheckCurrentLine];
                    MoveLNSCheck(current, () =>
                    {
                        //1.获取锁存位置
                        var position = card.GetLockPosition();
                        if (lnsCheckType == 2)
                        {
                            current.RealValue = CurrInfo.GetWActPos(((decimal)position) / 1000, current.AxisType);
                            current.CheckValue = OtherSet.LNSAllowValue;
                        }
                        else
                        {
                            current.StandardValue = CurrInfo.GetWActPos(((decimal)position) / 1000, current.AxisType);
                            current.CheckValue = OtherSet.LNSAllowValue;
                        }
                        card.ClearLockPosition();
                        lnsCheckCurrentLine++;
                    });
                }
                else
                {
                    PlcHelpr.SendMsg(PortHelper.LNSOff);
                    isLNSCheck = false;
                }
            }
            #endregion

            #endregion
        }

        private bool ChangeDaoFailureHeightWarninged = false;
        private void CheckChangeDaoFailureHeight()
        {
            var position = this.CurrInfo.LogPosZ;
            if (!IOHelper.IsZero() && !isChangeDaoCheckFailureHeight && position < OtherSet.ChangeDaoFailureHeight && !ChangeDaoFailureHeightWarninged)
            {
                ChangeDaoFailureHeightWarninged = true;
                isChangeDaoCheckFailureHeight = true;
                StopImmediately();
                ContraHelper.ShowMessage("加工失败");
            }
        }

        private void CheckDaoKu()
        {
            if (!IOHelper.IsDaoKuCheck() && !isChangeDaoMove && isChangeDao)
            {
                isChangeDao = false;
                miStart_ItemClick(null, null);
            }
        }

        private void MoveCenter(int axis, int xiShu, Action action)
        {
            string targetInfo = string.Format("{0}{1}:", axis == AxisSet.AxisX ? "X" : "Y", xiShu > 0 ? "+" : "-");
            if (centerAttemps == 0 && !card.IsMove(axis) && !IOHelper.IsWHit() && (isSkipProtect == true || xiShu == 1))
            {
                isSkipProtect = false;
                IOHelper.SetHitProtect(1);
                Thread.Sleep(50);
                if (IOHelper.IsWHit())
                {
                    isSkipProtect = true;
                    IOHelper.SetHitProtect(0);
                    Thread.Sleep(50);
                    //while (IOHelper.IsWHit())
                    //    Thread.Sleep(1);
                    card.isOperate = false;
                    card.OperateCenter(axis, -700 * xiShu, 300);
                }
                else
                {
                    card.isOperate = false;
                    card.OperateCenter(axis, 100000 * xiShu, 1000);
                    centerAttemps = 1;
                }
            }
            else if (centerAttemps == 1 && !card.IsMove(axis) && isSkipProtect == false)
            {
                listBoxControl1.Items.Insert(0, L.R("FormMain.AutoCenter.First", "第一次:") + targetInfo + card.Contra.GetActPos(axis, this.axisType, this.AxisSet));
                isSkipProtect = true;
                IOHelper.SetHitProtect(0);
                //while (IOHelper.IsWHit())
                //    Thread.Sleep(1);
                Thread.Sleep(50);
                card.isOperate = false;
                card.OperateCenter(axis, -700 * xiShu, 300);
                centerAttemps = 2;
            }
            else if (centerAttemps == 2 && !card.IsMove(axis) && !IOHelper.IsWHit() && isSkipProtect == true)//表示走到位后
            {
                isSkipProtect = false;
                IOHelper.SetHitProtect(1);
                Thread.Sleep(50);
                if (IOHelper.IsWHit())
                {
                    isSkipProtect = true;
                    IOHelper.SetHitProtect(0);
                    //while (IOHelper.IsWHit())
                    //    Thread.Sleep(1);
                    Thread.Sleep(50);
                    card.isOperate = false;
                    card.OperateCenter(axis, -300 * xiShu, 300);
                }
                else
                {
                    card.isOperate = false;
                    card.OperateCenter(axis, 100000 * xiShu, 20);
                    centerAttemps = 3;
                }
            }
            else if (centerAttemps == 3 && !card.IsMove(axis) && isSkipProtect == false)
            {
                listBoxControl1.Items.Insert(0, L.R("FormMain.AutoCenter.Second", "第二次:") + targetInfo + card.Contra.GetActPos(axis, this.axisType, this.AxisSet));
                isSkipProtect = true;
                IOHelper.SetHitProtect(0);
                //while (IOHelper.IsWHit())
                //    Thread.Sleep(1);
                Thread.Sleep(50);
                firstValue = card.Contra.GetActPos(axis, this.axisType, this.AxisSet);
                card.isOperate = false;
                card.OperateCenter(axis, -300 * xiShu, 300);
                centerAttemps = 4;
            }
            else if (centerAttemps == 4 && !card.IsMove(axis) && !IOHelper.IsWHit() && isSkipProtect == true)//表示走到位后
            {
                isSkipProtect = false;
                IOHelper.SetHitProtect(1);
                Thread.Sleep(50);
                if (IOHelper.IsWHit())
                {
                    isSkipProtect = true;
                    IOHelper.SetHitProtect(0);
                    //while (IOHelper.IsWHit())
                    //    Thread.Sleep(1);
                    Thread.Sleep(50);
                    card.isOperate = false;
                    card.OperateCenter(axis, -300 * xiShu, 300);
                }
                else
                {
                    card.isOperate = false;
                    card.OperateCenter(axis, 100000 * xiShu, 20);
                    centerAttemps = 9;
                }
            }
            else if (centerAttemps == 5 && !card.IsMove(axis) && isSkipProtect == false)
            {
                listBoxControl1.Items.Insert(0, L.R("FormMain.AutoCenter.Third", "第三次:") + targetInfo + card.Contra.GetActPos(axis, this.axisType, this.AxisSet));
                isSkipProtect = true;
                IOHelper.SetHitProtect(0);
                //while (IOHelper.IsWHit())
                //    Thread.Sleep(1);
                Thread.Sleep(50);
                card.isOperate = false;
                card.OperateCenter(axis, -300 * xiShu, 300);
                centerAttemps = 6;
            }
            else if (centerAttemps == 6 && !card.IsMove(axis) && !IOHelper.IsWHit() && isSkipProtect == true)//表示走到位后
            {
                isSkipProtect = false;
                IOHelper.SetHitProtect(1);
                Thread.Sleep(50);
                if (IOHelper.IsWHit())
                {
                    isSkipProtect = true;
                    IOHelper.SetHitProtect(0);
                    //while (IOHelper.IsWHit())
                    //    Thread.Sleep(1);
                    Thread.Sleep(50);
                    card.isOperate = false;
                    card.OperateCenter(axis, -300 * xiShu, 300);
                }
                else
                {
                    card.isOperate = false;
                    card.OperateCenter(axis, 100000 * xiShu, 20);
                    centerAttemps = 7;
                }
            }
            else if (centerAttemps == 7 && !card.IsMove(axis) && isSkipProtect == false)
            {
                listBoxControl1.Items.Insert(0, L.R("FormMain.AutoCenter.Four", "第四次:") + targetInfo + card.Contra.GetActPos(axis, this.axisType, this.AxisSet));
                isSkipProtect = true;
                IOHelper.SetHitProtect(0);
                secondValue = card.Contra.GetActPos(axis, this.axisType, this.AxisSet);
                //while (IOHelper.IsWHit())
                //    Thread.Sleep(1);
                Thread.Sleep(50);
                card.isOperate = false;
                card.OperateCenter(axis, -300 * xiShu, 300);
                centerAttemps = 8;
            }
            else if (centerAttemps == 8 && !card.IsMove(axis) && !IOHelper.IsWHit() && isSkipProtect == true)//表示走到位后
            {
                isSkipProtect = false;
                IOHelper.SetHitProtect(1);
                Thread.Sleep(50);
                if (IOHelper.IsWHit())
                {
                    isSkipProtect = true;
                    IOHelper.SetHitProtect(0);
                    //while (IOHelper.IsWHit())
                    //    Thread.Sleep(1);
                    Thread.Sleep(50);
                    card.isOperate = false;
                    card.OperateCenter(axis, -300 * xiShu, 300);
                }
                else
                {
                    card.isOperate = false;
                    card.OperateCenter(axis, 100000 * xiShu, 20);
                    centerAttemps = 9;
                }
            }
            else if (centerAttemps == 9 && !card.IsMove(axis) && isSkipProtect == false)
            {
                listBoxControl1.Items.Insert(0, L.R("FormMain.AutoCenter.Five", "第三次:") + targetInfo + card.Contra.GetActPos(axis, this.axisType, this.AxisSet));
                isSkipProtect = true;
                IOHelper.SetHitProtect(0);
                thirdValue = card.Contra.GetActPos(axis, this.axisType, this.AxisSet);
                Thread.Sleep(50);
                card.isOperate = false;
                card.Operate(axis, -500 * xiShu, 300);
                centerAttemps = 10;
            }
            else if (centerAttemps == 10 && !card.IsMove(axis) && !IOHelper.IsWHit() && isSkipProtect == true)
            {
                action();
            }
        }

        private void MoveLNSCheck(PCKInfo current, Action action)
        {
            if (lnsCheckCount == 0 && isLnsMoved == false)
            {
                inputInfo = new SingleMoveInfo()
                {
                    X = current.X,
                    Y = current.Y,
                    W = CurrInfo.LNSCheckSafeWHeight + CurrInfo.GetActPosW(current.AxisType) - CurrInfo.LogPosW,
                    B = current.B,
                    C = current.C,
                    AxisType = current.AxisType
                };
                card.moveState = 0;
                isLnsMove = true;
                isInput = true;
            }
            else if (isLnsMoved)
            {
                if (lnsCheckCount == 0 && !IOHelper.IsLockCheck() && !card.IsMove(AxisSet.AxisW))
                {
                    if (card.IsLockStatus()) //第一遍的时候检测是否已锁存
                    {
                        card.ClearLockPosition();
                    }
                    card.isOperate = false;
                    card.Operate(AxisSet.AxisW, -100000, OtherSet.LNSDownSpeed1 * 1000 / 60);
                    lnsCheckCount = 1;
                }
                else if (lnsCheckCount == 1 && IOHelper.IsLockCheck() && card.IsMove(AxisSet.AxisW))
                {
                    card.OperateStopRun();
                    while (card.IsMove(AxisSet.AxisW))
                        Thread.Sleep(1);
                    card.isOperate = false;
                    card.ClearLockPosition();
                    card.Operate(AxisSet.AxisW, OtherSet.LNSBackHeight * 1000, OtherSet.LNSBackSpeed * 1000 / 60);
                    lnsCheckCount = 2;
                }
                else if (lnsCheckCount == 2 && !IOHelper.IsLockCheck() && !card.IsMove(AxisSet.AxisW))
                {
                    card.isOperate = false;
                    card.Operate(AxisSet.AxisW, -100000, OtherSet.LNSDownSpeed2 * 1000 / 60);
                    lnsCheckCount = 3;
                }
                else if (lnsCheckCount == 3 && IOHelper.IsLockCheck() && card.IsMove(AxisSet.AxisW))
                {
                    card.OperateStopRun();
                    while (card.IsMove(AxisSet.AxisW))
                        Thread.Sleep(1);
                    action();
                    card.isOperate = false;
                    card.Operate(AxisSet.AxisW, (int)((CurrInfo.LNSCheckSafeWHeight - CurrInfo.LogPosW) * 1000), OtherSet.LNSBackSpeed * 1000 / 60);
                    lnsCheckCount = 0;
                    isLnsMoved = false;
                }
            }
        }

        private void CheckZMinus()
        {
            if (IOHelper.IsShifuStart() && IOHelper.IsZMinusLimit())
            {
                CloseAllOutput();
                card.OperateStopRun();
                PlcHelpr.SendMsg(PortHelper.ZDownOff);
                PlcHelpr.SendMsg(PortHelper.ZDownOff2);
            }
        }

        #region 伺服报警
        private bool isBBatteryWarninged;
        private bool isCBatteryWarninged;
        private bool isWarninged = false;
        private void CheckAlarm()
        {
            bool flag = false;
            if (AbsolutePosSet.IsBBatteryWarning && !isBBatteryWarninged)
            {
                if (!isWarninged)
                    WarningForm.AddWarning(L.R("FormMain.BBatteryError", "B轴电池错误"));
                isBBatteryWarninged = true;
                flag = true;
            }
            if (AbsolutePosSet.IsCBatteryWarning && !isCBatteryWarninged)
            {
                if (!isWarninged)
                    WarningForm.AddWarning(L.R("FormMain.CBatteryError", "C轴电池错误"));
                isCBatteryWarninged = true;
                flag = true;
            }
            if (!IOHelper.IsQiYaCheck())
            {
                if (!isWarninged)
                    WarningForm.AddWarning(L.R("FormMain.QiYaError", "气压未到"));
                flag = true;
            }
            if (!OtherSet.IgnoreShifuBaojing)
            {
                if (!AxisSet.IgnoreX && !IOHelper.IsXNotWarning())
                {
                    if (!isWarninged)
                        WarningForm.AddWarning(L.R("FormMain.XError", "X轴异常"));
                    flag = true;
                }
                if (!AxisSet.IgnoreY && !IOHelper.IsYNotWarning())
                {
                    if (!isWarninged)
                        WarningForm.AddWarning(L.R("FormMain.YError", "Y轴异常"));
                    flag = true;
                }
                if (!AxisSet.IgnoreW && !IOHelper.IsWNotWarning())
                {
                    if (!isWarninged)
                        WarningForm.AddWarning(L.R("FormMain.WError", "W轴异常"));
                    flag = true;
                }
                if (!AxisSet.IgnoreZ && !IOHelper.IsZNotWarning())
                {
                    if (!isWarninged)
                        WarningForm.AddWarning(L.R("FormMain.ZError", "Z轴异常"));
                    flag = true;
                }
                if (!AxisSet.IgnoreB && !IOHelper.IsBNotWarning())
                {
                    if (!isWarninged)
                        WarningForm.AddWarning(L.R("FormMain.BError", "B轴异常"));
                    flag = true;
                }
                if (!AxisSet.IgnoreC && !IOHelper.IsCNotWarning())
                {
                    if (!isWarninged)
                        WarningForm.AddWarning(L.R("FormMain.CError", "C轴异常"));
                    flag = true;
                }
            }
            if (IOHelper.IsXPlusLimit())
            {
                if (!isWarninged)
                    WarningForm.AddWarning(L.R("FormMain.XPlusError", "X轴已至硬件正限位"));

                flag = true;
            }
            if (IOHelper.IsXMinusLimit())
            {
                if (!isWarninged)
                    WarningForm.AddWarning(L.R("FormMain.XMinusError", "X轴已至硬件负限位"));
                flag = true;
            }
            if (IOHelper.IsYPlusLimit())
            {
                if (!isWarninged)
                    WarningForm.AddWarning(L.R("FormMain.YPlusError", "Y轴已至硬件正限位"));
                flag = true;
            }
            if (IOHelper.IsYMinusLimit())
            {
                if (!isWarninged)
                    WarningForm.AddWarning(L.R("FormMain.YMinusError", "Y轴已至硬件负限位"));
                flag = true;
            }
            if (!isZero && IOHelper.IsWPlusLimit())
            {
                if (!isWarninged)
                    WarningForm.AddWarning(L.R("FormMain.WPlusError", "W轴已至硬件正限位"));
                flag = true;
            }
            if (IOHelper.IsWMinusLimit())
            {
                if (!isWarninged)
                    WarningForm.AddWarning(L.R("FormMain.WMinusError", "W轴已至硬件负限位"));
                flag = true;
            }
            if (IOHelper.IsZMinusLimit())
            {
                if (!isWarninged)
                    WarningForm.AddWarning(L.R("FormMain.ZMinusError", "Z轴已至硬件负限位"));
                flag = true;
            }
            if (IOHelper.IsBMinusLimit())
            {
                if (!isWarninged)
                    WarningForm.AddWarning(L.R("FormMain.BMinusError", "B轴已至硬件负限位"));
                flag = true;
            }
            if (IOHelper.IsBPlusLimit())
            {
                if (!isWarninged)
                    WarningForm.AddWarning(L.R("FormMain.BPlusError", "B轴已至硬件正限位"));
                flag = true;
            }
            if (!isWarninged && flag)
            {
                isWarninged = true;
            }
            else if (!flag)
            {
                isWarninged = false;
            }
            btnWarning.Checked = flag;
        }
        #endregion

        #region 检查W正限位
        private void CheckWPlus()
        {
            if (IOHelper.IsWPlusLimit() && isZero)
            {
                card.SetLogPos(AxisSet.AxisW, 0);
            }
        }
        #endregion

        #region 检查Z正限位
        private void CheckZPlus()
        {
            if (IOHelper.IsZPlusLimit())
            {
                card.SetActPos(AxisSet.ZReadAxis, 0);
                plcHelper.SendMsg(PortHelper.ZUpOff);
            }
        }
        #endregion

        #region 检查扶丝
        //设置的
        private void CheckFusi()
        {
            if (OtherSet.FusiLocation != 0)
            {
                if (CurrInfo.LogPosZ >= OtherSet.FusiLocation + 10
                    && this.btnFushi.Value == 1
                    && this.btnJiagong.Checked)//如果是开加工并且是黄灯 并且是 0-扶丝器高度+50
                {
                    this.btnFushi.Value = 0; //变成红色
                    plcHelper.SendMsg(PortHelper.FushiOn);
                }
                else if ((CurrInfo.LogPosZ > 0 || CurrInfo.LogPosZ < OtherSet.FusiLocation || !this.btnJiagong.Checked || IOHelper.IsStopButton())
                    && this.btnFushi.Value == 0)//如果回退到了>0的高度或者小于扶丝高度或者不在加工或者急停状态
                {
                    this.btnFushi.Value = 1; //变成黄色
                    plcHelper.SendMsg(PortHelper.FushiOff);
                }
            }
        }
        #endregion

        #region 判断急停
        /// <summary>
        /// 检查任何输入口
        /// </summary>
        private void CheckUrgencyStop()
        {
            if (IOHelper.IsShifuStart() && IOHelper.IsStopButton())
            {
                isAutoCenter = false;
                centerType = 0;
                centerAttemps = 0;
                IOHelper.CloseShifu();
                isContinue = false;
                CloseAllOutput();
                btnLight.Checked = false;
                btnBuzzing.Checked = false;
                card.CloseAllMove();
                card.OperateClose();
                isM21 = false;
                isChangeDaoMove = false;
                isChangeDao = false;
                isChangeDaoCheckFailureHeight = true;
                PlcHelpr.SendMsg(PortHelper.LNSOff);
                isLNSCheck = false;
            }
            else if (!IOHelper.IsShifuStart())
            {
                isBBatteryWarninged = false;
                isCBatteryWarninged = false;
                IOHelper.StartShifu();
            }
        }
        #endregion

        #region 判断清零状态
        public void SetZeroState()
        {
            btnZZero.Checked = IOHelper.IsZero();
        }
        #endregion

        #region 判断穿透状态
        private void SetThrowState()
        {
            btnZThrow.Checked = IOHelper.IsThrow();
        }
        #endregion

        #region 判断W轴碰撞状态
        private void SetWHitState()
        {
            int flag = (!isM21 && !isSkipProtect && !btnWHitIgnore.Checked && !this.btnJiagong.Checked && !isChangeDianji && !isCtrlDown) ? 1 : 0;
            IOHelper.SetHitProtect(flag);
            btnWHit.Checked = IOHelper.IsWHit();
            if (!isM21 && btnWHit.Checked) //任何时候短路信号有的情况下
            {
                card.moveState = 0;
                this.StopImmediately();
            }
        }
        #endregion

        #region 检查Z轴限位
        /// <summary>
        /// Z轴限位控制
        /// </summary>
        private void CheckZLimit()
        {
            //bool isZPlusLimit = IOHelper.IsZPlusLimit();
            //bool isZMinusLimit = IOHelper.IsZMinusLimit();
            //if (!isZPlusLimit)
            //{
            //    isZUp = false;
            //}
            //if (isZPlusLimit && !isZUp)
            //{
            //    //MasterStopUp();
            //    isZUp = true;
            //}
            //if (!isZMinusLimit)
            //{
            //    isZDown = false;
            //}
            //if (isZMinusLimit && !isZDown)
            //{
            //    //MasterStopDown();
            //    isZDown = true;
            //    this.lockedButton = Keys.NoName;
            //    this.gridViewCnc.Focus();
            //}
        }
        #endregion

        #region C回原点
        private bool isCOrigined = false;
        private bool isCOrigined2 = false;
        private int cOriginCount = 0;
        private void CheckCOrigin()
        {
            if (IOHelper.IsCZero() && isZero && zeroInfo != null && zeroInfo.IsZeroC)
            {
                if (!isCOrigined)
                {
                    if (cOriginCount < 4)
                    {
                        cOriginCount++;
                    }
                    if (cOriginCount >= 4)
                    {
                        card.SingleMoveC(new HoleInfo() { C = -1000000 }, this.axisType, 1000);
                        isCOrigined = true;
                        isCOrigined2 = false;
                    }
                }
                else
                {
                    isCOrigined2 = true;
                }
            }
            else
            {
                cOriginCount = 0;
            }
        }

        private void CheckCZero()
        {
            if (!IOHelper.IsCZero() && IOHelper.IsCOrigin() && isZero && isCOrigined && isCOrigined2 && zeroInfo != null && zeroInfo.IsZeroC)
            {
                card.SetLogPos(AxisSet.AxisC, 0);
                card.CloseSingleMove(AxisSet.AxisC);
                isCOrigined = false;
            }
        }
        #endregion

        private void SetFirstByParam()
        {
            ParamList list = this.GetParamList(param);
            int count = list.Count;
            if (count < 2)
            {
                isContinue = false;
                isRestart = false;
                throw new WarningException(param + L.R("FormMain.MustHavTwoParam", "必须有两行加工参数!"));
            }
            this.zeroHeight = list[0].Depth;
            this.machineHeight = list[count - 2].Depth2;
            this.backHeight = list[count - 1].Depth2;
            this.isM21ZUpRotate = list[count - 1].Rotate;
            if (machineHeight >= this.backHeight)
            {
                isContinue = false;
                isRestart = false;
                throw new WarningException(param + L.R("FormMain.BackHeightWarning", "回退高度必须大于加工深度!"));
            }
            var info = list[0];
            paramIndex = 0;
            IOHelper.SetTOn(info.TOn);
            IOHelper.SetTOff(info.TOff);
            IOHelper.SetI(info.I);
            IOHelper.SetI2(info.I2);
            IOHelper.SetSpeed(info.Speed);
            IOHelper.SetV(info.V);
            btnAxisR.Checked = info.Rotate;
            if (info.Fanjixing)  //如果参数第一行 有反极性，要先关碰撞保护，再开反极性
                SetWHitState();
            btnFanjixing.Checked = info.Fanjixing;
            paramStopSecond = info.StopTime;
            this.gridViewParam.Invalidate();
        }

        private int currThrowMode;
        private void SetByThrowSet(string throwMode)
        {
            switch (throwMode)
            {
                case "0": plcHelper.SendMsg(PortHelper.ThrowOff); break;
                case "1": plcHelper.SendMsg(PortHelper.ThrowMode1); break;
                case "2": plcHelper.SendMsg(PortHelper.ThrowMode2); break;
            }
            currThrowMode = Convert.ToInt32(throwMode);
            int throwResponse = ThrowSet.GetThrowResponse(currThrowMode);
            plcHelper.SendMsg(PortHelper.ThrowResponse + (throwResponse * 2 + 12).ToString("X4"));
            if (!string.IsNullOrEmpty(param))
            {
                this.tabE.SelectedTabPage = this.tabE.TabPages.Where(x => x.Text == param).FirstOrDefault();
                string mode = null;
                switch (throwMode)
                {
                    case "0": mode = L.R("FormMain.ThrowMode.NotThrow", "不使用穿透"); break;
                    case "1": mode = L.R("FormMain.ThrowMode.Mode1", "穿透模式1"); break;
                    case "2": mode = L.R("FormMain.ThrowMode.Mode2", "穿透模式2"); break;
                }
                this.lbJiagongWarning.Text = string.Format(L.R("FormMain.CurrentParamWarning", "当前使用加工参数:{0},\r\n穿透模式:{1}"), param, mode);
            }
        }

        private void CheckWaitForJiaong()
        {
            if (isM21WaitForJiaGong && (DateTime.Now - m21WaitForJiagongStartTime).TotalSeconds > (double)OtherSet.ShuibengDelay)
            {
                IOHelper.SetJiagong(1);
                plcHelper.SendMsg(PortHelper.JiagongOn);
                if (this.btnShineng.Checked)
                    plcHelper.SendMsg(PortHelper.ShinengOn);
                isM21WaitForJiaGong = false;
            }
        }

        /// <summary>
        /// 有了清零信号后，还要把Z轴数据清零
        /// </summary>
        bool isChangeDianji = false;
        private void CheckDuanlu()
        {
            if (IOHelper.IsZero() && !isM21Zero && isM21)
            {
                isChangeDaoCheckFailureHeight = true;
                zeroCurrentHeight = this.CurrInfo.GetActPosZ(this.axisType);
                this.CurrInfo.ZeroZ(zeroHeight);
                minPosition = 0;
                var logPosZ = this.CurrInfo.LogPosZ;
                if ((logPosZ + this.machineHeight) < card.GetZStroke())
                {
                    this.StopImmediately();
                    CancelZero();
                    Thread.Sleep(100);
                    //isChangeDianji = true;
                    IOHelper.SetHitProtect(0);
                    if (OtherSet.UseChangeDao)
                    {
                        ChangeDaoMove(true);
                    }
                    else
                    {
                        if (ContraHelper.ShowQuestion(L.R("FormMain.ChangeDianJi", "请更换电极,您是否要回退到更换电极位置？"), OtherSet.JiagongErrorWaitTime))
                        {
                            isChangeDianji = true;
                            IOHelper.SetHitProtect(0);
                            Thread.Sleep(100);
                            card.SingleMoveZ(new HoleInfo() { Z = this.CurrInfo.GetActPosZ(axisType) - logPosZ + OtherSet.ChangePoleHeight }, this.axisType);
                            plcHelper.SendMsg(PortHelper.ZUpOn);
                            isBackToZChange = true;
                            backToChangePosition = this.CurrInfo.GetActPosZ(axisType) - logPosZ + OtherSet.ChangePoleHeight;
                        }
                    }
                    this.gridViewCnc.Focus();
                }
                else
                {
                    currentSecond = 0;
                    jiagongZeroStartTime = DateTime.Now;
                    isM21Zero = true;
                    isM21ZDown = false;
                }
            }
        }

        /// <summary>
        /// 穿透位置
        /// </summary>
        decimal throwPosition = 0;
        decimal minPosition = 0;
        int m21ZDownState = 0;
        bool isLastThrow = false;
        bool isM21EndStop = false;
        private decimal zeroCurrentHeight;

        private bool isThrowZStarted = false;
        private bool isThrowZStoped = false;
        private decimal throwZDetectedHeight = 0;
        private bool isThrowZDetected = false;
        private bool isThrowZEndStoped = false;
        private bool isThrowZWHitDetected = false;
        private decimal throwZReachPosition = 0;
        private bool isM21ZUpWHit = false;

        /// <summary>
        /// 数值清完零后，判断是否所有的加工都已完成，完成后抬升A到回退高度
        /// </summary>
        private void WaitForM21ZDown()
        {
            var list = GetParamList(param);
            barStaticItem2.Caption = isM21Zero + "|" + isM21 + "|" + isM21ZDown + "|" + CurrInfo.JiaGongOverTime + "|" + currentSecond + "|" + backHeight;
            if (isM21Zero && isM21 && !isM21ZDown && CurrInfo.JiaGongOverTime != 0 && currentSecond > CurrInfo.JiaGongOverTime)
            {
                this.btnShineng.Checked = false;
                this.btnAxisR.Checked = isM21ZUpRotate;
                m21ZDownState = 0;
                paramIndex = list.Count - 1;
                isLastThrow = false;
                this.gridViewParam.Invalidate();
                var hole = inputHole ?? this.gridViewCnc.GetRow(currPostion) as HoleInfo;
                if (hole != null)
                {
                    jiagongHistory.Insert(0, new JiagongHistoryInfo()
                    {
                        AxisType = hole.AxisType,
                        X = hole.X,
                        Y = hole.Y,
                        W = hole.W,
                        B = hole.B,
                        C = hole.C,
                        Line = currPostion + 1,
                        MachineHeight = machineHeight,
                        Seconds = currentSecond,
                    });
                    int historyCount = jiagongHistory.Count;
                    if (historyCount >= 2)
                    {
                        jiagongHistory[1].ZeroHeight = zeroCurrentHeight;
                        jiagongHistory[1].HoleHeight = (jiagongHistory[1].ThrowHeight ?? jiagongHistory[1].MachineHeight) - zeroCurrentHeight;
                    }
                }

                card.SingleMoveZ(new HoleInfo() { Z = backHeight * OtherSet.BackHeightRate, IsJiaGong = false }, this.axisType);
                PlcHelpr.SendMsg(PortHelper.ZUpOn);
                throwPosition = 0;
                minPosition = 0;
                isM21ZDown = true;
                isM21EndStop = true;
                isM21ZUpWHit = false;
                isM21FinishCloseShuibeng = true;
            }
            else
            {
                var position = this.CurrInfo.GetActPosZ(axisType);
                if (isThrowZDetected && (position < throwZDetectedHeight + 0.02m || AxisSet.ThrowStartMode == 0))//穿透开始位置设置为0 代表穿透位置直接开始穿透位置模式
                {
                    isThrowZDetected = false;
                    this.btnShineng.Checked = false;
                    this.CurrInfo.LogPosZ = card.GetActPos(AxisSet.ZReadAxis) * AxisSet.ZResolution;
                    card.SingleMoveZ(new HoleInfo() { Z = throwZReachPosition }, this.axisType, AxisSet.ThrowSpeed);
                    plcHelper.SendMsg(PortHelper.ZDownOn);
                    isThrowZStoped = false;
                    isThrowZEndStoped = true;
                    isThrowZWHitDetected = false;
                }
                minPosition = minPosition > position ? position : minPosition;
                bool isThrow = IOHelper.IsThrow();
                bool isClose = IOHelper.IsClose();
                if (((isM21Zero && isM21) || isThrow || isClose) && !isM21ZDown)
                {
                    decimal throwLeft = ThrowSet.GetThrowLeft(currThrowMode);
                    if (isThrow && AxisSet.ThrowMode == 0)
                    {
                        if (throwLeft != 0 && throwPosition == 0)
                        {
                            throwPosition = minPosition + throwLeft;
                        }
                        barStaticItem3.Caption = position + "|" + minPosition + "|" + throwPosition;
                    }
                    if (isThrow && isThrowZStarted && AxisSet.ThrowMode == 1)
                    {
                        if (throwLeft != 0)
                        {
                            if (isThrowZDetected == false)
                            {
                                isThrowZDetected = true;
                                throwZDetectedHeight = minPosition;
                                throwZReachPosition = minPosition + throwLeft;
                                barStaticItem3.Caption = position + "|" + minPosition;

                                var info = list[paramIndex + 1];
                                IOHelper.SetI(info.I);
                                IOHelper.SetI2(info.I2);
                                IOHelper.SetTOff(info.TOff);
                                IOHelper.SetTOn(info.TOn);
                                IOHelper.SetSpeed(info.Speed);
                                IOHelper.SetV(info.V);
                            }
                        }
                        else
                        {
                            isThrowZStoped = true;
                        }
                        isThrowZStarted = false;
                    }
                    else if (((!isThrow && !isClose && (position <= this.machineHeight || m21ZDownState != 0))
                        || (isThrow && ((AxisSet.ThrowMode == 0 && (throwLeft == 0 || position < throwPosition)) || (AxisSet.ThrowMode == 1 && isThrowZStoped))) || isClose) && !isWaitParamStopTime)
                    {
                        if ((isThrow || isClose) && minPosition > ThrowSet.GetThrowStartHeight(currThrowMode))
                        {
                            this.StopImmediately();
                            DialogResult result = ContraHelper.ShowQuestion2(L.R("FormMain.WorkError", "加工失败，继续加工？!"));
                            if (result == DialogResult.Yes)
                            {
                                this.isContinue = true;
                            }
                            else if (DialogResult.No == result)
                            {
                                this.CancelZero();
                            }
                            else
                            {
                                this.CancelZero();
                                this.IOHelper.SetHitProtect(0);
                                Thread.Sleep(100);
                                this.isChangeDianji = true;
                                card.ReadPos();
                                card.SingleMoveZ(new HoleInfo() { Z = this.CurrInfo.GetActPosZ(axisType) - this.CurrInfo.LogPosZ + OtherSet.ChangePoleHeight }, this.axisType);
                                plcHelper.SendMsg(PortHelper.ZUpOn);
                                isBackToZChange = true;
                                backToChangePosition = this.CurrInfo.GetActPosZ(axisType) - this.CurrInfo.LogPosZ + OtherSet.ChangePoleHeight;
                                this.gridViewCnc.Focus();
                            }
                            this.gridViewCnc.Focus();
                        }
                        else if (paramStopSecond != 0)
                        {
                            if (isThrow)
                                m21ZDownState = 1;
                            else if (isClose)
                                m21ZDownState = 2;
                            paramStopStartTime = DateTime.Now;
                            isWaitParamStopTime = true;
                            btnShineng.Checked = false;
                        }
                        else
                        {
                            this.btnShineng.Checked = false;
                            this.btnAxisR.Checked = isM21ZUpRotate;
                            m21ZDownState = 0;
                            paramIndex = list.Count - 1;
                            isLastThrow = false;
                            this.gridViewParam.Invalidate();
                            var hole = inputHole ?? this.gridViewCnc.GetRow(currPostion) as HoleInfo;
                            if (hole != null)
                            {
                                jiagongHistory.Insert(0, new JiagongHistoryInfo()
                                {
                                    AxisType = hole.AxisType,
                                    X = hole.X,
                                    Y = hole.Y,
                                    W = hole.W,
                                    B = hole.B,
                                    C = hole.C,
                                    Line = currPostion + 1,
                                    MachineHeight = machineHeight,
                                    Seconds = currentSecond,
                                    ThrowHeight = isThrow || isClose ? (Nullable<decimal>)minPosition : null
                                });
                                int historyCount = jiagongHistory.Count;
                                if (historyCount >= 2)
                                {
                                    jiagongHistory[1].ZeroHeight = zeroCurrentHeight;
                                    jiagongHistory[1].HoleHeight = (jiagongHistory[1].ThrowHeight ?? jiagongHistory[1].MachineHeight) - zeroCurrentHeight;
                                }
                            }
                            if (isThrow)
                                biLastHole.Caption = string.Format(L.R("FormMain.LastThrowDepth", "上一个孔的穿透深度:{0:0.000}"), minPosition);
                            card.SingleMoveZ(new HoleInfo() { Z = backHeight * OtherSet.BackHeightRate, IsJiaGong = false }, this.axisType);
                            PlcHelpr.SendMsg(PortHelper.ZUpOn);
                            throwPosition = 0;
                            minPosition = 0;
                            isM21ZUpWHit = false;
                            isM21ZDown = true;
                        }
                    }
                    else
                    {
                        if (paramIndex >= 0 && paramIndex < list.Count)
                        {
                            var info = list[paramIndex];
                            if (position <= info.Depth2 && !isWaitParamStopTime)
                            {
                                if (paramStopSecond != 0)
                                {
                                    paramStopStartTime = DateTime.Now;
                                    isWaitParamStopTime = true;
                                    btnShineng.Checked = false;
                                }
                                else
                                {
                                    while (true)
                                    {
                                        paramIndex++;
                                        if (paramIndex >= list.Count)
                                        {
                                            break;
                                        }
                                        info = list[paramIndex];
                                        if (position > info.Depth2)
                                        {
                                            info = list[paramIndex];
                                            paramStopSecond = info.StopTime;
                                            IOHelper.SetI(info.I);
                                            IOHelper.SetI2(info.I2);
                                            IOHelper.SetTOff(info.TOff);
                                            IOHelper.SetTOn(info.TOn);
                                            IOHelper.SetSpeed(info.Speed);
                                            IOHelper.SetV(info.V);
                                            SetByThrowSet(info.ThrowMode);
                                            btnAxisR.Checked = info.Rotate;
                                            btnFanjixing.Checked = info.Fanjixing;
                                            this.gridViewParam.Invalidate();
                                            break;
                                        }
                                    }
                                }
                            }
                            else if (isWaitParamStopTime)
                            {
                                TimeSpan span = DateTime.Now - paramStopStartTime;
                                if (span.Seconds > paramStopSecond)
                                {
                                    btnShineng.Checked = true;
                                    isWaitParamStopTime = false;
                                    paramStopSecond = 0;
                                }
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 抬升到回退高度后，关闭加工
        /// </summary>
        private void WaitForM21ZUp()
        {
            if (isM21Zero && isM21ZDown && this.CurrInfo.GetActPosZ(axisType) >= (backHeight - 0.02m) && IOHelper.IsZero())
            {
                plcHelper.SendMsg(PortHelper.ZUpOff);
                this.isM21 = false;
                this.isM21Zero = false;
                this.isM21ZDown = false;
                this.lbStopWarning.Visible = false;
                totalCount += 1;
                timerTotal_Tick(null, null);
                timerCurrent.Enabled = false;
                lastSecond = currentSecond;
                currentSecond = 0;
                isEndM21 = false;
                if (isM21FinishCloseShuibeng)//加工完成后
                {
                    CloseAllOutput();
                    btnFanjixing.Checked = false;
                    CancelZero();
                    isM21FinishCloseShuibeng = false;
                    timerTotal.Enabled = false;
                    isContinue = false;
                    this.btnMen.Value = this.btnMen.Value == 2 ? 2 : 1; //绿色的变成绿色红色的变成黄色
                    IOHelper.SetMen(0);
                    return;
                }
                plcHelper.SendMsg("0500FFBW0M0104010");
            }
        }

        #region StartMove
        public bool isEndM21 = false;
        private bool isEndStop = false;
        public bool isEndStartMove = false;
        private string param = "E1";
        private void StartMove()
        {
            var hole = inputHole ?? this.gridViewCnc.GetRow(currPostion) as HoleInfo;
            if ((isEndStartMove || !CurrInfo.UseSafeHeight) && !string.IsNullOrEmpty(hole.AxisType))
            {
                this.tabShow.SelectedTabPage = this.tabShow.TabPages.Where(x => x.Text == hole.AxisType).FirstOrDefault();
                this.axisType = hole.AxisType;
                this.grpContrl.Text = string.Format(L.R("FormMain.CurrentAxis", "坐标系，当前使用") + hole.AxisType);
                StartMove(hole);
            }
            //如果使用安全高度 先移动安全高度
            if (!isEndStartMove && CurrInfo.UseSafeHeight)
            {
                isEndStartMove = true;
                card.SingleMoveW(new HoleInfo() { W = CurrInfo.SafeHeight + CurrInfo.GetActPosW(axisType) - CurrInfo.LogPosW }, this.tabShow.SelectedTabPage.Text);
            }
        }

        private void StartMove(HoleInfo info)
        {
            SingleMove(info);
            isEndM21 = info.IsJiaGong && !this.cbEmptyRun.Checked;// && (!isSingle || (isSingle && CurrInfo.GetActPosX(info.AxisType) == info.X && CurrInfo.GetActPosY(info.AxisType) == info.Y));
            param = info.Param;
        }

        #region 解析坐标系 如G90 G55
        private void SetAxisAndType(HeadInfo info)
        {
            HeadInfo headInfo = info as HeadInfo;
            if (headInfo.AxisType == HeadType.G90)
                card.SetAbsolute();
            else
                card.SetRelative();
            SetCoordinatePage(headInfo.Coordinate);
        }

        private void SetCoordinatePage(string axisType)
        {
            foreach (DevExpress.XtraTab.XtraTabPage item in this.tabShow.TabPages)
            {
                if (string.Equals(item.Text, axisType))
                {
                    this.tabShow.SelectedTabPage = item;
                    break;
                }
            }
        }
        #endregion

        #region 轴移动
        private void SingleMove(HoleInfo info)
        {
            card.SingleMove(info, this.tabShow.SelectedTabPage.Text);
        }

        private void UnionMove(UnionMoveInfo info)
        {
            card.UnionMove(info, this.tabShow.SelectedTabPage.Text);
        }
        #endregion

        #region M21
        bool isM21WaitForJiaGong = false;
        DateTime m21WaitForJiagongStartTime;
        public void M21()
        {
            if (isChangeRow)
            {
                isChangeRow = false;
                CancelZero();
            }
            timerCurrent.Enabled = true;
            timerTotal.Enabled = true;
            btnDuidao.Checked = false;
            SetFirstByParam();
            isM21 = true;
            ParamList list = this.GetParamList(param);
            SetByThrowSet(list[0].ThrowMode);
            if (btnShuibang.Checked || OtherSet.ShuibengDelay <= 0) //不使用延时
            {
                isM21WaitForJiaGong = false;
                if (this.btnJiagong.Checked == true)
                {
                    IOHelper.SetJiagong(btnJiagong.Checked ? 1 : 0);
                    plcHelper.SendMsg(btnJiagong.Checked ? PortHelper.JiagongOn : PortHelper.JiagongOff);
                }
            }
            else
            {
                m21WaitForJiagongStartTime = DateTime.Now;
                isM21WaitForJiaGong = true;
            }
            btnShuibang.Checked = true;
            btnJiagong.Checked = true;
            btnShineng.Checked = true;

            if (this.btnMen.Value == 1)//黄色时，门上升
            {
                this.btnMen.Value = 0;
                IOHelper.SetMen(1);
            }
            IOHelper.SetHitProtect(0);
            Thread.Sleep(30);
            btnChongShui.Checked = true;

            isThrowZStoped = false;
            isThrowZStarted = true;
            isThrowZEndStoped = false;
        }


        #endregion

        #region End
        private void End()
        {
            this.btnShuibang.Checked = false;
            this.btnShineng.Checked = false;
            ContraHelper.ShowMessage(L.R("FormMain.ScriptFinish", "脚本运行结束!"));
            currPostion = 0;
            this.gridViewCnc.Focus();
        }
        #endregion
        #endregion
        #endregion

        #region 运动控制
        #region 开始
        private void miStart_ItemClick(object sender, EventArgs e)
        {
            if (this.gridViewCnc.RowCount == 0)
            {
                throw new Exception(L.R("FormMain.ScriptNotLoad", "还未加载脚本!"));
            }
            inputHole = null;
            inputInfo = null;
            if (currPostion >= this.gridViewCnc.RowCount)
                currPostion = this.gridViewCnc.RowCount - 1;
            isContinue = true;
            isRestart = true;
            card.SetAbsolute();
            timerTotal.Enabled = true;
            this.gridViewCnc.Focus();
        }
        #endregion

        #region 暂停
        private void miStop_ItemClick(object sender, EventArgs e)
        {
            isContinue = false;
            lbStopWarning.Visible = true;
        }

        private void StopImmediately()
        {
            isContinue = false;
            isM21 = false;
            isEndM21 = false;
            CloseAllOutput();
            card.CloseAllMove();
            timerCurrent.Enabled = false;
            isChangeDianji = false;
            this.gridViewCnc.Focus();
        }

        public void CloseAllOutput()
        {
            this.btnAxisR.Checked = false;
            this.btnShuibang.Checked = false;
            this.btnJiagong.Checked = false;
            this.btnFanjixing.Checked = false;
            this.btnShineng.Checked = false;
            this.btnChongShui.Checked = false;
        }
        #endregion

        #region 复位
        private void miRestart_ItemClick(object sender, EventArgs e)
        {
            currPostion = 0;
            isContinue = false;
            isRestart = false;
            isM21 = false;
            isM21Zero = false;
            lbStopWarning.Visible = false;
            CancelZero();
            this.gridViewCnc.FocusedRowHandle = 0;
            this.gridViewCnc.Focus();
        }
        #endregion

        #region 清零复位

        private void btnZeroRestart_Click(object sender, EventArgs e)
        {
            isM21Zero = false;
            CancelZero();
        }
        #endregion

        #region 机械回零
        private void miToZero_ItemClick(object sender, EventArgs e)
        {
            FormToZero frmToZero = new FormToZero(ZeroInfo, AxisSet);
            DialogResult result = frmToZero.ShowDialog();
            if (result == DialogResult.OK || result == DialogResult.Yes)
            {
                ToZero(frmToZero.ZeroInfo, result);
            }
        }

        ToZeroInfo zeroInfo;
        private void ToZero(ToZeroInfo info, DialogResult result)
        {
            isZero = true;
            isZeroAttemp = 0;
            isCOrigined = false;
            zeroInfo = info;
            if ((info.IsZeroX || result == DialogResult.Yes) && !AxisSet.IgnoreX)
            {
                if (AbsolutePosSet.UseAbsolutePos || AbsolutePosSet.UseFushiAbsolutePos)
                {
                    card.SingleMoveX(new HoleInfo() { X = this.CurrInfo.GetActPosX(axisType) - this.CurrInfo.LogPosX }, this.axisType);
                }
                else
                {
                    card.Home(AxisSet.AxisX, 0, CurrInfo.StartSpeed, AxisSet.SpeedXPerSecond, 2000, 4000, 0);
                }
            }
            if ((info.IsZeroY || result == DialogResult.Yes) && !AxisSet.IgnoreY)
            {
                if (AbsolutePosSet.UseAbsolutePos || AbsolutePosSet.UseFushiAbsolutePos)
                {
                    card.SingleMoveY(new HoleInfo() { Y = this.CurrInfo.GetActPosY(axisType) - this.CurrInfo.LogPosY }, this.axisType);
                }
                else
                {
                    card.Home(AxisSet.AxisY, 0, CurrInfo.StartSpeed, AxisSet.SpeedYPerSecond, 2000, 4000, 0);
                }
            }
            if ((info.IsZeroW || result == DialogResult.Yes) && !AxisSet.IgnoreW)
            {
                card.SingleMoveW(new HoleInfo() { W = 1000000 }, this.axisType);
            }
            if ((info.IsZeroZ || result == DialogResult.Yes) && !AxisSet.IgnoreZ)
            {
                card.SingleMoveZ(new HoleInfo() { Z = 1000000 }, this.axisType);
                plcHelper.SendMsg(PortHelper.ZUpOn);
            }
            if ((info.IsZeroB || result == DialogResult.Yes) && !AxisSet.IgnoreB)
            {
                card.SingleMoveB(new HoleInfo() { B = this.CurrInfo.GetActPosB(axisType) - this.CurrInfo.LogPosB }, this.axisType);
            }
            if ((info.IsZeroC || result == DialogResult.Yes) && !AxisSet.IgnoreC)
            {
                cOriginCount = 0;
                card.SingleMoveC(new HoleInfo() { C = 1000000 }, this.axisType, 10000);

                //card.SingleMoveC(new HoleInfo() { C = this.CurrInfo.GetActPosC(axisType) - this.CurrInfo.LogPosC }, this.axisType);
            }
        }
        #endregion

        #region 运行上一步
        private void miPrevious_Click(object sender, EventArgs e)
        {
            var selectRow = this.gridViewCnc.FocusedRowHandle;
            if (selectRow < 0)
            {
                throw new Exception(L.R("FormMain.NotChooseAnyHole", "还未选中任何孔位!"));
            }
            if (selectRow < 1)
            {
                throw new Exception(L.R("FormMain.IsFirst", "已是首位!"));
            }
            currPostion = selectRow - 1;
            isContinue = true;
            isRestart = true;
            isSingle = true;
        }
        #endregion

        #region 运行下一步
        private void miNext_Click(object sender, EventArgs e)
        {
            var selectRow = this.gridViewCnc.FocusedRowHandle;
            if (selectRow < 0)
            {
                throw new Exception(L.R("FormMain.NotChooseAnyHole", "还未选中任何孔位!"));
            }
            if (selectRow + 1 > this.gridViewCnc.RowCount)
            {
                throw new Exception(L.R("FormMain.RunToEnd", "已运行至结尾!"));
            }
            inputHole = null;
            inputInfo = null;
            currPostion = selectRow;
            isContinue = true;
            isRestart = true;
            isSingle = true;
        }
        #endregion
        #endregion

        #region 清零加设置

        #region 清零54
        private void btnZeroX_Click(object sender, EventArgs e)
        {
            this.CurrInfo.SetActPosX(this.axisType, 0);
        }

        private void btnZeroY_Click(object sender, EventArgs e)
        {
            this.CurrInfo.SetActPosY(this.axisType, 0);
        }

        private void btnZeroW_Click(object sender, EventArgs e)
        {
            this.CurrInfo.SetActPosW(this.axisType, 0);
        }

        private void btnZeroZ_Click(object sender, EventArgs e)
        {
            this.CurrInfo.SetActPosZ(this.axisType, 0);
            //CancelZero();
        }

        private void btnZeroB_Click(object sender, EventArgs e)
        {
            this.CurrInfo.SetActPosB(this.axisType, 0);
        }

        private void btnZeroC_Click(object sender, EventArgs e)
        {
            this.CurrInfo.SetActPosC(this.axisType, 0);
        }

        private void CancelZero()
        {
            if (IOHelper.IsZero())
            {
                plcHelper.SendMsg(PortHelper.Duanlu);
            }
        }
        #endregion

        #region 1/2
        private void btnHalfX_Click(object sender, EventArgs e)
        {
            this.CurrInfo.SetActPosX(this.axisType, this.CurrInfo.GetActPosX(this.axisType) / 2);
        }

        private void btnHalfY_Click(object sender, EventArgs e)
        {
            this.CurrInfo.SetActPosY(this.axisType, this.CurrInfo.GetActPosY(this.axisType) / 2);
        }

        private void btnHalfW_Click(object sender, EventArgs e)
        {
            this.CurrInfo.SetActPosW(this.axisType, this.CurrInfo.GetActPosW(this.axisType) / 2);
        }

        private void btnHalfZ_Click(object sender, EventArgs e)
        {
            this.CurrInfo.SetActPosZ(this.axisType, this.CurrInfo.GetActPosZ(this.axisType) / 2);
        }

        private void btnHalfB_Click(object sender, EventArgs e)
        {
            this.CurrInfo.SetActPosB(this.axisType, this.CurrInfo.GetActPosB(this.axisType) / 2);
        }

        private void btnHalfC_Click(object sender, EventArgs e)
        {
            this.CurrInfo.SetActPosC(this.axisType, this.CurrInfo.GetActPosC(this.axisType) / 2);
        }
        #endregion

        #region 设置
        private void btnSetX_Click(object sender, EventArgs e)
        {
            this.CurrInfo.SetActPosX(this.axisType, AxisModify.SetX);
        }

        private void btnSetY_Click(object sender, EventArgs e)
        {
            this.CurrInfo.SetActPosY(this.axisType, AxisModify.SetY);
        }

        private void btnSetW_Click(object sender, EventArgs e)
        {
            this.CurrInfo.SetActPosW(this.axisType, AxisModify.SetW);
        }

        private void btnSetZ_Click(object sender, EventArgs e)
        {
            this.CurrInfo.SetActPosZ(this.axisType, AxisModify.SetZ);
        }

        private void btnSetB_Click(object sender, EventArgs e)
        {
            this.CurrInfo.SetActPosB(this.axisType, AxisModify.SetB);
        }

        private void btnSetC_Click(object sender, EventArgs e)
        {
            this.CurrInfo.SetActPosC(this.axisType, AxisModify.SetC);
        }
        #endregion

        private void spSetX_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.CurrInfo.SetActPosX(this.axisType, AxisModify.SetX);
        }

        private void spSetY_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.CurrInfo.SetActPosY(this.axisType, AxisModify.SetY);
        }

        private void spSetW_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.CurrInfo.SetActPosW(this.axisType, AxisModify.SetW);
        }

        private void spSetB_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.CurrInfo.SetActPosB(this.axisType, AxisModify.SetB);
        }

        private void spSetC_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.CurrInfo.SetActPosC(this.axisType, AxisModify.SetC);
        }

        private void spSetZ_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.CurrInfo.SetActPosZ(this.axisType, AxisModify.SetZ);
        }

        private void tabShow_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            this.gcAxisModify.Text = string.Format(L.R("FormMain.AxisModify", "坐标修改({0})"), e.Page.Text);
            this.axisType = e.Page.Text;

            e.Page.Controls.Add(this.axisControl1);
            this.axisControl1.SetBinding(this.bindingSource, e.Page.Text);
        }
        #endregion

        #region 按钮切换
        private void btnBuzzing_CheckedChanged(object sender, EventArgs e)
        {
            plcHelper.SendMsg(btnBuzzing.Checked ? PortHelper.BuzzingOn : PortHelper.BuzzingOff);
        }

        private void btnShuibang_CheckedChanged(object sender, EventArgs e)
        {
            IOHelper.SetShuibeng(btnShuibang.Checked ? 1 : 0);
            plcHelper.SendMsg(btnShuibang.Checked ? PortHelper.ShuibengOn : PortHelper.ShuibengOff);
            btnChongShui.Checked = btnShuibang.Checked;
            if (!btnShuibang.Checked)
            {
                this.btnJiagong.Checked = false;
            }
        }

        private void btnJiagong_CheckedChanged(object sender, EventArgs e)
        {
            if (!btnJiagong.Checked || OtherSet.ShuibengDelay == 0) //延时加工
            {
                IOHelper.SetJiagong(btnJiagong.Checked ? 1 : 0);
                plcHelper.SendMsg(btnJiagong.Checked ? PortHelper.JiagongOn : PortHelper.JiagongOff);
            }
            if (!isM21 && btnJiagong.Checked)
            {
                param = L.R("FormMain.Manual", "手动");
                M21();
            }
            else if (isM21 && !btnJiagong.Checked)
            {
                StopImmediately();
                inputInfo = null;
                inputHole = null;
                timerTotal.Enabled = false;
                timerCurrent.Enabled = false;
                isM21FinishCloseShuibeng = false;
                this.btnFushi.Value = this.btnFushi.Value == 2 ? 2 : 1; //绿色的变成绿色红色的变成黄色
                this.btnMen.Value = this.btnMen.Value == 2 ? 2 : 1;//绿色的变成绿色红色的变成黄色
                IOHelper.SetMen(0);
                plcHelper.SendMsg(PortHelper.FushiOff);
                isM21 = false;
            }
            else if (!btnJiagong.Checked)
            {
                btnMen.Value = btnMen.Value == 2 ? 2 : 1; //绿色的变成绿色红色的变成黄色
                IOHelper.SetMen(0);
            }
        }

        private void btnShineng_CheckedChanged(object sender, EventArgs e)
        {
            if (!btnJiagong.Checked || OtherSet.ShuibengDelay == 0 || !isM21WaitForJiaGong) //延时加工
            {
                plcHelper.SendMsg(btnShineng.Checked ? PortHelper.ShinengOn : PortHelper.ShinengOff);
            }
        }

        private void btnDuidao_CheckedChanged(object sender, EventArgs e)
        {
            plcHelper.SendMsg(btnDuidao.Checked ? PortHelper.DuidaoOn : PortHelper.DuidaoOff);
        }

        private void btnChongShui_CheckedChanged(object sender, EventArgs e)
        {
            IOHelper.SetChongShui(btnChongShui.Checked ? 1 : 0);
        }

        private void btnFanjixing_CheckedChanged(object sender, EventArgs e)
        {
            IOHelper.SetJixing(btnFanjixing.Checked ? 1 : 0);
            plcHelper.SendMsg(btnFanjixing.Checked ? PortHelper.FanjixingOn : PortHelper.FanjixingOff);
        }

        private void btnAxisR_CheckedChanged(object sender, EventArgs e)
        {
            IOHelper.SetRotate(btnAxisR.Checked ? 1 : 0);
            plcHelper.SendMsg(btnAxisR.Checked ? PortHelper.RotateOn : PortHelper.RotateOff);
        }

        private void btnChuiqi_CheckedChanged(object sender, EventArgs e)
        {
            //SetOutPut(17, btnChuiqi.Checked ? 1 : 0);
        }

        private void btnLight_CheckedChanged(object sender, EventArgs e)
        {
            IOHelper.SetLight(btnLight.Checked ? 1 : 0);
        }

        FormMove formMove;
        private void btnMovePanel_CheckedChanged(object sender, EventArgs e)
        {
            if (btnMovePanel.Checked)
            {
                formMove = new FormMove(card, this);
                formMove.FormClosed += new FormClosedEventHandler(formMove_FormClosed);
                formMove.ShowDialog();
                CurrInfo.StepLength = 0;
                btnMovePanel.Checked = false;
            }
        }

        FormDaoKu formDaoKu;
        private void btnDaoKu_CheckedChanged(object sender, EventArgs e)
        {
            if (btnDaoKu.Checked)
            {
                formDaoKu = new FormDaoKu(this, plcHelper);
                formDaoKu.FormClosed += new FormClosedEventHandler(formDaoKu_FormClosed);
                formDaoKu.ShowDialog();
                btnDaoKu.Checked = false;
            }
        }

        void formDaoKu_FormClosed(object sender, FormClosedEventArgs e)
        {
            formDaoKu = null;
        }

        void formMove_FormClosed(object sender, FormClosedEventArgs e)
        {
            formMove = null;
        }

        private FormWarning warningForm;
        public FormWarning WarningForm
        {
            get
            {
                if (warningForm == null)
                {
                    warningForm = new FormWarning();
                }
                return warningForm;
            }
        }
        private void btnWarning_CheckedChanged(object sender, EventArgs e)
        {
            if (btnWarning.Checked && WarningForm.Visible == false)
            {
                WarningForm.ShowDialog();
            }
        }

        private void btnZZero_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.btnZZero.Checked)
            {
                isM21Zero = false;
                CancelZero();
            }
        }
        #endregion

        #region 右上角事件


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion

        #region 加工时间控制
        private int currentSecond;
        private int lastSecond;
        private int totalCount;
        private int totalSecond;
        private void timerCurrent_Tick(object sender, EventArgs e)
        {
            if (isM21 && isM21Zero)
            {
                currentSecond++;
                totalSecond++;
            }
        }

        private void timerTotal_Tick(object sender, EventArgs e)
        {
            this.lbTotalCount.Text = string.Format(L.R("FormMain.TotalHoles", "累计孔数:       {0}"), totalCount);
            this.lbTotalTime.Text = string.Format(L.R("FormMain.TotalTime", "运行总时间:    {0:##00}:{1:00}"), totalSecond / 60, totalSecond % 60);
            this.lbCurrentTime.Text = string.Format(L.R("FormMain.CurrentTime", "当前孔用时:    {0:00}:{1:00}"), currentSecond / 60, currentSecond % 60);
            this.lbLastTime.Text = string.Format(L.R("FormMain.LastTime", "上一孔用时:    {0:00}:{1:00}"), lastSecond / 60, lastSecond % 60);
            this.lbJiagongOvertime.Text = string.Format(L.R("FormMain.OverTime","加工超时(S):    {0}"), CurrInfo.JiaGongOverTime);
        }

        private void btnClearTotalCount_Click(object sender, EventArgs e)
        {
            this.totalCount = 0;
            this.totalSecond = 0;
            timerTotal_Tick(sender, e);
        }

        private void btnJiagongHistory_Click(object sender, EventArgs e)
        {
            var historyForm = new FormJiagongHistory(jiagongHistory);
            historyForm.ShowDialog();
        }

        private void btnTimeSet_Click(object sender, EventArgs e)
        {
            FormJiagongTimeSet formSet = new FormJiagongTimeSet(CurrInfo);
            if (formSet.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CurrInfo.JiaGongOverTime = formSet.JiaGongOverTime;
                timerTotal_Tick(null, null);
            }
        }
        #endregion

        #region 双击数字表 设置位置
        private void gaugeg_DoubleClick(object sender, MouseEventArgs e)
        {
            if (this.btnStart.Enabled)
            {
                GaugeControl control = sender as GaugeControl;

                foreach (var item in control.Gauges)
                {
                    if (item.Bounds.Contains(e.Location))
                    {
                        DigitalGauge gauge = item as DigitalGauge;
                        Binding binding = gauge.DataBindings[0];
                        var member = binding.BindingMemberInfo.BindingMember;
                        if (member.StartsWith("ActPos"))
                        {
                            Type type = this.CurrInfo.GetType();
                            System.Reflection.PropertyInfo info = type.GetProperty(member);
                            decimal value = Convert.ToDecimal(info.GetValue(this.CurrInfo, null));
                            FormSetValue form = new FormSetValue(value);
                            if (form.ShowDialog() == DialogResult.OK)
                            {
                                var tempMember = "TempLogPos" + member.Replace("ActPos", "");

                                System.Reflection.PropertyInfo tempPosInfo = type.GetProperty(tempMember);

                                decimal oldValue = Convert.ToDecimal(tempPosInfo.GetValue(this.CurrInfo, null));

                                tempPosInfo.SetValue(this.CurrInfo, oldValue - value + form.SetInfo.Value, null);
                            }
                        }
                        break;
                    }
                }
            }
        }
        #endregion

        #region 手动输入面板
        private void btnInput_ItemClick(object sender, EventArgs e)
        {
            if (this.txtInput1.EditValue != null && this.txtInput1.EditValue.ToString() != "")
            {
                this.inputInfo = BaseInfoCollection.CreateBaseInfoByString((string)this.txtInput1.EditValue);
                this.isInput = true;
            }
        }

        private void btnKeyboard_Click(object sender, EventArgs e)
        {
            if (program == null || program.HasExited)
            {
                var path = Environment.GetFolderPath(Environment.SpecialFolder.System);
                var keyboardPath = Path.Combine(path, "osk.exe");
                if (!File.Exists(keyboardPath))
                {
                    ContraHelper.ShowError(L.R("FormMain.NoKeyborad", "未找到屏幕键盘!"));
                    return;
                }
                program = Process.Start(keyboardPath);
            }
        }
        #endregion

        #region 参数控制

        private void btnAddParam_Click(object sender, EventArgs e)
        {
            var info = this.bindingSourceParam.Current as ParamInfo;
            var newInfo = new ParamInfo();
            if (info != null)
            {
                newInfo.Depth = info.Depth2;
                newInfo.Depth2 = info.Depth2;
            }
            if (this.bindingSource.Position >= 0 && this.bindingSourceParam.Position < this.bindingSourceParam.Count)
            {
                this.bindingSourceParam.Insert(this.bindingSourceParam.Position + 1, newInfo);
                this.bindingSourceParam.Position++;
            }
            else
            {
                this.bindingSourceParam.Add(newInfo);
                this.bindingSourceParam.Position = this.bindingSourceParam.Count - 1;
            }
            isChanged = true;
        }

        private void btnDeleteParam_Click(object sender, EventArgs e)
        {
            if (this.bindingSourceParam.Current != null)
            {
                this.bindingSourceParam.RemoveCurrent();
                isChanged = true;
            }
        }

        /// <summary>
        /// 控制参数表只读
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridViewParam_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            e.RepositoryItem.ReadOnly = isContinue && (e.Column.FieldName == "Depth" && e.RowHandle != 0) || (e.RowHandle == this.gridViewParam.RowCount - 1 && e.Column.FieldName != "Depth2");
        }

        private void repositoryItem_DoubleClick(object sender, EventArgs e)
        {
            var spinEdit = sender as SpinEdit;
            if (!spinEdit.Properties.ReadOnly)
            {
                FormEditParam form = new FormEditParam(spinEdit.Properties.Tag, spinEdit.EditValue, spinEdit.Properties.MinValue, spinEdit.Properties.MaxValue, IOHelper);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    spinEdit.EditValue = form.EditValue;
                }
            }
        }

        /// <summary>
        /// 画出参数表当前行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridViewParam_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (this.param == this.tabE.SelectedTabPage.Text && e.RowHandle == paramIndex)
            {
                e.Appearance.ForeColor = Color.Red;
            }
            //else
            //{
            //    e.Appearance.ForeColor = Color.Black;
            //}
        }

        /// <summary>
        /// 参数列表改变的时候改变对应的值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridViewParam_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            this.isChanged = true;
            if (this.param == this.tabE.SelectedTabPage.Text)
            {
                if (this.isM21 && paramIndex == e.RowHandle)
                {
                    if (e.Column.FieldName == "TOn")
                    {
                        IOHelper.SetTOn(Convert.ToInt32(e.Value));
                    }
                    else if (e.Column.FieldName == "TOff")
                    {
                        IOHelper.SetTOff(Convert.ToInt32(e.Value));
                    }
                    else if (e.Column.FieldName == "I")
                    {
                        IOHelper.SetI(Convert.ToInt32(e.Value));
                    }
                    else if (e.Column.FieldName == "I2")
                    {
                        IOHelper.SetI2(Convert.ToInt32(e.Value));
                    }
                    else if (e.Column.FieldName == "Speed")
                    {
                        IOHelper.SetSpeed(Convert.ToInt32(e.Value));
                    }
                    else if (e.Column.FieldName == "V")
                    {
                        IOHelper.SetV(Convert.ToInt32(e.Value));
                    }
                    else if (e.Column.FieldName == "Rotate")
                    {
                        btnAxisR.Checked = Convert.ToBoolean(e.Value);
                    }
                    else if (e.Column.FieldName == "Fanjixing")
                    {
                        btnFanjixing.Checked = Convert.ToBoolean(e.Value);
                    }
                }
                if (this.isM21 && e.Column.FieldName == "Depth")
                {
                    if (e.RowHandle == this.gridViewParam.RowCount)
                    {
                        this.backHeight = Convert.ToDecimal(e.Value);
                    }
                    else if (e.RowHandle == this.gridViewParam.RowCount - 1)
                    {
                        this.machineHeight = Convert.ToDecimal(e.Value);
                    }
                }
            }
            if (e.Column.FieldName == "Depth2")
            {
                if (e.RowHandle + 1 < this.gridViewParam.RowCount)
                {
                    try
                    {
                        var info = this.gridViewParam.GetRow(e.RowHandle + 1) as ParamInfo;
                        info.Depth = Convert.ToDecimal(e.Value);
                        this.bindingSourceParam.ResetItem(e.RowHandle + 1);
                    }
                    catch (Exception)
                    {

                    }
                }
            }
        }

        private void tabE_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (!string.Equals(e.Page.Tag, "Throw"))
            {
                e.Page.Controls.Add(this.gcParam);
                this.bindingSourceParam.DataMember = Convert.ToString(e.Page.Tag);
            }
        }
        #endregion

        #region 脚本相关
        public string fileName = string.Empty;
        //新建孔位
        private void btnNewHoles_Click(object sender, EventArgs e)
        {
            if (this.HoleCollection.Count == 0 || ContraHelper.ShowQuestion(L.R("FormMain.WillClearHole", "将会清除所有孔位，是否继续？")))
            {
                this.HoleCollection.Clear();
                this.bindingSourceCnc.ResetBindings(false);
                fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "newPnc1.pnc");
                this.gcFileName.Text = string.Format(L.R("FormMain.HoleList", "加工孔位列表({0})"), fileName);
            }
        }

        //编辑孔位
        FormHoleEdit formEdit;
        private void btnMoreOperate_Click(object sender, EventArgs e)
        {
            var list = this.bindingSourceCnc.DataSource as HoleCollection;
            formEdit = new FormHoleEdit(list, CurrInfo, this.tabShow.SelectedTabPage.Text);
            formEdit.FileName = !string.IsNullOrEmpty(fileName) ? fileName : Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "newPnc1.pnc");
            if (formEdit.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pncInfo.Holes = formEdit.HoleCollection;
                this.bindingSourceCnc.DataSource = pncInfo.Holes;
                this.gcFileName.Text = string.Format(L.R("FormMain.HoleList", "加工孔位列表({0})"), formEdit.FileName);
                fileName = formEdit.FileName;
                isChanged = true;
            }
            formEdit = null;
        }

        private PNCInfo pncInfo;
        private void LoadPnc()
        {
            pncInfo = PNCHelper.LoadPnc(setting.FilePath);
            this.bindingSourceCnc.DataSource = pncInfo.Holes;
            this.bindingSourceParam.DataSource = pncInfo.Params;
            this.bindingSourceParam.DataMember = this.tabE.SelectedTabPage.Text == L.R("FormMain.Throw", "穿透") ? L.R("FormMain.Manual", "手动") : this.tabE.SelectedTabPage.Text;
            this.bindingSourceThrowSet.DataSource = pncInfo.ThrowSet;
            fileName = setting.FilePath;
            //this.biFileName.Caption = File.Exists(setting.FilePath) ? setting.FilePath : "";
            this.gcFileName.Text = string.Format(L.R("FormMain.HoleList", "加工孔位列表{0}"), fileName == "" ? "" : "(" + fileName + ")");
            this.isChanged = false;
        }

        private void miLoadFile_ItemClick(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = ContraHelper.FilterPnc;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                setting.FilePath = dialog.FileName;
                LoadPnc();
            }
        }

        private void chkCheckAll_CheckedChanged(object sender, EventArgs e)
        {
            var list = this.bindingSourceCnc.DataSource as HoleCollection;
            if (list != null)
            {
                foreach (var item in list)
                {
                    item.IsJiaGong = chkCheckAll.Checked;
                }
                this.bindingSourceCnc.ResetBindings(false);
            }
        }

        private void btnLoadScript_Click(object sender, EventArgs e)
        {

        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            FormPckCheck checkForm = new FormPckCheck(this);
            checkForm.ShowDialog();
        }

        private bool isChangeRow = false;
        private void gridViewCnc_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (!isContinue)
            {
                currPostion = e.FocusedRowHandle;
                card.moveState = 0;
                isSingleM21 = false;
            }
            isChangeRow = true;
        }

        private void btnChooseAll_Click(object sender, EventArgs e)
        {
            var list = this.bindingSourceCnc.DataSource as HoleCollection;
            bool flag = true;
            if (list != null)
            {
                if (list.FindAll(x => x.IsJiaGong == false).Count == 0)
                    flag = false;
                foreach (var item in list)
                {
                    item.IsJiaGong = flag;
                }
                this.bindingSourceCnc.ResetBindings(false);
                this.isChanged = true;
            }
        }

        //保存脚本
        private void btnSaveScript_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = ContraHelper.FilterPnc;
            dialog.FileName = string.IsNullOrEmpty(fileName) ? "newPnc1.pnc" : fileName;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                PNCHelper.SavePnc(pncInfo, dialog.FileName);
                setting.FilePath = dialog.FileName;
                //this.biFileName.Caption = setting.FilePath;
                this.gcFileName.Text = string.Format("加工孔位列表({0})", setting.FilePath);
                isChanged = false;
            }
        }

        private void gridViewCnc_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }
        #endregion

        #region 手轮相关
        Nullable<decimal> wheelLocation;
        int wheelUse = 0;
        Nullable<decimal> resultLocation;
        bool isLastPlus = true;
        decimal wheelAddValue;
        decimal wheelStaticValue;
        int tempCount = 0;
        bool isLastPositionZero = false;
        private void timerWheel_Tick(object sender, EventArgs e)
        {
            IOHelper.ReadInputs2(); //读取信号
            int beiLv = IOHelper.GetWheelBeilv(); //获得倍率
            int choose = IOHelper.GetWheelChoose(); //获得选轴
            var axis = AxisSet.GetAxis(choose); //获得选轴
            btnWheel.Checked = choose != 0;
            btnWheel.Text = IOHelper.GetWheelText(beiLv, choose); //显示手轮按钮状态
            this.axisControl1.SetHighlightAxis(IOHelper.GetWheelChooseText(choose));
            decimal wheelLocationTemp = card.GetActPos(AxisSet.WheelReadAxis) * 1000;  //获得手轮本次读数
            if (!wheelLocation.HasValue) //不管
            {
                wheelLocation = wheelLocationTemp;
            }
            if (formMove != null)
            {
                wheelLocation = wheelLocationTemp;
            }
            //如果选轴不是0 当前不在加工 不在移轴 不是急停 不是碰撞
            if (wheelLocation.HasValue && choose != 0 && !isContinue && !btnJiagong.Checked && formMove == null && !IOHelper.IsStopButton())
            {
                //获得脉冲值
                decimal logPostion = card.GetLogPos(axis) * 1000;
                int absLocation = (int)Math.Abs((decimal)(wheelLocation.Value - wheelLocationTemp)); //
                if (choose == 3 && beiLv == 100) //如果是Z轴并且倍率是100
                    absLocation = absLocation > 50 ? 50 : absLocation; //如果脉冲大于50 按50算 否则按得到的算
                if (absLocation > 0) //代表连续移动
                {
                    isM21 = false;
                    isEndM21 = false;
                    card.moveState = 0;
                    isLastPositionZero = false;
                    wheelUse = 0;
                    if (wheelLocation < wheelLocationTemp) //代表正方向转动
                    {
                        if (isLastPlus == false) //如果之前是负方向移动 先清除缓存
                        {
                            card.OperateStopCache();
                            wheelAddValue = 0;
                            wheelStaticValue = logPostion;
                            if (choose == 3)
                            {
                                plcHelper.SendMsg(PortHelper.ZDownOff2);
                            }
                        }
                        decimal value = card.ConvertWheelSoftPlusLimit(choose, wheelStaticValue, wheelAddValue, absLocation * beiLv);
                        if ((choose == 1 && !IOHelper.IsXPlusLimit() //如果选的是X并且不是正限位
                        || (choose == 2 && !IOHelper.IsYPlusLimit())//如果选的是Y并且不是正限位
                        || (choose == 3 && !IOHelper.IsZPlusLimit())//如果选的是W并且不是正限位
                        || (choose == 4 && !IOHelper.IsWPlusLimit())//如果选的是W并且不是正限位
                        || (choose == 5 && !IOHelper.IsBPlusLimit()) || choose == 6) && !isAutoCenter)//B C不考虑限位
                        {
                            isLastPlus = true;
                            //移动脉冲*倍率位移  速度  脉冲*倍率*0.1
                            wheelAddValue += value;
                            card.OperateCache(AxisSet.GetAxis(choose), (int)value, (absLocation * beiLv * 1000 / 100));
                            if (choose == 3)
                            {
                                plcHelper.SendMsg(PortHelper.ZUpOn2);
                            }
                        }
                    }
                    else //代表负方向转动
                    {
                        isM21 = false;
                        if (isLastPlus == true)
                        {
                            card.OperateStopCache();
                            wheelAddValue = 0;
                            wheelStaticValue = logPostion;
                            //如果之前是正方向移动 先清除缓存
                            if (choose == 3)
                            {
                                plcHelper.SendMsg(PortHelper.ZUpOff2);
                            }
                        }
                        decimal value = card.ConvertWheelSoftMinusLimit(choose, wheelStaticValue, wheelAddValue, -absLocation * beiLv);
                        if ((choose == 1 && !IOHelper.IsXMinusLimit() //如果选的是X并且不是负限位
                         || (choose == 2 && !IOHelper.IsYMinusLimit())//如果选的是Y并且不是负限位
                         || (choose == 3 && !IOHelper.IsZMinusLimit())//如果选的是Z并且不是负限位
                         || (choose == 4 && !IOHelper.IsWMinusLimit())//如果选的是W并且不是负限位
                         || (choose == 5 && !IOHelper.IsBMinusLimit()) || choose == 6) && !isAutoCenter)//B C不考虑限位
                        {
                            isLastPlus = false;
                            //移动脉冲*倍率位移  速度  脉冲*倍率*0.1
                            wheelAddValue += value;
                            card.OperateCache(AxisSet.GetAxis(choose), (int)value, (absLocation * beiLv * 1000 / 100));// * ((double)absLocation / 40)
                            if (choose == 3)
                            {
                                if (!IOHelper.IsWHit())
                                {
                                    plcHelper.SendMsg(PortHelper.ZDownOn2);
                                }
                            }
                        }
                    }
                }
                else if (absLocation < 1 && !isLastPositionZero) //代表不转动
                {
                    card.OperateStopCache();
                    wheelAddValue = 0;
                    wheelStaticValue = logPostion;
                    if (choose == 3)
                    {
                        if (isLastPlus)
                        {
                            plcHelper.SendMsg(PortHelper.ZUpOff2);
                        }
                        else
                        {
                            plcHelper.SendMsg(PortHelper.ZDownOff2);
                        }
                    }
                    isLastPositionZero = true;
                }
            }
            wheelLocation = wheelLocationTemp; //把刷新脉冲
            watch.SetState(0, IOHelper.IsWheelButton1());
            watch.SetState(1, IOHelper.IsWheelButton2());
            watch.SetState(2, IOHelper.IsWheelButton3());
            watch.SetState(3, IOHelper.IsWheelButton4());
            watch.SetState(4, IOHelper.IsWheelButton5());
            watch.SetState(5, IOHelper.IsWheelButton6());
            watch.SetState(6, IOHelper.IsWheelButton7());
            this.bindingSource.ResetBindings(false);
        }

        void watch_ButtonEvent(ButtonWatchEventArgs args)
        {
            if (IOSet.ShouLunType == 2)
            {
                if (formMove == null)
                {
                    if (args.ButtonNum == 0 && args.State == 1)
                    {
                        if (formEdit == null)
                        {
                            //ContraHelper.ShowMessage("F1短按");
                            btnJiagong.Checked = true;
                            isM21FinishCloseShuibeng = true;
                        }
                    }
                    else if (args.ButtonNum == 0 && args.State == 2)
                    {
                        //ContraHelper.ShowMessage("F1长按");
                        if (this.btnStart.Enabled && formEdit == null)
                            miStart_ItemClick(null, null);
                    }
                    else if (args.ButtonNum == 1 && args.State == 1)
                    {
                        //ContraHelper.ShowMessage("F2短按");
                        if (formEdit != null)
                        {
                            formEdit.FocusedPrevious();
                        }
                        else if (this.btnStart.Enabled && currPostion > 0)
                        {
                            currPostion--;
                            this.gridViewCnc.FocusedRowHandle = currPostion;
                        }
                    }
                    else if (args.ButtonNum == 1 && args.State == 2)
                    {
                        //ContraHelper.ShowMessage("F2长按");
                        if (this.btnStart.Enabled)
                        {
                            HoleInfo hole = null;
                            if (formEdit != null)
                            {
                                hole = formEdit.GetMoveInfo();
                            }
                            else
                            {
                                if (currPostion >= this.gridViewCnc.RowCount)
                                {
                                    currPostion = this.gridViewCnc.RowCount - 1;
                                }
                                else if (currPostion < 0)
                                {
                                    currPostion = 0;
                                }
                                hole = HoleInfo;
                            }
                            if (hole != null)
                            {
                                inputInfo = new SingleMoveInfo()
                                {
                                    X = hole.X,
                                    Y = hole.Y,
                                    W = hole.W,
                                    B = hole.B,
                                    C = hole.C,
                                    AxisType = hole.AxisType ?? this.axisType
                                };
                                isInput = true;
                            }
                        }
                    }
                    else if (args.ButtonNum == 2 && args.State == 1)
                    {
                        //ContraHelper.ShowMessage("F3短按");
                        CancelZero();
                    }
                    else if (args.ButtonNum == 2 && args.State == 2)
                    {
                        //ContraHelper.ShowMessage("F3长按");
                        if (this.btnStart.Enabled && formEdit == null)
                            miRestart_ItemClick(null, null);
                    }
                    else if (args.ButtonNum == 3 && args.State == 1)
                    {
                        //ContraHelper.ShowMessage("F4短按");
                        if (this.btnStart.Enabled)
                        {
                            if (formEdit != null)
                            {
                                formEdit.FocusedNext();
                            }
                            else if (currPostion < this.gridViewCnc.RowCount)
                            {
                                currPostion++;
                                this.gridViewCnc.FocusedRowHandle = currPostion;
                            }
                        }
                    }
                    else if (args.ButtonNum == 3 && args.State == 2)
                    {
                        //ContraHelper.ShowMessage("F4长按");
                        if (this.btnStart.Enabled)
                        {
                            HoleInfo hole = null;
                            if (formEdit != null)
                            {
                                hole = formEdit.GetMoveInfo();
                            }
                            else
                            {
                                if (currPostion >= this.gridViewCnc.RowCount)
                                {
                                    currPostion = this.gridViewCnc.RowCount - 1;
                                }
                                else if (currPostion < 0)
                                {
                                    currPostion = 0;
                                }
                                hole = HoleInfo;
                            }
                            if (hole != null)
                            {
                                inputInfo = new SingleMoveInfo()
                                {
                                    X = hole.X,
                                    Y = hole.Y,
                                    W = hole.W,
                                    B = hole.B,
                                    C = hole.C,
                                    AxisType = hole.AxisType ?? this.axisType
                                };
                                isInput = true;
                            }
                        }
                    }
                    else if (args.ButtonNum == 4 && args.State == 1)
                    {
                        if (this.btnStop.Enabled)
                            StopImmediately();
                    }
                    else if (args.ButtonNum == 4 && args.State == 2)
                    {
                        //ContraHelper.ShowMessage("F5长按");
                        isContinue = false;
                        lbStopWarning.Visible = true;
                    }
                    else if (args.ButtonNum == 5 && args.State == 1)
                    {
                        //ContraHelper.ShowMessage("F6短按");
                        btnAxisR.Checked = !btnAxisR.Checked;
                    }
                    else if (args.ButtonNum == 5 && args.State == 2)
                    {
                        //ContraHelper.ShowMessage("F6长按");
                        IOHelper.SetChongShui(0);
                        IOHelper.SetJixing(0);
                        isSkipProtect = true;
                    }
                    else if (args.ButtonNum == 5 && args.State == 0)
                    {
                        //ContraHelper.ShowMessage("F6长按");
                        if (!isAutoCenter)
                            isSkipProtect = false;
                    }
                    else if (args.ButtonNum == 6 && args.State == 1)
                    {
                        //ContraHelper.ShowMessage("F7短按");
                        btnShuibang.Checked = !btnShuibang.Checked;
                    }
                    else if (args.ButtonNum == 6 && args.State == 2)
                    {
                        if (!this.btnJiagong.Checked && this.formEdit != null)
                            this.formEdit.btnAddHole_Click(null, null);
                        //ContraHelper.ShowMessage("F7长按");
                    }
                }
            }
        }
        #endregion

        #region 功能

        private void picLogo_DoubleClick(object sender, EventArgs e)
        {
            if ((System.Windows.Forms.Control.ModifierKeys & Keys.Control) == Keys.Control
                && (System.Windows.Forms.Control.ModifierKeys & Keys.Alt) == Keys.Alt)
            {
                ShowLanguageKeyValues();
            }
            else if ((System.Windows.Forms.Control.ModifierKeys & Keys.Alt) == Keys.Alt)
            {
                ShowControlType();
            }
            else
            {
                StringBuilder builder = new StringBuilder();
                builder.AppendLine(card.GetVersion());
                builder.AppendLine(card.GetHardwareVersion());
                builder.AppendFormat("剩余天数:{0}", Register.GetLeftDays());
                ContraHelper.ShowMessage(builder.ToString());
            }
        }

        private void btnProgram_Click(object sender, EventArgs e)
        {
            this.pnlProgram.Visible = true;
        }

        private void btnHelper_Click(object sender, EventArgs e)
        {
            ContraHelper.ShowMessage(L.R("FormMain.Contact", "请联系中谷!"));
        }

        private void btnManual_Click(object sender, EventArgs e)
        {
            this.pnlProgram.Visible = false;
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            FrmInputPassword passwordFrm = new FrmInputPassword();
            if (passwordFrm.ShowDialog() == DialogResult.OK)
            {
                FrmSet setForm = new FrmSet(setting.Set, card, _232Helper);
                if (setForm.ShowDialog() == DialogResult.OK)
                {
                    if (setForm.IsNeedZeroB)
                        card.SetLogPos(AxisSet.AxisB, 0);
                    if (setForm.IsNeedZeroC)
                        card.SetLogPos(AxisSet.AxisC, 0);
                    setting.Set = setForm.SetInfo;
                    IOHelper = new IOHelper(card, setting.Set.IOSet, setting.Set.AxisSet, setting.Set.AbsolutePosSet, plcHelper, _232Helper, this);
                    RefreshButton();
                    this.axisControl1.SetVisible(AxisSet);
                }
            }
        }

        private void btnShutdown_Click(object sender, EventArgs e)
        {
            if (isChanged && ContraHelper.ShowQuestion(L.R("FormMain.ScriptNotSave", "加工孔位或加工参数还未保存,是否要保存？")))
            {
                btnSaveScript_Click(null, null);
            }
            if (ContraHelper.ShowQuestion(L.R("FormMain.ReallyShutdown", "您真的想关机吗?")))
            {
                Process.Start("shutdown", "-s -t 0");
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.ControlKey)
            {
                isCtrlDown = true;
            }
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            if (e.KeyCode == Keys.ControlKey)
            {
                isCtrlDown = false;
            }
            switch (e.KeyCode)
            {
                case Keys.F1: this.btnHelper_Click(this.btnHelper, null); break;
                case Keys.F2: this.btnManual_Click(this.btnManual, null); break;
                case Keys.F3: this.btnProgram_Click(this.btnProgram, null); break;
                case Keys.F4: this.btnShuibang.Checked = !this.btnShuibang.Checked; break;
                case Keys.F5: this.btnJiagong.Checked = !this.btnJiagong.Checked;
                    isM21FinishCloseShuibeng = true;
                    break;
                case Keys.F6: this.btnShineng.Checked = !this.btnShineng.Checked; break;
                case Keys.F7: this.btnSet_Click(this.btnSet, null); break;
                case Keys.F8: this.btnShutdown_Click(this.btnShutdown, null); break;
                case Keys.F9: this.miStart_ItemClick(this.btnStart, null); break;
                case Keys.F10: this.miStop_ItemClick(this.btnStop, null); break;
                case Keys.F11: this.miRestart_ItemClick(this.btnReset, null); break;
                case Keys.F12: this.miNext_Click(this.btnNext, null); break;
            }
        }
        #endregion

        private void btnJiagong_MouseUp(object sender, MouseEventArgs e)
        {
            isM21FinishCloseShuibeng = true;
        }

        private void btnJiagong_MouseDown(object sender, MouseEventArgs e)
        {
            isM21FinishCloseShuibeng = true;
        }

        private void btnFushi_Click(object sender, EventArgs e)
        {
            int value = 0;
            switch (this.btnFushi.Value)
            {
                case 0:
                    if (this.btnJiagong.Checked)
                    {
                        plcHelper.SendMsg(PortHelper.FushiOff);
                    }
                    value = 2;
                    break;
                case 1: value = 2; break;
                case 2:
                    if (this.btnJiagong.Checked
                        && CurrInfo.LogPosZ >= OtherSet.FusiLocation + 10)
                    {
                        plcHelper.SendMsg(PortHelper.FushiOn);
                        value = 0;
                    }
                    else
                    {
                        value = 1;
                    }
                    break;
            }
            this.btnFushi.Value = value;
            AxisSet.UseFushi = value;
        }

        private void btnMen_Click(object sender, EventArgs e)
        {
            if (this.btnMen.Value == 2 && this.btnJiagong.Checked) //绿色并且在加工状态下
            {
                this.btnMen.Value = 0; //变成红色
                IOHelper.SetMen(1);
            }
            else if (this.btnMen.Value == 2 && !this.btnJiagong.Checked) //绿色变成黄色
            {
                this.btnMen.Value = 1;//黄色
            }
            else if (this.btnMen.Value == 0) //加工状态下红色
            {
                this.btnMen.Value = 2;
                IOHelper.SetMen(0);
            }
            else if (this.btnMen.Value == 1 && !this.btnJiagong.Checked) //非加工状态下黄色
            {
                this.btnMen.Value = 2;//变成绿色
            }
            AxisSet.UseMen = btnMen.Value;
        }

        private void gridViewCnc_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            isChanged = true;
        }

        private void txtThrowStartHeight_EditValueChanged(object sender, EventArgs e)
        {
            var textEdit = sender as TextEdit;
            isChanged = isChanged || !object.Equals(textEdit.EditValue, ThrowSet.ThrowStartHeight);
        }

        private void cmbThrowResponse_EditValueChanged(object sender, EventArgs e)
        {
            var textEdit = sender as TextEdit;
            isChanged = isChanged || !object.Equals(textEdit.EditValue, ThrowSet.ThrowResponse);
        }

        private void txtThrowLeft_EditValueChanged(object sender, EventArgs e)
        {
            var textEdit = sender as TextEdit;
            isChanged = isChanged || !object.Equals(textEdit.EditValue, ThrowSet.ThrowLeft);
        }

        private void txtThrowStartHeight2_EditValueChanged(object sender, EventArgs e)
        {
            var textEdit = sender as TextEdit;
            isChanged = isChanged || !object.Equals(textEdit.EditValue, ThrowSet.ThrowStartHeight2);
        }

        private void txtThrowLeft2_EditValueChanged(object sender, EventArgs e)
        {
            var textEdit = sender as TextEdit;
            isChanged = isChanged || !object.Equals(textEdit.EditValue, ThrowSet.ThrowLeft2);
        }

        private void cmbThrowResponse2_EditValueChanged(object sender, EventArgs e)
        {
            var textEdit = sender as TextEdit;
            isChanged = isChanged || !object.Equals(textEdit.EditValue, ThrowSet.ThrowResponse2);
        }

        private void rgThrowMode_EditValueChanged(object sender, EventArgs e)
        {
            var radioGroup = sender as RadioGroup;
            if (radioGroup.SelectedIndex >= 0)
            {
                var value = radioGroup.Properties.Items[radioGroup.SelectedIndex].Value;
                isChanged = isChanged || !object.Equals(ThrowSet.ThrowMode, value);
            }
        }

        private void btnAutoCenter_Click(object sender, EventArgs e)
        {
            isAutoCenter = true;
            centerType = 0;
            this.listBoxControl1.Items.Clear();
        }

        private void btnStopCenter_Click(object sender, EventArgs e)
        {
            centerType = 10;
        }

        private void txtInput1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnInput_ItemClick(sender, e);
            }
        }

        private void btnSpeed_CheckedChanged(object sender, EventArgs e)
        {
            this.btnSpeed.Text = btnSpeed.Checked ? L.R("FormMain.HighSpeed", "高速") : L.R("FormMain.LowSpeed", "低速");
            AxisSet.UseHighSpeed = this.btnSpeed.Checked;
            card.SetupSpeed();
        }

        bool outCheckWarninged = false;
        //检查 控制卡是否断开连接
        private void timerPlcCheck_Tick(object sender, EventArgs e)
        {
            if (!outCheckWarninged && !card.GetOutCheck())
            {
                outCheckWarninged = true;
                ContraHelper.ShowMessage(L.R("FormMain.CardDisconnect", "控制卡已断开连接,点确定后将会关闭系统"));
                Application.Exit();
            }
        }

        int plcCheckState = 0;
        //检查软件是否死机
        private void timerPlcCheck2_Tick(object sender, EventArgs e)
        {
            if (IOHelper.IsShifuStart())
            {
                plcHelper.SendMsg(PortHelper.PortCheck + plcCheckState.ToString());
                plcCheckState = plcCheckState == 0 ? 1 : 0;
            }
        }

        private void btnChangeDaoXiang_CheckedChanged(object sender, EventArgs e)
        {
            plcHelper.SendMsg(this.btnChangeDaoXiang.Checked ? PortHelper.ChangeDaoXiangOn : PortHelper.ChangeDaoXiangOff);
        }

        public void ChangeDaoMove(bool isChangeDao)
        {
            inputInfo = new SingleMoveInfo()
            {
                X = OtherSet.DaoXSafeHeight + CurrInfo.GetActPosX(axisType) - CurrInfo.LogPosX,
                Y = OtherSet.DaoYSafeHeight + CurrInfo.GetActPosY(axisType) - CurrInfo.LogPosY,
                W = OtherSet.DaoWSafeHeight + CurrInfo.GetActPosW(axisType) - CurrInfo.LogPosW,
                A = 0 + CurrInfo.GetActPosZ(axisType) - CurrInfo.LogPosZ,
                AxisType = this.axisType
            };
            plcHelper.SendMsg(PortHelper.ZUpOn);
            card.moveState = 0;
            isInput = true;
            isChangeDaoMove = true;
            this.isChangeDao = isChangeDao;
            isChangeDaoCheckFailureHeight = false;
        }

        private void timerReg_Tick(object sender, EventArgs e)
        {
            try
            {
                var lastCaclRegDateTime = Settings.Default.LastCaclRegDate;
                Register.CheckDaysValid(lastCaclRegDateTime);
                Settings.Default.LastCaclRegDate = DateTime.Today;
            }
            catch (Exception ex)
            {
                timerReg.Enabled = false;
                ContraHelper.ShowMessage(ex.Message);
                Application.Exit();
            }
        }

        private void timerCOrigin_Tick(object sender, EventArgs e)
        {
            //检查C零位信号
            CheckCZero();
            //检查C原点信号
            CheckCOrigin();
        }

        private void axisControl1_ActualDoubleClick(object sender, EventArgs e)
        {
            if (this.btnStart.Enabled)
            {
                AxisItem control = sender as AxisItem;
                Binding binding = control.DataBindings[1];
                var member = binding.BindingMemberInfo.BindingMember;
                Type type = this.CurrInfo.GetType();
                System.Reflection.PropertyInfo info = type.GetProperty(member);
                decimal value = Convert.ToDecimal(info.GetValue(this.CurrInfo, null));
                FormSetValue form = new FormSetValue(value);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var tempMember = "TempLogPos" + member.Replace("ActPos", "");

                    System.Reflection.PropertyInfo tempPosInfo = type.GetProperty(tempMember);

                    decimal oldValue = Convert.ToDecimal(tempPosInfo.GetValue(this.CurrInfo, null));

                    tempPosInfo.SetValue(this.CurrInfo, oldValue - value + form.SetInfo.Value, null);
                }
            }
        }

    }
}
