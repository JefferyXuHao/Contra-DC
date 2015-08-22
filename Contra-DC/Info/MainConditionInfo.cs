using System;
using System.Collections.Generic;
using System.Text;

namespace Card
{
    public class MainConditionInfo
    {
        private double m_nPulseX;
        /// <summary>
        /// X默认目标位置
        /// </summary>
        public double NPulseX
        {
            get { return m_nPulseX; }
            set { m_nPulseX = value; }
        }

        private double m_nPulseY;
        /// <summary>
        /// Y默认目标位置
        /// </summary>
        public double NPulseY
        {
            get { return m_nPulseY; }
            set { m_nPulseY = value; }
        }

        /// <summary>
        /// 步进长度
        /// </summary>
        public int IStep
        {
            get
            {
                if (isA) return 10;
                else if (isB) return 100;
                else if (isC) return 1000;
                //else if (isD) return 10000;
                return 10;
            }
        }

        private int m_nSpeedX;
        /// <summary>
        /// 驱动速度
        /// </summary>
        public int NSpeedX
        {
            get { return m_nSpeedX; }
            set { m_nSpeedX = value; }
        }

        private double x;
        /// <summary>
        /// X坐标
        /// </summary>
        public double X
        {
            get { return x; }
            set { x = value; }
        }

        private double y;
        /// <summary>
        /// Y坐标
        /// </summary>
        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        private bool isA = true;
        /// <summary>
        /// 0.01mm
        /// </summary>
        public bool IsA
        {
            get { return isA; }
            set { isA = value;            
            }
        }

        private bool isB;
        /// <summary>
        /// 0.1mm
        /// </summary>
        public bool IsB
        {
            get { return isB; }
            set { isB = value; }
        }

        private bool isC;
        /// <summary>
        /// 1mm
        /// </summary>
        public bool IsC
        {
            get { return isC; }
            set { isC = value; }
        }

        private bool isD;
        /// <summary>
        /// 10mm
        /// </summary>
        public bool IsD
        {
            get { return isD; }
            set { isD = value; }
        }

        private bool limitX;
        /// <summary>
        /// X负限位
        /// </summary>
        public bool LimitX
        {
            get { return limitX; }
            set { limitX = value; }
        }

        private bool limitY;
        /// <summary>
        /// Y负限位
        /// </summary>
        public bool LimitY
        {
            get { return limitY; }
            set { limitY = value; }
        }

        private bool limitX2;
        /// <summary>
        /// X正限位
        /// </summary>
        public bool LimitX2
        {
            get { return limitX2; }
            set { limitX2 = value; }
        }

        private bool limitY2;
        /// <summary>
        /// Y正限位
        /// </summary>
        public bool LimitY2
        {
            get { return limitY2; }
            set { limitY2 = value; }
        }

        private int m_nStartvX;
        /// <summary>
        /// X初始速度
        /// </summary>
        public int NStartvX
        {
            get { return m_nStartvX; }
            set { m_nStartvX = value; }
        }

        private int m_nStartvY;
        /// <summary>
        /// Y初始速度
        /// </summary>
        public int NStartvY
        {
            get { return m_nStartvY; }
            set { m_nStartvY = value; }
        }

        private double m_dTaccX;
        /// <summary>
        /// X加速时间
        /// </summary>
        public double DTaccX
        {
            get { return m_dTaccX; }
            set { m_dTaccX = value; }
        }

        private double m_dTaccY;
        /// <summary>
        /// Y加速时间
        /// </summary>
        public double DTaccY
        {
            get { return m_dTaccY; }
            set { m_dTaccY = value; }
        }

        private int m_iFrequency_1;
        /// <summary>
        /// 1变频器档位
        /// </summary>
        public int IFrequency_1
        {
            get { return m_iFrequency_1; }
            set { m_iFrequency_1 = value; }
        }

        private int m_iFrequency_2;
        /// <summary>
        /// 2变频器档位
        /// </summary>
        public int IFrequency_2
        {
            get { return m_iFrequency_2; }
            set { m_iFrequency_2 = value; }
        }

        private int m_nAddX;
        /// <summary>
        /// X默认加速度
        /// </summary>
        public int NAddX
        {
            get { return m_nAddX; }
            set { m_nAddX = value; }
        }

        private int m_nAddY;
        /// <summary>
        /// Y默认加速度
        /// </summary>
        public int NAddY
        {
            get { return m_nAddY; }
            set { m_nAddY = value; }
        }

        /// <summary>
        /// 速度
        /// </summary>
        public int TempSpeed
        {
            get { return this.NSpeedX * 1000 / 60; }
        }
        /// <summary>
        /// 临时默认目标X位置
        /// </summary>
        public int TempX
        {
            get { return (int)(this.NPulseX * 1000); ; }
        }
        /// <summary>
        /// 临时默认目标Y位置
        /// </summary>
        public int TempY
        {
            get { return (int)(this.NPulseY * 1000); ; }
        }


        private bool isStep11;

        public bool IsStep11
        {
            get { return isStep11; }
            set { isStep11 = value; }
        }
        private bool isStep12;

        public bool IsStep12
        {
            get { return isStep12; }
            set { isStep12 = value; }
        }
        private bool isStep13;

        public bool IsStep13
        {
            get { return isStep13; }
            set { isStep13 = value; }
        }
        private bool isStep14;

        public bool IsStep14
        {
            get { return isStep14; }
            set { isStep14 = value; }
        }

        private bool isStep21;

        public bool IsStep21
        {
            get { return isStep21; }
            set { isStep21 = value; }
        }
        private bool isStep22;

        public bool IsStep22
        {
            get { return isStep22; }
            set { isStep22 = value; }
        }
        private bool isStep23;

        public bool IsStep23
        {
            get { return isStep23; }
            set { isStep23 = value; }
        }
        private bool isStep24;

        public bool IsStep24
        {
            get { return isStep24; }
            set { isStep24 = value; }
        }

        public int Frequency1
        {
            get { if (IsStep11) return 0;
            if (IsStep12) return 1;
            if (IsStep13) return 2;
            if (IsStep14) return 3;
            return 0;
            }
        }

        public int Frequency2
        {
            get
            {
                if (IsStep21) return 0;
                if (IsStep22) return 1;
                if (IsStep23) return 2;
                if (IsStep24) return 3;
                return 0;
            }
        }

        private bool isOut0;

        public bool IsOut0
        {
            get { return isOut0; }
            set { isOut0 = value; }
        }
        private bool isOut4;

        public bool IsOut4
        {
            get { return isOut4; }
            set { isOut4 = value; }
        }
        private bool isOut8;

        public bool IsOut8
        {
            get { return isOut8; }
            set { isOut8 = value; }
        }
        private bool isOut9;

        public bool IsOut9
        {
            get { return isOut9; }
            set { isOut9 = value; }
        }


        //private bool twiceUp;

        //public bool TwiceUp
        //{
        //    get { return twiceUp; }
        //    set { twiceUp = value; }
        //}

        //private bool twiceDown;

        //public bool TwiceDown
        //{
        //    get { return twiceDown; }
        //    set { twiceDown = value; }
        //}
    }
}
