using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ContraLibrary;

namespace Contra
{
    public partial class FormMove : FormBase
    {
        CardHelper helper;
        ButtonWatch watch;
        FormMain formMain;
        public FormMove(CardHelper helper, FormMain formMain)
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.formMain = formMain;
            this.watch = new ButtonWatch();
            this.watch.WatchButtons = 1;
            this.watch.ButtonEvent += new Action<ButtonWatchEventArgs>(watch_ButtonEvent);
            this.helper = helper;
            this.bindingSource.DataSource = helper.Contra;

            this.btnXPlus.Enabled = !helper.AxisSet.IgnoreX;
            this.btnXMinus.Enabled = !helper.AxisSet.IgnoreX;
            this.btnYPlus.Enabled = !helper.AxisSet.IgnoreY;
            this.btnYMinus.Enabled = !helper.AxisSet.IgnoreY;
            this.btnWMinus.Enabled = !helper.AxisSet.IgnoreW;
            this.btnWPlus.Enabled = !helper.AxisSet.IgnoreW;
            this.btnAPlus.Enabled = !helper.AxisSet.IgnoreZ;
            this.btnAMinus.Enabled = !helper.AxisSet.IgnoreZ;
            this.btnCPlus.Enabled = !helper.AxisSet.IgnoreC;
            this.btnCMinus.Enabled = !helper.AxisSet.IgnoreC;
            this.btnBPlus.Enabled = !helper.AxisSet.IgnoreB;
            this.btnBMinus.Enabled = !helper.AxisSet.IgnoreB;
        }

        void watch_ButtonEvent(ButtonWatchEventArgs obj)
        {
            if (obj.State == 2)  //Ctrl 长按
            {
                formMain.isSkipProtect = true;
                helper.IOHelper.SetChongShui(0);
                helper.IOHelper.SetJixing(0);
            }
            else if (obj.State == 0)
            {
                formMain.isSkipProtect = false;
            }
        }

        private bool isCtrlDown = false;
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
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            if (this.watch != null)
                this.watch.Stop();
        }

        #region 单轴移动
        private void btn_MouseUp(object sender, MouseEventArgs e)
        {
            helper.OperateStopRun();
        }

        #region X轴移动
        private void btnXPlus_MouseDown(object sender, MouseEventArgs e)
        {
            helper.OperatePlus(helper.AxisSet.AxisX);
        }

        private void btnXMinus_MouseDown(object sender, MouseEventArgs e)
        {
            helper.OperateMinus(helper.AxisSet.AxisX);
        }
        #endregion

        #region Y轴移动
        private void btnYPlus_MouseDown(object sender, MouseEventArgs e)
        {
            helper.OperatePlus(helper.AxisSet.AxisY);
        }

        private void btnYMinus_MouseDown(object sender, MouseEventArgs e)
        {
            helper.OperateMinus(helper.AxisSet.AxisY);
        }
        #endregion

        #region W轴移动
        private void btnWPlus_MouseDown(object sender, MouseEventArgs e)
        {
            helper.OperatePlus(helper.AxisSet.AxisW);
        }

        private void btnWMinus_MouseDown(object sender, MouseEventArgs e)
        {
            helper.OperateMinus(helper.AxisSet.AxisW);
        }
        #endregion

        #region Z轴移动
        private void btnAPlus_MouseDown(object sender, MouseEventArgs e)
        {
            helper.OperatePlus(helper.AxisSet.AxisZ);
            formMain.PlcHelpr.SendMsg(PortHelper.ZUpOn);
        }

        private void btnAMinus_MouseDown(object sender, MouseEventArgs e)
        {
            //没有在负限位，并且没有在短路碰撞的条件下
            if (!formMain.IOHelper.IsZMinusLimit()
                && !formMain.IOHelper.IsWHit())
            {
                helper.OperateMinus(helper.AxisSet.AxisZ);
                formMain.PlcHelpr.SendMsg(PortHelper.ZDownOn);
            }
        }

        private void btnAPlus_MouseUp(object sender, MouseEventArgs e)
        {
            helper.OperateStopRun();
            formMain.PlcHelpr.SendMsg(PortHelper.ZUpOff);
        }

        private void btnAMinus_MouseUp(object sender, MouseEventArgs e)
        {
            helper.OperateStopRun();
            formMain.PlcHelpr.SendMsg(PortHelper.ZDownOff);
        }
        #endregion

        #region B轴移动
        private void btnBPlus_MouseDown(object sender, MouseEventArgs e)
        {
            helper.OperatePlus(helper.AxisSet.AxisB);
        }

        private void btnBMinus_MouseDown(object sender, MouseEventArgs e)
        {
            helper.OperateMinus(helper.AxisSet.AxisB);
        }
        #endregion

        #region C轴移动
        private void btnCPlus_MouseDown(object sender, MouseEventArgs e)
        {
            helper.OperatePlus(helper.AxisSet.AxisC);
        }

        private void btnCMinus_MouseDown(object sender, MouseEventArgs e)
        {
            helper.OperateMinus(helper.AxisSet.AxisC);
        }
        #endregion

        private void timer_Tick(object sender, EventArgs e)
        {
            watch.SetState(0, isCtrlDown);
        }
        #endregion


    }
}
