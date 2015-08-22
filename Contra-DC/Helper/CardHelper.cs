using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contra.Properties;
using ContraLibrary;

namespace Contra
{
    public class CardHelper
    {
        private FormMain form;
        private bool isG90 = true;
        public CardHelper(FormMain form)
        {
            this.form = form;
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

        public IOHelper IOHelper
        {
            get { return form.IOHelper; }
        }

        public ContraInfo Contra
        {
            get { return form.CurrInfo; }
        }

        private CCtrlCard ctrlCard;
        public CCtrlCard CtrlCard
        {
            get
            {
                if (ctrlCard == null)
                    ctrlCard = new CCtrlCard();
                return ctrlCard;
            }
        }

        #region 初始化
        public void InitBoard()
        {
            int i = CtrlCard.Init_Board();
            if (i <= 0)
            {
                ContraHelper.ShowError(L.R("CardHelper.InitFailure", "控制卡初始化失败!"));
                if (i == 0)
                {
                    ContraHelper.ShowError(L.R("Cardhelper.NotInstallCard", "没有安装ADT8940A1卡!"));
                }
                if (i == -1)
                {
                    ContraHelper.ShowError(L.R("CardHelper.NotDrive", "没有安装端口驱动程序!"));
                }
                if (i == -2)
                {
                    ContraHelper.ShowError(L.R("CardHelper.PCIError", "PCI桥故障!"));
                }
            }
            SetByRecord();
            SetupSpeed();
            SetIOMode();
            SetLimitMode();
            SetupHardStop();
            this.Setup_LockPosition();
        }

        private void SetupHardStop()
        {
            CtrlCard.Setup_HardStop(1, 0);
        }

        private void SetByRecord()
        {
            if (!AxisSet.IgnoreX) CtrlCard.Setup_Pos(AxisSet.AxisX, (int)(Contra.LogPosX * 1000 / AxisSet.XResolution), 0);
            if (!AxisSet.IgnoreY) CtrlCard.Setup_Pos(AxisSet.AxisY, (int)(Contra.LogPosY * 1000 / AxisSet.YResolution), 0);
            if (!AxisSet.IgnoreW) CtrlCard.Setup_Pos(AxisSet.AxisW, (int)(Contra.LogPosW * 1000 / AxisSet.WResolution), 0);
            if (!AxisSet.IgnoreZ) CtrlCard.Setup_Pos(AxisSet.AxisZ, (int)(Contra.LogPosA * 1000 / AxisSet.AResolution), 0);
            if (!AxisSet.IgnoreB) CtrlCard.Setup_Pos(AxisSet.AxisB, (int)(Contra.LogPosB * 1000 / AxisSet.BResolution), 0);
            if (!AxisSet.IgnoreC) CtrlCard.Setup_Pos(AxisSet.AxisC, (int)(Contra.LogPosC * 1000 / AxisSet.CResolution), 0);
            CtrlCard.Setup_Pos(AxisSet.ZReadAxis, AxisSet.ZResolution == 0 ? 0 : (int)(Contra.LogPosZ * 1000 / AxisSet.ZResolution), 1);
        }

        public void SetupSpeed()
        {
            if (!AxisSet.IgnoreX) CtrlCard.Setup_Speed(AxisSet.AxisX, (int)AxisSet.SpeedXPerSecond, (int)AxisSet.SpeedXPerSecond, Contra.AddSpeed);
            if (!AxisSet.IgnoreY) CtrlCard.Setup_Speed(AxisSet.AxisY, (int)AxisSet.SpeedYPerSecond, (int)AxisSet.SpeedYPerSecond, Contra.AddSpeed);
            if (!AxisSet.IgnoreW) CtrlCard.Setup_Speed(AxisSet.AxisW, (int)AxisSet.SpeedWPerSecond, (int)AxisSet.SpeedWPerSecond, Contra.AddSpeed);
            if (!AxisSet.IgnoreZ) CtrlCard.Setup_Speed(AxisSet.AxisZ, Contra.StartSpeed, Contra.StartSpeed, Contra.AddSpeed);
            if (!AxisSet.IgnoreB) CtrlCard.Setup_Speed(AxisSet.AxisB, (int)AxisSet.SpeedBPerSecond, (int)AxisSet.SpeedBPerSecond, Contra.AddSpeed);
            if (!AxisSet.IgnoreC) CtrlCard.Setup_Speed(AxisSet.AxisC, (int)AxisSet.SpeedCPerSecond, (int)AxisSet.SpeedCPerSecond, Contra.AddSpeed);
        }

        private void SetIOMode()
        {
            CtrlCard.SetIOMmode(0, 1);
        }

        private void SetLimitMode()
        {
            //CtrlCard.Setup_LimitMode(5, 1, 1, 1);
            CtrlCard.Setup_LimitMode(6, 1, 1, 1);
        }

        public string GetVersion()
        {
            float libVer = CtrlCard.Get_Version();
            return string.Format(L.R("CardHelper.LibVersion", "库版本号:{0}"), libVer.ToString("0.0#"));
        }

        public string GetHardwareVersion()
        {
            float hardwareVer = CtrlCard.Get_HardwareVersion();
            return string.Format(L.R("CardHelper.HardwareVersion", "硬件版本号:{0}"), hardwareVer.ToString("0.0#"));
        }
        #endregion

        #region 逻辑值和实际值
        public decimal GetLogPos(int axis)
        {
            return ((decimal)CtrlCard.Get_LogPos(axis)) / 1000;
        }

        public decimal GetActPos(int axis)
        {
            return ((decimal)CtrlCard.Get_ActPos(axis)) / 1000;
        }

        public void SetLogPos(int axis, int position)
        {
            CtrlCard.Setup_Pos(axis, position, 0);
        }

        public void SetActPos(int axis, int position)
        {
            CtrlCard.Setup_Pos(axis, position, 1);
        }
        #endregion

        #region 获得状态
        public bool IsMove(int axis)
        {
            return CtrlCard.Get_Status(axis, 0) != 0;
        }
        #endregion

        #region 输入输出点控制
        private int GetOutPut(int number)
        {
            return CtrlCard.Get_OutNum(number);
        }
        /// <summary>
        /// 获取输出点的选中状态
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public bool GetOutPutState(int number)
        {
            return GetOutPut(number) == 1;
        }
        /// <summary>
        /// 设置输出点状态
        /// </summary>
        public void SetOutPut(int number, int value)
        {
            CtrlCard.Write_Output(number, value);
        }

        private int GetInput(int number)
        {
            return CtrlCard.Read_Input(number);
        }
        /// <summary>
        /// 获取输入点的选中状态
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public bool GetInputState(int number)
        {
            return GetInput(number) == 0;
        }
        #endregion

        #region 绝对坐标系，相对坐标系转换
        public void SetAbsolute()
        {
            isG90 = true;
        }

        public void SetRelative()
        {
            isG90 = false;
        }
        #endregion

        #region 运动控制
        private decimal jianxiX;
        private decimal jianxiY;
        private decimal jianxiW;
        private decimal jianxiA;
        private decimal jianxiB;
        private decimal jianxiC;
        private bool isOldXPlus = true;
        private bool isOldYPlus = true;
        private bool isOldWPlus = true;
        private bool isOldAPlus = true;
        private bool isOldBPlus = true;
        private bool isOldCPlus = true;
        private bool isXPlus = true;
        private bool isYPlus = true;
        private bool isWPlus = true;
        private bool isAPlus = true;
        private bool isBPlus = true;
        private bool isCPlus = true;

        public int moveState = 0;
        public void SingleMove(HoleInfo moveInfo, string axisType)
        {
            decimal actPosW = Contra.GetActPosW(axisType);
            decimal moveToW = moveInfo.W ?? actPosW;

            if (moveState == 0 && actPosW < moveToW)
            {
                isWPlus = moveInfo.W.Value >= actPosW;
                CtrlCard.Sym_AbsoluteMove(AxisSet.AxisW,
                GetMovePosition("W", moveInfo.W, actPosW, Contra.LogPosW, isWPlus != isOldWPlus, isOldWPlus, out jianxiW),
                Contra.StartSpeed, (int)AxisSet.SpeedWPerSecond, (double)Contra.AddSpeedTime);
                isOldWPlus = isWPlus;
                moveState = 1;
            }
            else if (moveState == 1 || (!moveInfo.W.HasValue && moveState != 2) || (moveInfo.W.HasValue && actPosW >= moveToW && moveState != 2))
            {
                if (moveInfo.X.HasValue)
                {
                    decimal actPosX = Contra.GetActPosX(axisType);
                    isXPlus = moveInfo.X.Value >= actPosX;
                    CtrlCard.Sym_AbsoluteMove(AxisSet.AxisX,
                    GetMovePosition("X", moveInfo.X, actPosX, Contra.LogPosX, isXPlus != isOldXPlus, isOldXPlus, out jianxiX),
                    Contra.StartSpeed, (int)AxisSet.SpeedXPerSecond, (double)Contra.AddSpeedTime);
                    isOldXPlus = isXPlus;
                }
                if (moveInfo.Y.HasValue)
                {
                    decimal actPosY = Contra.GetActPosY(axisType);
                    isYPlus = moveInfo.Y.Value >= actPosY;
                    CtrlCard.Sym_AbsoluteMove(AxisSet.AxisY,
                    GetMovePosition("Y", moveInfo.Y, actPosY, Contra.LogPosY, isYPlus != isOldYPlus, isOldYPlus, out jianxiY),
                    Contra.StartSpeed, (int)AxisSet.SpeedYPerSecond, (double)Contra.AddSpeedTime);
                    isOldYPlus = isYPlus;
                }
                if (moveInfo.Z.HasValue)
                {
                    Contra.LogPosZ = GetActPos(AxisSet.ZReadAxis) * AxisSet.ZResolution;
                    Contra.LogPosA = GetLogPos(AxisSet.AxisZ);
                    Contra.TempLogPosA = Contra.LogPosZ + Contra.TempLogPosZ - Contra.LogPosA;
                    Contra.TempLogPosA55 = Contra.LogPosZ + Contra.TempLogPosZ55 - Contra.LogPosA;
                    Contra.TempLogPosA56 = Contra.LogPosZ + Contra.TempLogPosZ56 - Contra.LogPosA;
                    Contra.TempLogPosA57 = Contra.LogPosZ + Contra.TempLogPosZ57 - Contra.LogPosA;
                    Contra.TempLogPosA58 = Contra.LogPosZ + Contra.TempLogPosZ58 - Contra.LogPosA;
                    Contra.TempLogPosA59 = Contra.LogPosZ + Contra.TempLogPosZ59 - Contra.LogPosA;

                    Contra.TempLogPosA60 = Contra.LogPosZ + Contra.TempLogPosZ60 - Contra.LogPosA;
                    Contra.TempLogPosA61 = Contra.LogPosZ + Contra.TempLogPosZ61 - Contra.LogPosA;
                    Contra.TempLogPosA62 = Contra.LogPosZ + Contra.TempLogPosZ62 - Contra.LogPosA;
                    Contra.TempLogPosA63 = Contra.LogPosZ + Contra.TempLogPosZ63 - Contra.LogPosA;
                    Contra.TempLogPosA64 = Contra.LogPosZ + Contra.TempLogPosZ64 - Contra.LogPosA;
                    Contra.TempLogPosA65 = Contra.LogPosZ + Contra.TempLogPosZ65 - Contra.LogPosA;


                    decimal actPosA = Contra.GetActPosZ(axisType);
                    isAPlus = moveInfo.Z.Value >= actPosA;
                    CtrlCard.Sym_AbsoluteMove(AxisSet.AxisZ,
                    GetMovePosition("Z", moveInfo.Z, actPosA, Contra.LogPosA, isAPlus != isOldAPlus, isOldAPlus, out jianxiA),
                    Contra.StartSpeed, (int)AxisSet.SpeedZPerSecond, (double)Contra.AddSpeedTime);
                    isOldAPlus = isAPlus;
                }
                if (moveInfo.B.HasValue)
                {
                    decimal actPosB = Contra.GetActPosB(axisType);
                    isBPlus = moveInfo.B.Value >= actPosB;
                    CtrlCard.Sym_AbsoluteMove(AxisSet.AxisB,
                    GetMovePosition("B", moveInfo.B, actPosB, Contra.LogPosB, isBPlus != isOldBPlus, isOldBPlus, out jianxiB),
                    Contra.StartSpeed, (int)AxisSet.SpeedBPerSecond, (double)Contra.AddSpeedTime);
                    isOldBPlus = isBPlus;
                }
                if (moveInfo.C.HasValue)
                {
                    decimal actPosC = Contra.GetActPosC(axisType);
                    isCPlus = moveInfo.C.Value >= actPosC;
                    CtrlCard.Sym_AbsoluteMove(AxisSet.AxisC,
                    GetMovePosition("C", moveInfo.C, actPosC, Contra.LogPosC, isCPlus != isOldCPlus, isOldCPlus, out jianxiC),
                    Contra.StartSpeed, (int)AxisSet.SpeedCPerSecond, (double)Contra.AddSpeedTime);
                    isOldCPlus = isCPlus;
                }
                moveState = (!moveInfo.W.HasValue || actPosW >= moveToW) ? 2 : 0;
            }
            else if (moveState == 2 && actPosW >= moveToW)
            {
                if (moveInfo.W.HasValue)
                {
                    isWPlus = moveInfo.W.Value >= actPosW;
                    CtrlCard.Sym_AbsoluteMove(AxisSet.AxisW,
                    GetMovePosition("W", moveInfo.W, actPosW, Contra.LogPosW, isWPlus != isOldWPlus, isOldWPlus, out jianxiW),
                    Contra.StartSpeed, (int)AxisSet.SpeedWPerSecond, (double)Contra.AddSpeedTime);
                    isOldWPlus = isWPlus;
                }
                moveState = 0;
            }
        }

        public void SingleMoveX(HoleInfo moveInfo, string axisType)
        {
            if (moveInfo.X.HasValue)
            {
                decimal actPosX = Contra.GetActPosX(axisType);
                isXPlus = moveInfo.X.Value >= actPosX;
                CtrlCard.Sym_AbsoluteMove(AxisSet.AxisX,
                GetMovePosition("X", moveInfo.X, actPosX, Contra.LogPosX, isXPlus != isOldXPlus, isOldXPlus, out jianxiX),
                Contra.StartSpeed, (int)AxisSet.SpeedXPerSecond, (double)Contra.AddSpeedTime);
                isOldXPlus = isXPlus;
            }
        }

        public void SingleMoveY(HoleInfo moveInfo, string axisType)
        {
            if (moveInfo.Y.HasValue)
            {
                decimal actPosY = Contra.GetActPosY(axisType);
                isYPlus = moveInfo.Y.Value >= actPosY;
                CtrlCard.Sym_AbsoluteMove(AxisSet.AxisY,
                GetMovePosition("Y", moveInfo.Y, actPosY, Contra.LogPosY, isYPlus != isOldYPlus, isOldYPlus, out jianxiY),
                Contra.StartSpeed, (int)AxisSet.SpeedYPerSecond, (double)Contra.AddSpeedTime);
                isOldYPlus = isYPlus;
            }
        }

        public void SingleMoveW(HoleInfo moveInfo, string axisType)
        {
            if (moveInfo.W.HasValue)
            {
                decimal actPosW = Contra.GetActPosW(axisType);
                isWPlus = moveInfo.W.Value >= actPosW;
                CtrlCard.Sym_AbsoluteMove(AxisSet.AxisW,
                GetMovePosition("W", moveInfo.W, actPosW, Contra.LogPosW, isWPlus != isOldWPlus, isOldWPlus, out jianxiW),
                Contra.StartSpeed, (int)AxisSet.SpeedWPerSecond, (double)Contra.AddSpeedTime);
                isOldWPlus = isWPlus;
            }
        }

        public void SingleMoveZ(HoleInfo moveInfo, string axisType, decimal speed = 0)
        {
            if (moveInfo.Z.HasValue)
            {
                Contra.LogPosZ = GetActPos(AxisSet.ZReadAxis) * AxisSet.ZResolution;
                Contra.LogPosA = GetLogPos(AxisSet.AxisZ);
                Contra.TempLogPosA = Contra.LogPosZ + Contra.TempLogPosZ - Contra.LogPosA;
                Contra.TempLogPosA55 = Contra.LogPosZ + Contra.TempLogPosZ55 - Contra.LogPosA;
                Contra.TempLogPosA56 = Contra.LogPosZ + Contra.TempLogPosZ56 - Contra.LogPosA;
                Contra.TempLogPosA57 = Contra.LogPosZ + Contra.TempLogPosZ57 - Contra.LogPosA;
                Contra.TempLogPosA58 = Contra.LogPosZ + Contra.TempLogPosZ58 - Contra.LogPosA;
                Contra.TempLogPosA59 = Contra.LogPosZ + Contra.TempLogPosZ59 - Contra.LogPosA;

                Contra.TempLogPosA60 = Contra.LogPosZ + Contra.TempLogPosZ60 - Contra.LogPosA;
                Contra.TempLogPosA61 = Contra.LogPosZ + Contra.TempLogPosZ61 - Contra.LogPosA;
                Contra.TempLogPosA62 = Contra.LogPosZ + Contra.TempLogPosZ62 - Contra.LogPosA;
                Contra.TempLogPosA63 = Contra.LogPosZ + Contra.TempLogPosZ63 - Contra.LogPosA;
                Contra.TempLogPosA64 = Contra.LogPosZ + Contra.TempLogPosZ64 - Contra.LogPosA;
                Contra.TempLogPosA65 = Contra.LogPosZ + Contra.TempLogPosZ65 - Contra.LogPosA;

                decimal actPosA = Contra.GetActPosZ(axisType);
                var v = GetMovePosition("Z", moveInfo.Z, actPosA, Contra.LogPosA, isAPlus != isOldAPlus, isOldAPlus, out jianxiA);
                isAPlus = moveInfo.Z.Value >= actPosA;
                CtrlCard.Sym_AbsoluteMove(AxisSet.AxisZ,
                v,
                Contra.StartSpeed, (int)(speed == 0 ? AxisSet.SpeedZPerSecond : speed), (double)Contra.AddSpeedTime);
                isOldAPlus = isAPlus;
            }
        }

        public void SingleMoveB(HoleInfo moveInfo, string axisType)
        {
            if (moveInfo.B.HasValue)
            {
                decimal actPosB = Contra.GetActPosB(axisType);
                isBPlus = moveInfo.B.Value >= actPosB;
                CtrlCard.Sym_AbsoluteMove(AxisSet.AxisB,
                GetMovePosition("B", moveInfo.B, actPosB, Contra.LogPosB, isBPlus != isOldBPlus, isOldBPlus, out jianxiB),
                Contra.StartSpeed, (int)AxisSet.SpeedBPerSecond, (double)Contra.AddSpeedTime);
                isOldBPlus = isBPlus;
            }
        }

        public void SingleMoveC(HoleInfo moveInfo, string axisType, int? speed)
        {
            if (moveInfo.C.HasValue)
            {
                decimal actPosC = Contra.GetActPosC(axisType);
                isCPlus = moveInfo.C.Value >= actPosC;
                CtrlCard.Sym_AbsoluteMove(AxisSet.AxisC,
                GetMovePosition("C", moveInfo.C, actPosC, Contra.LogPosC, isCPlus != isOldCPlus, isOldCPlus, out jianxiC),
                Contra.StartSpeed, speed ?? (int)AxisSet.SpeedCPerSecond, (double)Contra.AddSpeedTime);
                isOldCPlus = isCPlus;
            }
        }

        public void UnionMove(UnionMoveInfo moveInfo, string axisType)
        {
            if (moveInfo.X.HasValue && moveInfo.Y.HasValue)
            {
                decimal actPosX = Contra.GetActPosX(axisType);
                isXPlus = moveInfo.X.Value >= actPosX;
                decimal actPosY = Contra.GetActPosY(axisType);
                isYPlus = moveInfo.Y.Value >= actPosY;
                CtrlCard.Sym_AbsoluteLine2(AxisSet.AxisX, AxisSet.AxisY,
                GetMovePosition("X", moveInfo.X, actPosX, Contra.LogPosX, isXPlus != isOldXPlus, isOldXPlus, out jianxiX),
                GetMovePosition("Y", moveInfo.Y, actPosY, Contra.LogPosY, isYPlus != isOldYPlus, isOldYPlus, out jianxiY),
                Contra.StartSpeed,
                (int)AxisSet.SpeedXPerSecond,
                Contra.AddSpeedTime);
                isOldXPlus = isXPlus;
                isOldYPlus = isYPlus;
            }

            if (moveInfo.W.HasValue && moveInfo.A.HasValue)
            {
                decimal actPosW = Contra.GetActPosW(axisType);
                isWPlus = moveInfo.W.Value >= actPosW;
                decimal actPosA = Contra.GetActPosA(axisType);
                isAPlus = moveInfo.A.Value >= actPosA;
                CtrlCard.Sym_AbsoluteLine2(AxisSet.AxisW, AxisSet.AxisZ,
                GetMovePosition("W", moveInfo.W, actPosW, Contra.LogPosW, isWPlus != isOldWPlus, isOldWPlus, out jianxiW),
                GetMovePosition("A", moveInfo.A, actPosA, Contra.LogPosA, isAPlus != isOldAPlus, isOldAPlus, out jianxiA),
                Contra.StartSpeed,
                (int)AxisSet.SpeedWPerSecond,
                Contra.AddSpeedTime);
                isOldWPlus = isWPlus;
                isOldAPlus = isAPlus;
            }

            if (moveInfo.B.HasValue && moveInfo.C.HasValue)
            {
                decimal actPosB = Contra.GetActPosB(axisType);
                isBPlus = moveInfo.B.Value >= actPosB;
                decimal actPosC = Contra.GetActPosC(axisType);
                isCPlus = moveInfo.C.Value >= actPosC;
                CtrlCard.Sym_AbsoluteLine2(AxisSet.AxisB, AxisSet.AxisC,
                GetMovePosition("B", moveInfo.B, actPosB, Contra.LogPosB, isBPlus != isOldBPlus, isOldBPlus, out jianxiB),
                GetMovePosition("C", moveInfo.C, actPosC, Contra.LogPosC, isCPlus != isOldCPlus, isOldCPlus, out jianxiC),
                Contra.StartSpeed,
                (int)AxisSet.SpeedWPerSecond,
                Contra.AddSpeedTime);
                isOldWPlus = isWPlus;
                isOldAPlus = isAPlus;
            }
        }

        private int GetMovePosition(string axisType, Nullable<decimal> infoValue, decimal lastPosition, decimal logPosition, bool flag, bool flag2, out decimal jianxi)
        {
            decimal value = logPosition;
            jianxi = 0;
            if (infoValue.HasValue)
            {
                value += infoValue.Value;
                if (isG90)
                    value -= lastPosition;
            }
            decimal resolution = AxisSet.GetResolution(axisType);
            value = Contra.GetRealValue(axisType, value, AxisSet, flag, flag2, out jianxi);
            return Convert.ToInt32(value * 1000 / resolution);
        }

        public void CloseSingleMove(int axis)
        {
            CtrlCard.StopRun(axis, 0);
        }

        private int GetJianxiPosition(string axisType, Nullable<decimal> infoValue, decimal lastPosition, decimal logPosition)
        {
            decimal value = logPosition;
            if (infoValue.HasValue)
            {
                value += infoValue.Value;
                if (isG90)
                    value -= lastPosition;
            }
            value = Contra.GetJianXiValue(axisType, value, lastPosition, AxisSet);
            return Convert.ToInt32(value * 1000);
        }

        public void JianxiTiaozheng()
        {
            //if (isMove)
            //{
            //    SetLogPos(AxisSet.AxisX, (int)((Contra.LogPosX + jianxiX) * 1000));
            //    SetLogPos(AxisSet.AxisY, (int)((Contra.LogPosY + jianxiY) * 1000));
            //    SetLogPos(AxisSet.AxisW, (int)((Contra.LogPosW + jianxiW) * 1000));
            //    SetLogPos(AxisSet.AxisZ, (int)((Contra.LogPosA + jianxiA) * 1000));
            //    SetLogPos(AxisSet.AxisB, (int)((Contra.LogPosB + jianxiB) * 1000));
            //    SetLogPos(AxisSet.AxisC, (int)((Contra.LogPosC + jianxiC) * 1000));
            //    jianxiX = 0;
            //    jianxiY = 0;
            //    jianxiW = 0;
            //    jianxiA = 0;
            //    jianxiB = 0;
            //    jianxiC = 0;
            //    isMove = false;
            //}
        }
        #endregion

        #region 回零
        public bool Home(int axis, int backDir, int startSpeed, decimal speed, int searchSpeed, int searchRange, decimal pianzhi)
        {
            int i = CtrlCard.Home(axis, backDir, startSpeed, (int)speed, Contra.AddSpeed, 4000, searchSpeed, searchRange);
            if (i == 0)
            {
                CtrlCard.Sym_RelativeMove(axis, (int)(pianzhi * 1000), startSpeed, searchSpeed, (double)Contra.AddSpeedTime);
                while (CtrlCard.Get_Status(axis, 0) != 0)
                {
                    System.Threading.Thread.Sleep(50);
                }
                SetLogPos(axis, 0);
                return true;
            }
            return false;
        }
        #endregion

        #region 控制卡断开判断
        public void SetOutCheck()
        {
            SetActPos(6, 200);
        }

        public bool GetOutCheck()
        {
            decimal pos = GetActPos(6);
            return pos > 0;
        }
        #endregion

        #region 操作
        public bool isOperate;
        private void OperateCloseOutput(params int[] outPuts)
        {
            if (isOperate)
            {
                foreach (int item in outPuts)
                {
                    if (GetOutPutState(item)) SetOutPut(item, 0);
                }
                isOperate = false;
            }
        }

        public void OperateClose()
        {
            if (isOperate)
            {
                isOperate = false;
            }
        }

        public void CloseAllMove()
        {
            for (int i = 1; i <= AxisSetInfo.MaxAxis; i++)
            {
                CtrlCard.StopRun(i, 0);
            }
        }

        public void OperateStopRun()
        {
            if (isOperate)
            {
                CloseAllMove();
                isOperate = false;
            }
        }

        public void OperateCenter(int axis, int value, int speed)
        {
            if (value > 0)
            {
                OperatePlus(axis, value, speed);
            }
            else
            {
                OperateMinus(axis, value, speed);
            }
        }

        public void OperatePlus(int axis)
        {
            decimal value = GetPlusLeftPositionByLimit(axis);
            Operate(axis, (int)value);
        }

        public void OperatePlus(int axis, int value2, int speed)
        {
            int value = (int)GetPlusLeftPositionByLimit(axis);
            Operate(axis, Math.Min(value, value2), speed);
        }

        public void OperateMinus(int axis)
        {
            decimal value = GetMinusLeftPositionByLimit(axis);
            Operate(axis, (int)value);
        }

        public void OperateMinus(int axis, int value2, int speed)
        {
            int value = (int)GetMinusLeftPositionByLimit(axis);
            Operate(axis, Math.Max(value, value2), speed);
        }

        public void Operate(int axis, int length)
        {
            Operate(axis, length, (int)AxisSet.GetSpeed(axis));
        }

        public bool Operate(int axis, int length, int speed)
        {
            return Operate(axis, length, speed, false);
        }

        public bool Operate(int axis, int length, int speed, bool isContinue)
        {
            if (CanOperate(axis) || isContinue)
            {
                decimal resolution = AxisSet.GetResolution(axis);
                if (Contra.StepLength != 0 && !IsMove(axis))
                {
                    if (!CheckSoftLimit(axis, length, Contra.StepLength))
                    {
                        return false;
                    }
                    CtrlCard.Sym_RelativeMove(axis, (int)((length > 0 ? Contra.StepLength : (0 - Contra.StepLength)) * resolution), speed, (int)AxisSet.GetSpeed(axis), (double)Contra.AddSpeedTime);
                    form.isM21 = false;
                    form.isEndM21 = false;
                    moveState = 0;
                }
                else if (!IsMove(axis))
                {
                    if (!CheckSoftLimit(axis, length, length))
                    {
                        return false;
                    }
                    CtrlCard.Sym_RelativeMove(axis, length, Contra.StartSpeed, speed, Contra.AddSpeedTime);
                    form.isM21 = false;
                    form.isEndM21 = false;
                    moveState = 0;
                }
                isOperate = true;
                return true;
            }
            return false;
        }

        public bool CheckSoftLimit(int axis, int length, int stepLength)
        {
            decimal logValue = GetLogPos(axis) * 1000;
            if ((axis == AxisSet.AxisX && ((length > 0 && (logValue + stepLength > AxisSet.SoftXPlusLimit * 1000)) || (length < 0 && (logValue - stepLength < AxisSet.SoftXMinusLimit * 1000))))
                || (axis == AxisSet.AxisY && ((length > 0 && (logValue + stepLength > AxisSet.SoftYPlusLimit * 1000)) || (length < 0 && (logValue - stepLength < AxisSet.SoftYMinusLimit * 1000))))
                || (axis == AxisSet.AxisW && ((length > 0 && (logValue + stepLength > AxisSet.SoftWPlusLimit * 1000)) || (length < 0 && (logValue - stepLength < AxisSet.SoftWMinusLimit * 1000))))
                || (axis == AxisSet.AxisB && ((length > 0 && (logValue + stepLength > AxisSet.SoftBPlusLimit * 1000)) || (length < 0 && (logValue - stepLength < AxisSet.SoftBMinusLimit * 1000))))
                || (axis == AxisSet.AxisC && ((length > 0 && (logValue + stepLength > AxisSet.SoftCPlusLimit * 1000)) || (length < 0 && (logValue - stepLength < AxisSet.SoftCMinusLimit * 1000)))))
            {
                //ContraHelper.ShowError("将会超过软件限位，运行停止");
                return false;
            }
            return true;
        }

        private bool CanOperate(int axis)
        {
            bool isZero = IOHelper.IsZero();
            bool isStop = IOHelper.IsStopButton();
            bool isNotWarning = IsNotWarning();
            bool isNotIgnore = AxisSet.IsNotIgnore(axis);
            return (!isZero || axis == 4) && !isStop && isNotWarning && !isOperate && isNotIgnore;
        }

        private void OperateSpeedMinus()
        {
            if (Contra.StepLength == ContraHelper.Step1)
                Contra.StepLength = ContraHelper.Step0;
            else if (Contra.StepLength == ContraHelper.Step2)
                Contra.StepLength = ContraHelper.Step1;
            else if (Contra.StepLength == ContraHelper.Step3)
                Contra.StepLength = ContraHelper.Step2;
            else if (Contra.StepLength == ContraHelper.Step5)
                Contra.StepLength = ContraHelper.Step3;
        }

        private void OperateSpeedPlus()
        {
            if (Contra.StepLength == ContraHelper.Step0)
                Contra.StepLength = ContraHelper.Step1;
            else if (Contra.StepLength == ContraHelper.Step1)
                Contra.StepLength = ContraHelper.Step2;
            else if (Contra.StepLength == ContraHelper.Step2)
                Contra.StepLength = ContraHelper.Step3;
            else if (Contra.StepLength == ContraHelper.Step3)
                Contra.StepLength = ContraHelper.Step5;

        }
        #endregion

        public bool IsNotWarning()
        {
            return (AxisSet.IgnoreX || IOHelper.IsXNotWarning())
                && (AxisSet.IgnoreY || IOHelper.IsYNotWarning())
                && (AxisSet.IgnoreW || IOHelper.IsWNotWarning())
                && (AxisSet.IgnoreZ || IOHelper.IsZNotWarning())
                && (AxisSet.IgnoreB || IOHelper.IsBNotWarning())
                && (AxisSet.IgnoreC || IOHelper.IsCNotWarning());
        }

        public bool IsRunning()
        {
            return (!AxisSet.IgnoreX && IsMove(AxisSet.AxisX))
                || (!AxisSet.IgnoreY && IsMove(AxisSet.AxisY))
                || (!AxisSet.IgnoreW && IsMove(AxisSet.AxisW))
                || (!AxisSet.IgnoreZ && IsMove(AxisSet.AxisZ))
                || (!AxisSet.IgnoreB && IsMove(AxisSet.AxisB))
                || (!AxisSet.IgnoreC && IsMove(AxisSet.AxisC));
        }

        public void ReadPos()
        {
            //读取轴数据
            if (!AxisSet.IgnoreX) Contra.LogPosX = GetLogPos(AxisSet.AxisX) * AxisSet.XResolution;
            if (!AxisSet.IgnoreY) Contra.LogPosY = GetLogPos(AxisSet.AxisY) * AxisSet.YResolution;
            if (!AxisSet.IgnoreW) Contra.LogPosW = GetLogPos(AxisSet.AxisW) * AxisSet.WResolution;
            if (!AxisSet.IgnoreZ) Contra.LogPosA = GetLogPos(AxisSet.AxisZ) * AxisSet.AResolution;
            if (!AxisSet.IgnoreB) Contra.LogPosB = GetLogPos(AxisSet.AxisB) * AxisSet.BResolution;
            if (!AxisSet.IgnoreC) Contra.LogPosC = GetLogPos(AxisSet.AxisC) * AxisSet.CResolution;
            Contra.LogPosZ = GetActPos(AxisSet.ZReadAxis) * AxisSet.ZResolution;
        }

        public void OperateCache(int axis, int length, int speed)
        {
            CtrlCard.Fifo_inp_move1(axis, length, speed);
        }

        public void OperateStopCache()
        {
            CtrlCard.Reset_fifo();
        }

        public int OperateGetCacheCount()
        {
            return CtrlCard.Read_fifo_count();
        }

        public decimal GetPlusLeftPositionByLimit(int axis)
        {
            decimal position = GetLogPos(axis) * 1000;
            if (Contra.StepLength == 0)
            {
                if (axis == AxisSet.AxisX)
                {
                    return AxisSet.SoftXPlusLimit * 1000 - position;
                }
                else if (axis == AxisSet.AxisY)
                {
                    return AxisSet.SoftYPlusLimit * 1000 - position;
                }
                else if (axis == AxisSet.AxisW)
                {
                    return AxisSet.SoftWPlusLimit * 1000 - position;
                }
                //else if (axis == AxisSet.AxisZ)
                //{
                //    return AxisSet.SoftZPlusLimit * 1000 - position;
                //}
                else if (axis == AxisSet.AxisB)
                {
                    return AxisSet.SoftBPlusLimit * 1000 - position;
                }
                else if (axis == AxisSet.AxisC)
                {
                    return AxisSet.SoftCPlusLimit * 1000 - position;
                }
            }
            else
            {
                return Contra.StepLength;
            }
            return position;
        }

        public decimal GetMinusLeftPositionByLimit(int axis)
        {
            decimal position = GetLogPos(axis) * 1000;
            if (Contra.StepLength == 0)
            {
                if (axis == AxisSet.AxisX)
                {
                    return AxisSet.SoftXMinusLimit * 1000 - position;
                }
                else if (axis == AxisSet.AxisY)
                {
                    return AxisSet.SoftYMinusLimit * 1000 - position;
                }
                else if (axis == AxisSet.AxisW)
                {
                    return AxisSet.SoftWMinusLimit * 1000 - position;
                }
                //else if (axis == AxisSet.AxisZ)
                //{
                //    return AxisSet.SoftZMinusLimit * 1000 - position;
                //}
                else if (axis == AxisSet.AxisB)
                {
                    return AxisSet.SoftBMinusLimit * 1000 - position;
                }
                else if (axis == AxisSet.AxisC)
                {
                    return AxisSet.SoftCMinusLimit * 1000 - position;
                }
            }
            else
            {
                return -Contra.StepLength;
            }
            return -position;
        }

        public decimal ConvertWheelSoftPlusLimit(int axis, decimal wheelStaticValue, decimal wheelAddValue, decimal length)
        {
            if (axis == 1)
            {
                return AxisSet.SoftXPlusLimit * 1000 - wheelStaticValue - wheelAddValue - length < 0 ? 0 : length;
            }
            else if (axis == 2)
            {
                return AxisSet.SoftYPlusLimit * 1000 - wheelStaticValue - wheelAddValue - length < 0 ? 0 : length;
            }
            else if (axis == 4)
            {
                return AxisSet.SoftWPlusLimit * 1000 - wheelStaticValue - wheelAddValue - length < 0 ? 0 : length;
            }
            else if (axis == 5)
            {
                return AxisSet.SoftBPlusLimit * 1000 - wheelStaticValue - wheelAddValue - length < 0 ? 0 : length;
            }
            else if (axis == 6)
            {
                return AxisSet.SoftCPlusLimit * 1000 - wheelStaticValue - wheelAddValue - length < 0 ? 0 : length;
            }
            return length;
        }

        public decimal ConvertWheelSoftMinusLimit(int axis, decimal wheelStaticValue, decimal wheelAddValue, decimal length)
        {
            if (axis == 1)
            {
                return AxisSet.SoftXMinusLimit * 1000 - wheelStaticValue - wheelAddValue - length >= 0 ? 0 : length;
            }
            else if (axis == 2)
            {
                return AxisSet.SoftYMinusLimit * 1000 - wheelStaticValue - wheelAddValue - length >= 0 ? 0 : length;
            }
            else if (axis == 4)
            {
                return AxisSet.SoftWMinusLimit * 1000 - wheelStaticValue - wheelAddValue - length >= 0 ? 0 : length;
            }
            else if (axis == 5)
            {
                return AxisSet.SoftBMinusLimit * 1000 - wheelStaticValue - wheelAddValue - length >= 0 ? 0 : length;
            }
            else if (axis == 6)
            {
                return AxisSet.SoftCMinusLimit * 1000 - wheelStaticValue - wheelAddValue - length >= 0 ? 0 : length;
            }
            return length;
        }

        public decimal GetZStroke()
        {
            if (AxisSet.ZMinusLimitMode == 1)
            {
                return AxisSet.ZStroke;
            }
            else
            {
                return AxisSet.ZStroke2;
            }
        }

        //位置锁存工作模式
        public void Setup_LockPosition()
        {
            CtrlCard.Setup_LockPosition(3, 1, 0, 0);
        }

        //是否执行过锁存操作
        public bool IsLockStatus()
        {
            return CtrlCard.Get_LockStatus(3) == 1;
        }

        //获取锁存位置
        public int GetLockPosition()
        {
            return CtrlCard.Get_LockPosition(3);
        }

        //清除锁存
        public void ClearLockPosition()
        {
            CtrlCard.Clr_LockPosition(3);
        }
    }
}
