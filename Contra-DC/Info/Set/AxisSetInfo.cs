using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contra
{
    public class AxisSetInfo : BaseSetInfo
    {
        public const int MaxAxis = 6;

        public AxisSetInfo()
        {
            AxisX = 1;
            AxisY = 2;
            AxisW = 3;
            AxisZ = 4;
            AxisB = 5;
            AxisC = 6;

            SpeedX = 1000;
            SpeedY = 1000;
            SpeedW = 60;
            SpeedB = 60;
            SpeedC = 60;
            SpeedZ = 60;

            SpeedXHigh = 1000;
            SpeedYHigh = 1000;
            SpeedWHigh = 60;
            SpeedBHigh = 60;
            SpeedCHigh = 60;
            SpeedZHigh = 60;

            WheelSpeedX = 1000;
            WheelSpeedY = 1000;
            WheelSpeedW = 1000;
            WheelSpeedB = 1000;
            WheelSpeedC = 1000;
            WheelSpeedZ = 1000;

            SoftXPlusLimit = 300;
            SoftXMinusLimit = -300;
            SoftYPlusLimit = 300;
            SoftYMinusLimit = -300;
            SoftWPlusLimit = 300;
            SoftWMinusLimit = -300;
            SoftZPlusLimit = 300;
            SoftZMinusLimit = -300;
            SoftBPlusLimit = 300;
            SoftBMinusLimit = -300;
            SoftCPlusLimit = 300;
            SoftCMinusLimit = -300;

            WheelReadAxis = 2;
            ZReadAxis = 1;
            ZMinusLimitMode = 1;

            XResolution = 1;
            YResolution = 1;
            WResolution = 1;
            AResolution = 1;
            BResolution = 1;
            CResolution = 1;
            ZResolution = 1;

            UseFushi = 2;
            UseMen = 2;
        }

        public int WheelReadAxis { get; set; }
        public int ZReadAxis { get; set; }
        public int ZMinusLimitMode { get; set; }

        public decimal ThrowSpeed { get; set; }

        public int ThrowMode { get; set; }

        public int ThrowStartMode { get; set; }


        /// <summary>
        /// 忽略
        /// </summary>
        public bool IgnoreX { get; set; }
        public bool IgnoreY { get; set; }
        public bool IgnoreW { get; set; }
        public bool IgnoreZ { get; set; }
        public bool IgnoreB { get; set; }
        public bool IgnoreC { get; set; }

        /// <summary>
        /// 对应轴号
        /// </summary>
        public int AxisX { get; set; }
        public int AxisY { get; set; }
        public int AxisW { get; set; }
        public int AxisZ { get; set; }
        public int AxisB { get; set; }
        public int AxisC { get; set; }


        public bool UseHighSpeed { get; set; }
        public int UseFushi { get; set; }
        public int UseMen { get; set; }

        /// <summary>
        /// 驱动速度低速
        /// </summary>
        public decimal SpeedX { get; set; }
        public decimal SpeedY { get; set; }
        public decimal SpeedW { get; set; }
        public decimal SpeedB { get; set; }
        public decimal SpeedC { get; set; }
        public decimal SpeedZ { get; set; }

        /// <summary>
        /// 驱动速度高速
        /// </summary>
        public decimal SpeedXHigh { get; set; }
        public decimal SpeedYHigh { get; set; }
        public decimal SpeedWHigh { get; set; }
        public decimal SpeedBHigh { get; set; }
        public decimal SpeedCHigh { get; set; }
        public decimal SpeedZHigh { get; set; }

        /// <summary>
        /// 间隙
        /// </summary>
        public decimal WheelSpeedX { get; set; }
        public decimal WheelSpeedY { get; set; }
        public decimal WheelSpeedW { get; set; }
        public decimal WheelSpeedZ { get; set; }
        public decimal WheelSpeedB { get; set; }
        public decimal WheelSpeedC { get; set; }

        /// <summary>
        /// 限位
        /// </summary>
        public decimal SoftXPlusLimit { get; set; }
        public decimal SoftXMinusLimit { get; set; }
        public decimal SoftYPlusLimit { get; set; }
        public decimal SoftYMinusLimit { get; set; }
        public decimal SoftWPlusLimit { get; set; }
        public decimal SoftWMinusLimit { get; set; }
        public decimal SoftZPlusLimit { get; set; }
        public decimal SoftZMinusLimit { get; set; }
        public decimal SoftBPlusLimit { get; set; }
        public decimal SoftBMinusLimit { get; set; }
        public decimal SoftCPlusLimit { get; set; }
        public decimal SoftCMinusLimit { get; set; }

        /// <summary>
        /// z轴行程
        /// </summary>
        public decimal ZStroke { get; set; }

        public decimal ZStroke2 { get; set; }

        /// <summary>
        /// 分辨率
        /// </summary>
        public decimal XResolution { get; set; }
        public decimal YResolution { get; set; }
        public decimal WResolution { get; set; }
        public decimal AResolution { get; set; }
        public decimal BResolution { get; set; }
        public decimal CResolution { get; set; }
        public decimal ZResolution { get; set; }

        public int GetAxis(int axisType)
        {
            if (axisType == 1)
            {
                return AxisX;
            }
            else if (axisType == 2)
            {
                return AxisY;
            }
            else if (axisType == 3)
            {
                return AxisZ;
            }
            else if (axisType == 4)
            {
                return AxisW;
            }
            else if (axisType == 5)
            {
                return AxisB;
            }
            else if (axisType == 6)
            {
                return AxisC;
            }
            return 1;
        }

        internal void Validate()
        {
            //if (SpeedX > 2000)
            //    throw new Exception("X轴速度最多设置2000！");
            //else if (SpeedY > 2000)
            //    throw new Exception("Y轴速度最多设置2000！");
            //else if (SpeedW > 2000)
            //    throw new Exception("W轴速度最多设置2000！");
            //else if (SpeedZ > 2000)
            //    throw new Exception("A轴速度最多设置2000！");
            //else if (SpeedB > 2000)
            //    throw new Exception("B轴速度最多设置2000！");
            //else if (SpeedX <= 0)
            //    throw new Exception("X轴速度应设置大于0！");
            //else if (SpeedY <= 0)
            //    throw new Exception("Y轴速度应设置大于0！");
            //else if (SpeedZ <= 0)
            //    throw new Exception("A轴速度应设置大于0！");
            //else if (SpeedB <= 0)
            //    throw new Exception("B轴速度应设置大于0！");
            //else if (SpeedW <= 0)
            //    throw new Exception("W轴速度应设置大于0！");
        }

        public decimal GetXSpeed()
        {
            if (UseHighSpeed)
                return SpeedXHigh;
            return SpeedX;
        }

        public decimal GetYSpeed()
        {
            if (UseHighSpeed)
                return SpeedYHigh;
            return SpeedY;
        }

        public decimal GetWSpeed()
        {
            if (UseHighSpeed)
                return SpeedWHigh;
            return SpeedW;
        }

        public decimal GetBSpeed()
        {
            if (UseHighSpeed)
                return SpeedBHigh;
            return SpeedB;
        }

        public decimal GetCSpeed()
        {
            if (UseHighSpeed)
                return SpeedCHigh;
            return SpeedC;
        }

        public decimal SpeedXPerSecond
        {
            get {
                if (UseHighSpeed)
                    return this.SpeedXHigh / 60 * 1000; 
                return this.SpeedX / 60 * 1000; }
        }

        public decimal SpeedYPerSecond
        {
            get {
                if (UseHighSpeed)
                    return this.SpeedYHigh / 60 * 1000; 
                return this.SpeedY / 60 * 1000; }
        }

        public decimal SpeedWPerSecond
        {
            get {
                if (UseHighSpeed)
                    return this.SpeedWHigh / 60 * 1000; 
                return this.SpeedW / 60 * 1000; }
        }

        public decimal SpeedZPerSecond
        {
            get {
               if (UseHighSpeed)
                    return this.SpeedZHigh / 60 * 1000; 
                return this.SpeedZ / 60 * 1000; }
        }

        public decimal SpeedBPerSecond
        {
            get {
                if (UseHighSpeed)
                    return this.SpeedBHigh / 60 * 1000; 
                return this.SpeedB / 60 * 1000; }
        }

        public decimal SpeedCPerSecond
        {
            get {
                if (UseHighSpeed)
                    return this.SpeedCHigh / 60 * 1000; 
                return this.SpeedC / 60 * 1000; }
        }

        internal decimal GetSpeed(int axis)
        {
            if (AxisX == axis) return SpeedXPerSecond;
            if (AxisY == axis) return SpeedYPerSecond;
            if (AxisW == axis) return SpeedWPerSecond;
            if (AxisZ == axis) return SpeedZPerSecond;
            if (AxisB == axis) return SpeedBPerSecond;
            if (AxisC == axis) return SpeedCPerSecond;
            return 0;
        }

        internal void SetSpeed(int axis, decimal speed)
        {
            if (AxisX == axis)
            {
                SpeedX = speed;
            }
            if (AxisY == axis)
            {
                SpeedY = speed;
            }
            if (AxisZ == axis)
            {
                SpeedZ = speed;
            }
            if (AxisB == axis)
            {
                SpeedB = speed;
            }
            if (AxisC == axis)
            {
                SpeedC = speed;
            }
            if (AxisW == axis)
            {
                SpeedW = speed;
            }
        }

        public int GetWheelSpeed(int axis, int beilv)
        {
            decimal speed = 0;
            switch (axis)
            {
                case 1: speed = WheelSpeedX; break;
                case 2: speed = WheelSpeedY; break;
                case 3: speed = WheelSpeedW; break;
                case 4: speed = WheelSpeedZ; break;
                case 5: speed = WheelSpeedB; break;
                case 6: speed = WheelSpeedC; break;
            }
            return (int)speed;// *beilv / 100;
        }

        internal bool IsNotIgnore(int axis)
        {
            switch (axis)
            {
                case 1: return !this.IgnoreX;
                case 2: return !this.IgnoreY;
                case 3: return !this.IgnoreW;
                case 4: return !this.IgnoreZ;
                case 5: return !this.IgnoreB;
                case 6: return !this.IgnoreC;
            }
            return false;
        }

        public decimal GetResolution(string axisType)
        {
            switch (axisType)
            {
                case "X": return this.XResolution;
                case "Y": return this.YResolution;
                case "W": return this.WResolution;
                case "A": return this.AResolution;
                case "B": return this.BResolution;
                case "C": return this.CResolution;
                case "Z": return this.ZResolution;
            }
            return 1;
        }

        public decimal GetResolution(int axis)
        {
            if (this.AxisX == axis) return this.XResolution;
            if (this.AxisY == axis) return this.YResolution;
            if (this.AxisW == axis) return this.WResolution;
            if (this.AxisZ == axis) return this.AResolution;
            if (this.AxisB == axis) return this.BResolution;
            if (this.AxisC == axis) return this.CResolution;
            return this.ZResolution;
        }
    }
}
