using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ContraLibrary;
using System.Windows.Forms;

namespace Contra
{
    public class IOHelper
    {
        CardHelper card;
        IOSetInfo ioSet;
        AxisSetInfo axisSet;
        AbsolutePosSetInfo apSet;
        PortHelper plcHelper;
        PortHelper _232Helper;
        FormMain form;
        bool[] inputStates = new bool[100];

        private bool isZero;
        private bool isThrow;
        private string wheelResult;

        public IOHelper(CardHelper card, IOSetInfo ioSet, AxisSetInfo axisSet, AbsolutePosSetInfo apSet, PortHelper plcHelper, PortHelper _232Helper, FormMain form)
        {
            this.card = card;
            this.form = form;
            this.ioSet = ioSet;
            this.axisSet = axisSet;
            this.apSet = apSet;
            this.plcHelper = plcHelper;
            this._232Helper = _232Helper;
        }

        #region 伺服
        public void CloseShifu()
        {
            card.SetOutPut(ioSet.Start, 0);
        }

        public void StartShifu()
        {
            card.SetOutPut(ioSet.Start, 1);
            if (form.PlcHelpr != null)
            {
                if (apSet.UseAbsolutePos)
                {
                    Load232Data();
                    Set232Data();
                }
                else if (apSet.UseFushiAbsolutePos)
                {
                    LoadAndSetFushiData();
                }
            }
        }

        public void Load232Data()
        {
            if (_232Helper != null)
            {
                apSet.ReadData(_232Helper.SendMsg2(PortHelper.BSignal));
                apSet.ReadData(_232Helper.SendMsg2(PortHelper.CSignal));
            }
        }

        public void Set232Data()
        {
            card.SetLogPos(axisSet.AxisB, (int)(apSet.GetBValue() * 1000));
            card.SetLogPos(axisSet.AxisC, (int)(apSet.GetCValue() * 1000));
        }

        public void LoadAndSetFushiData()
        {
            if (!this.axisSet.IgnoreX && this.apSet.UsePartX)
            {
                string code = GetPartCode(apSet.PartXNo);
                apSet.PartXData = _232Helper.SendMsg3(code, 9);
                card.SetLogPos(axisSet.AxisX, apSet.ReadFushiData(apSet.PartXData, (int)(card.GetLogPos(axisSet.AxisX) * 1000)));
            }
            if (!this.axisSet.IgnoreY && this.apSet.UsePartY)
            {
                string code = GetPartCode(apSet.PartYNo);
                apSet.PartYData = _232Helper.SendMsg3(code, 9);
                card.SetLogPos(axisSet.AxisY, apSet.ReadFushiData(apSet.PartYData, (int)(card.GetLogPos(axisSet.AxisY) * 1000)));
            }
            if (!this.axisSet.IgnoreW && this.apSet.UsePartW)
            {
                string code = GetPartCode(apSet.PartWNo);
                apSet.PartWData = _232Helper.SendMsg3(code, 9);
                card.SetLogPos(axisSet.AxisW, apSet.ReadFushiData(apSet.PartWData, (int)(card.GetLogPos(axisSet.AxisW) * 1000)));
            }
            if (!this.axisSet.IgnoreB && this.apSet.UsePartB)
            {
                string code = GetPartCode(apSet.PartBNo);
                apSet.PartBData = _232Helper.SendMsg3(code, 9);
                card.SetLogPos(axisSet.AxisB, apSet.ReadFushiData(apSet.PartBData, (int)(card.GetLogPos(axisSet.AxisB) * 1000)));
            }
            if (!this.axisSet.IgnoreC && this.apSet.UsePartC)
            {
                string code = GetPartCode(apSet.PartCNo);
                apSet.PartCData = _232Helper.SendMsg3(code, 9);
                card.SetLogPos(axisSet.AxisC, apSet.ReadFushiData(apSet.PartCData, (int)(card.GetLogPos(axisSet.AxisC) * 1000)));
            }
        }

        private string GetPartCode(int partNo)
        {
            switch (partNo)
            {
                case 1: return PortHelper.FushiPartXNo;
                case 2: return PortHelper.FushiPartYNo;
                case 3: return PortHelper.FushiPartWNo;
                case 4: return PortHelper.FushiPartBNo;
                case 5: return PortHelper.FushiPartCNo;
                default: return PortHelper.FushiPartXNo;
            }
        }

        public bool IsShifuStart()
        {
            return GetOutPutState(ioSet.Start);
        }
        #endregion

        #region 清零信号
        public bool IsZero()
        {
            return GetArrayState(ioSet.ZeroButton);
            //return isZero;
        }
        #endregion

        #region 关闭
        public bool IsClose()
        {
            return GetArrayState(ioSet.CloseButton);
        }
        #endregion

        #region 穿透
        public bool IsThrow()
        {
            if (ioSet.ThrowButton == 99) return true;
            return GetArrayState(ioSet.ThrowButton);
        }
        #endregion

        #region 气压检测
        public bool IsQiYaCheck()
        {
            if (ioSet.QiYaCheck == 99) return true;
            return GetArrayState(ioSet.QiYaCheck);
        }
        #endregion

        #region 刀库检测
        public bool IsDaoKuCheck()
        {
            if (ioSet.DaoKuCheck == 99) return true;
            return GetArrayState(ioSet.DaoKuCheck);
        }
        #endregion

        #region 刀库检测
        public bool IsLockCheck()
        {
            if (ioSet.LockCheck == 99) return true;
            return GetArrayState(ioSet.LockCheck);
        }
        #endregion

        #region 关闭输出
        public void CloseAllOutPut()
        {
            //card.Write_Output(ioSet.Jiagong, 0);
            //card.Write_Output(ioSet.Shuibeng, 0);
            //card.Write_Output(ioSet.Jixing, 0);
            //card.Write_Output(ioSet.Rotate, 0);
        }
        #endregion

        #region 读取输入点
        public void ReadInputs()
        {
            for (int i = 0; i < 32; i++)
            {
                inputStates[i] = GetInputState(i);
            }
            //ReadPlc();
        }

        private void ReadPlc()
        {
            //string result = plcHelper.SendMsg(PortHelper.Zero);
            //if (result != null)
            //    isZero = result.EndsWith(PortHelper.HasSignal);
            //result = plcHelper.SendMsg(PortHelper.Throw);
            //isThrow = result.EndsWith(PortHelper.HasSignal);
        }
        #endregion

        #region 各轴伺服报警
        public bool IsXNotWarning()
        {
            return GetArrayState(ioSet.XWarning);
        }

        public bool IsYNotWarning()
        {
            return GetArrayState(ioSet.YWarning);
        }

        public bool IsWNotWarning()
        {
            return GetArrayState(ioSet.WWarning);
        }

        public bool IsZNotWarning()
        {
            return GetArrayState(ioSet.ZWarning);
        }

        public bool IsBNotWarning()
        {
            return GetArrayState(ioSet.BWarning);
        }

        public bool IsCNotWarning()
        {
            return GetArrayState(ioSet.CWarning);
        }
        #endregion

        #region 各轴正负限位
        public bool IsXPlusLimit()
        {
            return GetArrayState(ioSet.XPlusLimit);
        }

        public bool IsXMinusLimit()
        {
            return GetArrayState(ioSet.XMinusLimit);
        }

        public bool IsYPlusLimit()
        {
            return GetArrayState(ioSet.YPlusLimit);
        }

        public bool IsYMinusLimit()
        {
            return GetArrayState(ioSet.YMinusLimit);
        }

        public bool IsWPlusLimit()
        {
            return GetArrayState(ioSet.WPlusLimit);
        }

        public bool IsWMinusLimit()
        {
            return GetArrayState(ioSet.WMinusLimit);
        }

        public bool IsZPlusLimit()
        {
            return GetArrayState(ioSet.ZPlusLimit);
        }

        public bool IsZMinusLimit()
        {
            if (axisSet.ZMinusLimitMode == 1)
            {
                return !GetArrayState(ioSet.ZMinusLimit);
            }
            else
            {
                return GetArrayState(ioSet.ZMinusLimit2);
            }
        }

        public bool IsBPlusLimit()
        {
            return GetArrayState(ioSet.BPlusLimit);
        }

        public bool IsBMinusLimit()
        {
            return GetArrayState(ioSet.BMinusLimit);
        }
        #endregion

        #region 急停
        internal bool IsStopButton()
        {
            return GetArrayState(ioSet.StopButton) == false;
        }
        #endregion

        #region W轴碰撞
        internal bool IsWHit()
        {
            return GetArrayState(ioSet.WHitButton);
        }

        //碰撞保护
        internal bool IsHitProtect()
        {
            return GetOutPut(ioSet.HitProtect) == 1;
        }
        #endregion

        #region 手轮
        public void ReadInputs2()
        {
            inputStates[ioSet.Wheel10] = GetInputState(ioSet.Wheel10);
            inputStates[ioSet.Wheel100] = GetInputState(ioSet.Wheel100);
            inputStates[ioSet.WheelAxis1] = GetInputState(ioSet.WheelAxis1);
            inputStates[ioSet.WheelAxis2] = GetInputState(ioSet.WheelAxis2);
            inputStates[ioSet.WheelAxis3] = GetInputState(ioSet.WheelAxis3);
            inputStates[ioSet.WheelAxis4] = GetInputState(ioSet.WheelAxis4);
            inputStates[ioSet.WheelAxis5] = GetInputState(ioSet.WheelAxis5);

            inputStates[ioSet.WheelAxis11] = GetInputState(ioSet.WheelAxis11);
            inputStates[ioSet.WheelAxis21] = GetInputState(ioSet.WheelAxis21);
            inputStates[ioSet.WheelAxis31] = GetInputState(ioSet.WheelAxis31);

            inputStates[ioSet.WheelButton1] = GetInputState(ioSet.WheelButton1);
            inputStates[ioSet.WheelButton2] = GetInputState(ioSet.WheelButton2);
            inputStates[ioSet.WheelButton3] = GetInputState(ioSet.WheelButton3);
            inputStates[ioSet.WheelButton4] = GetInputState(ioSet.WheelButton4);
            inputStates[ioSet.WheelButton5] = GetInputState(ioSet.WheelButton5);
            inputStates[ioSet.WheelButton6] = GetInputState(ioSet.WheelButton6);
            inputStates[ioSet.WheelButton7] = GetInputState(ioSet.WheelButton7);
        }

        public int GetWheelBeilv()
        {
            if (GetArrayState(ioSet.Wheel10) && GetArrayState(ioSet.Wheel100))
            {
                return 100;
            }
            if (GetArrayState(ioSet.Wheel10))
            {
                return 1;
            }
            if (GetArrayState(ioSet.Wheel100))
            {
                return 10;
            }
            return 100;
        }

        public string GetWheelChooseText(int choose)
        {
            switch (choose)
            {
                case 1: return "X";
                case 2: return "Y";
                case 3: return "Z";
                case 4: return "W";
                case 5: return "B";
                case 6: return "C";
            }
            return "";
        }

        public string GetWheelText(int beiLv, int choose)
        {
            if (choose == 0 || choose == 7)
            {
                return L.R("IOHelper.WheelOFF", "手轮 OFF");
            }
            string text = GetWheelChooseText(choose);
            switch (beiLv)
            {
                case 1: text += "x1"; break;
                case 10: text += "x10"; break;
                case 100: text += "x100"; break;
            }
            return L.R("IOHelper.Wheel", "手轮 ") + text;
        }

        public int GetWheelChoose()
        {
            if (ioSet.ShouLunType == 1)
            {
                if (GetArrayState(ioSet.WheelAxis1))
                {
                    return 1;
                }
                if (GetArrayState(ioSet.WheelAxis2))
                {
                    return 2;
                }
                if (GetArrayState(ioSet.WheelAxis3))
                {
                    return 4;
                }
                if (GetArrayState(ioSet.WheelAxis4))
                {
                    return 5;
                }
                if (GetArrayState(ioSet.WheelAxis5))
                {
                    return 6;
                }
            }
            else
            {
                int result = 0;
                if (GetArrayState(ioSet.WheelAxis11))
                {
                    result += 1;
                }
                if (GetArrayState(ioSet.WheelAxis21))
                {
                    result += 10;
                }
                if (GetArrayState(ioSet.WheelAxis31))
                {
                    result += 100;
                }
                switch (result)
                {
                    case 1: return 1;//X
                    case 10: return 2;//Y
                    case 11: return 3;//Z
                    case 100: return 4;//W
                    case 101: return 5;//
                    case 110: return 6;
                    case 111: return 7;

                    //case 1: return 1;
                    //case 10: return 2;
                    //case 11: return 3;
                    //case 100: return 4;
                    //case 101: return 5;
                    //case 110: return 6;
                    //case 111: return 7;
                }
                return 0;
            }
            return 0;
        }

        public bool IsWheelButton1()
        {
            return GetArrayState(ioSet.WheelButton1);
        }

        public bool IsWheelButton2()
        {
            return GetArrayState(ioSet.WheelButton2);
        }

        public bool IsWheelButton3()
        {
            return GetArrayState(ioSet.WheelButton3);
        }

        public bool IsWheelButton4()
        {
            return GetArrayState(ioSet.WheelButton4);
        }

        public bool IsWheelButton5()
        {
            return GetArrayState(ioSet.WheelButton5);
        }

        public bool IsWheelButton6()
        {
            return GetArrayState(ioSet.WheelButton6);
        }

        public bool IsWheelButton7()
        {
            return GetArrayState(ioSet.WheelButton7);
        }
        #endregion

        #region 设置参数
        public void SetTOn(int ton)
        {
            switch (ton)
            {
                case 0:
                    SetOutPut(ioSet.TOn1, 0);
                    SetOutPut(ioSet.TOn2, 0);
                    SetOutPut(ioSet.TOn4, 0);
                    SetOutPut(ioSet.TOn8, 0);
                    break;
                case 1:
                    SetOutPut(ioSet.TOn1, 1);
                    SetOutPut(ioSet.TOn2, 0);
                    SetOutPut(ioSet.TOn4, 0);
                    SetOutPut(ioSet.TOn8, 0);
                    break;
                case 2:
                    SetOutPut(ioSet.TOn1, 0);
                    SetOutPut(ioSet.TOn2, 1);
                    SetOutPut(ioSet.TOn4, 0);
                    SetOutPut(ioSet.TOn8, 0);
                    break;
                case 3:
                    SetOutPut(ioSet.TOn1, 1);
                    SetOutPut(ioSet.TOn2, 1);
                    SetOutPut(ioSet.TOn4, 0);
                    SetOutPut(ioSet.TOn8, 0);
                    break;
                case 4:
                    SetOutPut(ioSet.TOn1, 0);
                    SetOutPut(ioSet.TOn2, 0);
                    SetOutPut(ioSet.TOn4, 1);
                    SetOutPut(ioSet.TOn8, 0);
                    break;
                case 5:
                    SetOutPut(ioSet.TOn1, 1);
                    SetOutPut(ioSet.TOn2, 0);
                    SetOutPut(ioSet.TOn4, 1);
                    SetOutPut(ioSet.TOn8, 0);
                    break;
                case 6:
                    SetOutPut(ioSet.TOn1, 0);
                    SetOutPut(ioSet.TOn2, 1);
                    SetOutPut(ioSet.TOn4, 1);
                    SetOutPut(ioSet.TOn8, 0);
                    break;
                case 7:
                    SetOutPut(ioSet.TOn1, 1);
                    SetOutPut(ioSet.TOn2, 1);
                    SetOutPut(ioSet.TOn4, 1);
                    SetOutPut(ioSet.TOn8, 0);
                    break;
                case 8:
                    SetOutPut(ioSet.TOn1, 0);
                    SetOutPut(ioSet.TOn2, 0);
                    SetOutPut(ioSet.TOn4, 0);
                    SetOutPut(ioSet.TOn8, 1);
                    break;
                case 9:
                    SetOutPut(ioSet.TOn1, 1);
                    SetOutPut(ioSet.TOn2, 0);
                    SetOutPut(ioSet.TOn4, 0);
                    SetOutPut(ioSet.TOn8, 1);
                    break;
            }
        }

        public void SetTOff(int toff)
        {
            switch (toff)
            {
                case 0:
                    SetOutPut(ioSet.TOff1, 0);
                    SetOutPut(ioSet.TOff2, 0);
                    SetOutPut(ioSet.TOff4, 0);
                    SetOutPut(ioSet.TOff8, 0);
                    break;
                case 1:
                    SetOutPut(ioSet.TOff1, 1);
                    SetOutPut(ioSet.TOff2, 0);
                    SetOutPut(ioSet.TOff4, 0);
                    SetOutPut(ioSet.TOff8, 0);
                    break;
                case 2:
                    SetOutPut(ioSet.TOff1, 0);
                    SetOutPut(ioSet.TOff2, 1);
                    SetOutPut(ioSet.TOff4, 0);
                    SetOutPut(ioSet.TOff8, 0);
                    break;
                case 3:
                    SetOutPut(ioSet.TOff1, 1);
                    SetOutPut(ioSet.TOff2, 1);
                    SetOutPut(ioSet.TOff4, 0);
                    SetOutPut(ioSet.TOff8, 0);
                    break;
                case 4:
                    SetOutPut(ioSet.TOff1, 0);
                    SetOutPut(ioSet.TOff2, 0);
                    SetOutPut(ioSet.TOff4, 1);
                    SetOutPut(ioSet.TOff8, 0);
                    break;
                case 5:
                    SetOutPut(ioSet.TOff1, 1);
                    SetOutPut(ioSet.TOff2, 0);
                    SetOutPut(ioSet.TOff4, 1);
                    SetOutPut(ioSet.TOff8, 0);
                    break;
                case 6:
                    SetOutPut(ioSet.TOff1, 0);
                    SetOutPut(ioSet.TOff2, 1);
                    SetOutPut(ioSet.TOff4, 1);
                    SetOutPut(ioSet.TOff8, 0);
                    break;
                case 7:
                    SetOutPut(ioSet.TOff1, 1);
                    SetOutPut(ioSet.TOff2, 1);
                    SetOutPut(ioSet.TOff4, 1);
                    SetOutPut(ioSet.TOff8, 0);
                    break;
                case 8:
                    SetOutPut(ioSet.TOff1, 0);
                    SetOutPut(ioSet.TOff2, 0);
                    SetOutPut(ioSet.TOff4, 0);
                    SetOutPut(ioSet.TOff8, 1);
                    break;
                case 9:
                    SetOutPut(ioSet.TOff1, 1);
                    SetOutPut(ioSet.TOff2, 0);
                    SetOutPut(ioSet.TOff4, 0);
                    SetOutPut(ioSet.TOff8, 1);
                    break;
            }
        }

        public void SetI(int i)
        {
            switch (i)
            {
                case 0: SetOutPut(ioSet.I8, 0);
                    SetOutPut(ioSet.I4, 0);
                    SetOutPut(ioSet.I2, 0);
                    SetOutPut(ioSet.I1, 0);
                    break;
                case 1: SetOutPut(ioSet.I8, 0);
                    SetOutPut(ioSet.I4, 0);
                    SetOutPut(ioSet.I2, 0);
                    SetOutPut(ioSet.I1, 1);
                    break;
                case 2: SetOutPut(ioSet.I8, 0);
                    SetOutPut(ioSet.I4, 0);
                    SetOutPut(ioSet.I2, 1);
                    SetOutPut(ioSet.I1, 0);
                    break;
                case 3: SetOutPut(ioSet.I8, 0);
                    SetOutPut(ioSet.I4, 0);
                    SetOutPut(ioSet.I2, 1);
                    SetOutPut(ioSet.I1, 1);
                    break;
                case 4: SetOutPut(ioSet.I8, 0);
                    SetOutPut(ioSet.I4, 1);
                    SetOutPut(ioSet.I2, 0);
                    SetOutPut(ioSet.I1, 0);
                    break;
                case 5: SetOutPut(ioSet.I8, 0);
                    SetOutPut(ioSet.I4, 1);
                    SetOutPut(ioSet.I2, 0);
                    SetOutPut(ioSet.I1, 1);
                    break;
                case 6: SetOutPut(ioSet.I8, 0);
                    SetOutPut(ioSet.I4, 1);
                    SetOutPut(ioSet.I2, 1);
                    SetOutPut(ioSet.I1, 0);
                    break;
                case 7: SetOutPut(ioSet.I8, 0);
                    SetOutPut(ioSet.I4, 1);
                    SetOutPut(ioSet.I2, 1);
                    SetOutPut(ioSet.I1, 1);
                    break;
                case 8: SetOutPut(ioSet.I8, 1);
                    SetOutPut(ioSet.I4, 0);
                    SetOutPut(ioSet.I2, 0);
                    SetOutPut(ioSet.I1, 0);
                    break;
                case 9: SetOutPut(ioSet.I8, 1);
                    SetOutPut(ioSet.I4, 0);
                    SetOutPut(ioSet.I2, 0);
                    SetOutPut(ioSet.I1, 1);
                    break;
            }
        }

        public void SetI2(int i)
        {
            switch (i)
            {
                case 0: SetOutPut(ioSet.IC1, 0);
                    SetOutPut(ioSet.IC2, 0);
                    SetOutPut(ioSet.IC4, 0);
                    SetOutPut(ioSet.IC8, 0);
                    break;
                case 1: SetOutPut(ioSet.IC1, 1);
                    SetOutPut(ioSet.IC2, 0);
                    SetOutPut(ioSet.IC4, 0);
                    SetOutPut(ioSet.IC8, 0);
                    break;
                case 2: SetOutPut(ioSet.IC1, 0);
                    SetOutPut(ioSet.IC2, 1);
                    SetOutPut(ioSet.IC4, 0);
                    SetOutPut(ioSet.IC8, 0);
                    break;
                case 3: SetOutPut(ioSet.IC1, 1);
                    SetOutPut(ioSet.IC2, 1);
                    SetOutPut(ioSet.IC4, 0);
                    SetOutPut(ioSet.IC8, 0);
                    break;
                case 4: SetOutPut(ioSet.IC1, 0);
                    SetOutPut(ioSet.IC2, 0);
                    SetOutPut(ioSet.IC4, 1);
                    SetOutPut(ioSet.IC8, 0);
                    break;
                case 5: SetOutPut(ioSet.IC1, 1);
                    SetOutPut(ioSet.IC2, 0);
                    SetOutPut(ioSet.IC4, 1);
                    SetOutPut(ioSet.IC8, 0);
                    break;
                case 6: SetOutPut(ioSet.IC1, 0);
                    SetOutPut(ioSet.IC2, 1);
                    SetOutPut(ioSet.IC4, 1);
                    SetOutPut(ioSet.IC8, 0);
                    break;
                case 7: SetOutPut(ioSet.IC1, 1);
                    SetOutPut(ioSet.IC2, 1);
                    SetOutPut(ioSet.IC4, 1);
                    SetOutPut(ioSet.IC8, 0);
                    break;
                case 8: SetOutPut(ioSet.IC1, 0);
                    SetOutPut(ioSet.IC2, 0);
                    SetOutPut(ioSet.IC4, 0);
                    SetOutPut(ioSet.IC8, 1);
                    break;
                case 9: SetOutPut(ioSet.IC1, 1);
                    SetOutPut(ioSet.IC2, 0);
                    SetOutPut(ioSet.IC4, 0);
                    SetOutPut(ioSet.IC8, 1);
                    break;
                case 10: SetOutPut(ioSet.IC1, 0);
                    SetOutPut(ioSet.IC2, 1);
                    SetOutPut(ioSet.IC4, 0);
                    SetOutPut(ioSet.IC8, 1);
                    break;
                case 11: SetOutPut(ioSet.IC1, 1);
                    SetOutPut(ioSet.IC2, 1);
                    SetOutPut(ioSet.IC4, 0);
                    SetOutPut(ioSet.IC8, 1);
                    break;
                case 12: SetOutPut(ioSet.IC1, 0);
                    SetOutPut(ioSet.IC2, 0);
                    SetOutPut(ioSet.IC4, 1);
                    SetOutPut(ioSet.IC8, 1);
                    break;
                case 13: SetOutPut(ioSet.IC1, 1);
                    SetOutPut(ioSet.IC2, 0);
                    SetOutPut(ioSet.IC4, 1);
                    SetOutPut(ioSet.IC8, 1);
                    break;
                case 14: SetOutPut(ioSet.IC1, 0);
                    SetOutPut(ioSet.IC2, 1);
                    SetOutPut(ioSet.IC4, 1);
                    SetOutPut(ioSet.IC8, 1);
                    break;
                case 15: SetOutPut(ioSet.IC1, 1);
                    SetOutPut(ioSet.IC2, 1);
                    SetOutPut(ioSet.IC4, 1);
                    SetOutPut(ioSet.IC8, 1);
                    break;
            }
        }

        public void SetSpeed(int speed)
        {
            plcHelper.SendMsg(PortHelper.SpeedTitle + speed.ToString("X"));
        }

        public void SetV(int v)
        {
            var v1 = "0000" + (v * 100 * -1).ToString("X");
            v1 = v1.Substring(v1.Length - 4, 4);
            plcHelper.SendMsg(PortHelper.VTitle + v1);
        }

        private string NegativeToHexString(int iNumber)
        {
            string strResult = string.Empty;

            if (iNumber < 0)
            {
                iNumber = -iNumber;

                string strNegate = string.Empty;

                char[] binChar = Convert.ToString(iNumber, 2).PadLeft(8, '0').ToArray();

                foreach (char ch in binChar)
                {
                    if (Convert.ToInt32(ch) == 48)
                    {
                        strNegate += "1";
                    }
                    else
                    {
                        strNegate += "0";
                    }
                }

                int iComplement = Convert.ToInt32(strNegate, 2) + 1;

                strResult = Convert.ToString(iComplement, 16).ToUpper();
            }

            return strResult;
        }

        #endregion

        #region 私有方法
        #region 输入相关
        private int GetInput(int number)
        {
            return card.CtrlCard.Read_Input(number);
        }
        /// <summary>
        /// 获取输入点的选中状态
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private bool GetInputState(int number)
        {
            return GetInput(number) == 0;
        }
        /// <summary>
        /// 获得数组中输入点的状态
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private bool GetArrayState(int number)
        {
            try
            {
                return inputStates[number];
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region 输出相关
        private int GetOutPut(int number)
        {
            return card.CtrlCard.Get_OutNum(number);
        }
        /// <summary>
        /// 获取输出点的选中状态
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private bool GetOutPutState(int number)
        {
            if (number == 99)
                return false;
            return GetOutPut(number) == 1;
        }
        /// <summary>
        /// 设置输出点状态
        /// </summary>
        private void SetOutPut(int number, int value)
        {
            if (number != 99)
            {
                card.SetOutPut(number, value);
            }
        }
        #endregion
        #endregion

        internal void SetShuibeng(int value)
        {
            SetOutPut(ioSet.Shuibeng, value);
        }

        internal void SetJiagong(int value)
        {
            SetOutPut(ioSet.Jiagong, value);
        }

        internal void SetJixing(int value)
        {
            SetOutPut(ioSet.Jixing, value);
        }

        internal void SetRotate(int value)
        {
            SetOutPut(ioSet.Rotate, value);
        }

        internal void SetChongShui(int value)
        {
            SetOutPut(ioSet.ChongShui, value);
        }

        internal void SetHitProtect(int value)
        {
            SetOutPut(ioSet.HitProtect, value);
        }

        internal void SetLight(int value)
        {
            SetOutPut(ioSet.Light, value);
        }

        internal void SetMen(int value)
        {
            SetOutPut(ioSet.Men, value);
        }

        public bool IsCOrigin()
        {
            return GetArrayState(ioSet.COrigin);
        }

        public bool IsCZero()
        {
            return GetArrayState(ioSet.CZero);
        }
    }
}
