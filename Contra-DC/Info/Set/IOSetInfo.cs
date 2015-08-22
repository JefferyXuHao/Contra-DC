using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contra
{
    public class IOSetInfo : BaseSetInfo
    {
        public IOSetInfo()
        {
            #region 输入点默认值
            XPlusLimit = 0;
            XMinusLimit = 1;
            XOrigin = 2;
            XWarning = 3;
            YPlusLimit = 4;
            YMinusLimit = 5;
            YOrigin = 6;
            YWarning = 7;
            WPlusLimit = 8;
            WMinusLimit = 9;
            WOrigin = 10;
            WWarning = 11;
            ZPlusLimit = 12;
            ZMinusLimit = 13;
            ZOrigin = 14;
            ZWarning = 15;
            BLimit = 17;
            BOrigin = 18;
            BWarning = 19;
            COrigin = 22;
            CWarning = 23;
            CloseButton = 24;
            StopButton = 25;
            ZeroButton = 27;
            ThrowButton = 28;
            ChongShui = 26;
            DaoKuCheck = 99;
            QiYaCheck = 99;
            #endregion

            #region 输出点默认值
            TOn1 = 3;
            TOn2 = 2;
            TOn4 = 1;
            TOn8 = 0;

            TOff1 = 7;
            TOff2 = 6;
            TOff4 = 5;
            TOff8 = 4;

            I1 = 11;
            I2 = 10;
            I4 = 9;
            I8 = 8;

            IC1 = 15;
            IC2 = 14;
            IC4 = 13;
            IC8 = 12;

            Wheel10 = 32;
            Wheel100 = 33;
            WheelAxis1 = 34;
            WheelAxis2 = 35;
            WheelAxis3 = 36;
            //WheelAxis4 = 37;
            //WheelAxis5 = 38;
            //WheelAxis6 = 39;

            Start = 24;
            Jiagong = 25;
            HitProtect = 25;
            Shuibeng = 26;
            Jixing = 27;
            Rotate = 28;
            WHitButton = 31;
            #endregion

            ShouLunType = 1;
        }

        #region 输入点
        public int XPlusLimit { get; set; }

        public int XMinusLimit { get; set; }

        public int XOrigin { get; set; }

        public int XWarning { get; set; }

        public int YPlusLimit { get; set; }

        public int YMinusLimit { get; set; }

        public int YOrigin { get; set; }

        public int YWarning { get; set; }

        public int WPlusLimit { get; set; }

        public int WMinusLimit { get; set; }

        public int WOrigin { get; set; }

        public int WWarning { get; set; }

        public int ZPlusLimit { get; set; }

        public int ZMinusLimit { get; set; }

        public int ZMinusLimit2 { get; set; }

        public int ZOrigin { get; set; }

        public int ZWarning { get; set; }

        public int BPlusLimit { get; set; }

        public int BMinusLimit { get; set; }

        public int BLimit { get; set; }

        public int BOrigin { get; set; }

        public int BWarning { get; set; }

        public int COrigin { get; set; }

        public int CZero { get; set; }

        public int CWarning { get; set; }

        public int CloseButton { get; set; }

        public int StopButton { get; set; }

        public int WHitButton { get; set; }

        public int ZeroButton { get; set; }

        public int ThrowButton { get; set; }

        public int QiYaCheck { get; set; }

        public int DaoKuCheck { get; set; }

        public int LockCheck { get; set; }

        #endregion

        #region 输出
        public int TOn1 { get; set; }
        public int TOn2 { get; set; }
        public int TOn4 { get; set; }
        public int TOn8 { get; set; }
        public int TOff1 { get; set; }
        public int TOff2 { get; set; }
        public int TOff4 { get; set; }
        public int TOff8 { get; set; }

        public int I1 { get; set; }
        public int I2 { get; set; }
        public int I4 { get; set; }
        public int I8 { get; set; }
        public int IC1 { get; set; }
        public int IC2 { get; set; }
        public int IC4 { get; set; }
        public int IC8 { get; set; }

        public int Wheel10 { get; set; }
        public int Wheel100 { get; set; }
        public int WheelAxis1 { get; set; }
        public int WheelAxis2 { get; set; }
        public int WheelAxis3 { get; set; }
        public int WheelAxis4 { get; set; }
        public int WheelAxis5 { get; set; }

        public int WheelAxis11 { get; set; }
        public int WheelAxis21 { get; set; }
        public int WheelAxis31 { get; set; }

        public int WheelButton1 { get; set; }
        public int WheelButton2 { get; set; }
        public int WheelButton3 { get; set; }
        public int WheelButton4 { get; set; }
        public int WheelButton5 { get; set; }
        public int WheelButton6 { get; set; }
        public int WheelButton7 { get; set; }

        public int HitProtect { get; set; }

        //public int WheelAxis4 { get; set; }
        //public int WheelAxis5 { get; set; }
        //public int WheelAxis6 { get; set; }

        public int Start { get; set; }
        public int Jiagong { get; set; }
        public int Shuibeng { get; set; }
        public int Jixing { get; set; }
        public int Rotate { get; set; }
        public int ChongShui { get; set; }
        public int Light { get; set; }
        public int Men { get; set; }
        #endregion

        //手轮类型，1普通手轮，2多功能键手轮
        public int ShouLunType { get; set; }
    }
}
