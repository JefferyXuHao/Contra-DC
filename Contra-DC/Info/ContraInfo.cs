using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using ContraLibrary;

namespace Contra
{
    public class ContraInfo
    {
        public ContraInfo()
        {
            this.StartSpeed = 1000;
            this.AddSpeed = 10000;
            this.AddSpeedTime = 0.1;
            this.StepLength = ContraHelper.Step1;
            this.LogPosA = decimal.Zero;
            this.LogPosB = decimal.Zero;
            this.LogPosW = decimal.Zero;
            this.LogPosX = decimal.Zero;
            this.LogPosW = decimal.Zero;
            this.IsSetZZero = false;
        }

        public bool IsSetZZero { get; set; }

        #region 速度相关
        public int StartSpeed { get; set; }
        public int AddSpeed { get; set; }
        public double AddSpeedTime { get; set; }
        #endregion

        #region GetActPos
        public decimal GetActPos(int axis, string axisType, AxisSetInfo axisSet)
        {
            if (axis == axisSet.AxisX)
            {
                return GetActPosX(axisType);
            }
            if (axis == axisSet.AxisY)
            {
                return GetActPosY(axisType);
            }
            if (axis == axisSet.AxisW)
            {
                return GetActPosW(axisType);
            }
            if (axis == axisSet.AxisZ)
            {
                return GetActPosZ(axisType);
            }
            if (axis == axisSet.AxisB)
            {
                return GetActPosB(axisType);
            }
            if (axis == axisSet.AxisC)
            {
                return GetActPosC(axisType);
            }
            return 0;
        }

        public decimal GetActPosX(string axisType)
        {
            switch (axisType)
            {
                case HeadType.G54: return this.ActPosX;
                case HeadType.G55: return this.ActPosX55;
                case HeadType.G56: return this.ActPosX56;
                case HeadType.G57: return this.ActPosX57;
                case HeadType.G58: return this.ActPosX58;
                case HeadType.G59: return this.ActPosX59;

                case HeadType.G60: return this.ActPosX60;
                case HeadType.G61: return this.ActPosX61;
                case HeadType.G62: return this.ActPosX62;
                case HeadType.G63: return this.ActPosX63;
                case HeadType.G64: return this.ActPosX64;
                case HeadType.G65: return this.ActPosX65;

            }
            return 0;
        }

        public decimal GetActPosY(string axisType)
        {
            switch (axisType)
            {
                case HeadType.G54: return this.ActPosY;
                case HeadType.G55: return this.ActPosY55;
                case HeadType.G56: return this.ActPosY56;
                case HeadType.G57: return this.ActPosY57;
                case HeadType.G58: return this.ActPosY58;
                case HeadType.G59: return this.ActPosY59;

                case HeadType.G60: return this.ActPosY60;
                case HeadType.G61: return this.ActPosY61;
                case HeadType.G62: return this.ActPosY62;
                case HeadType.G63: return this.ActPosY63;
                case HeadType.G64: return this.ActPosY64;
                case HeadType.G65: return this.ActPosY65;
            }
            return 0;
        }

        public decimal GetActPosW(string axisType)
        {
            switch (axisType)
            {
                case HeadType.G54: return this.ActPosW;
                case HeadType.G55: return this.ActPosW55;
                case HeadType.G56: return this.ActPosW56;
                case HeadType.G57: return this.ActPosW57;
                case HeadType.G58: return this.ActPosW58;
                case HeadType.G59: return this.ActPosW59;

                case HeadType.G60: return this.ActPosW60;
                case HeadType.G61: return this.ActPosW61;
                case HeadType.G62: return this.ActPosW62;
                case HeadType.G63: return this.ActPosW63;
                case HeadType.G64: return this.ActPosW64;
                case HeadType.G65: return this.ActPosW65;
            }
            return 0;
        }

        public decimal GetActPosA(string axisType)
        {
            switch (axisType)
            {
                case HeadType.G54: return this.ActPosA;
                case HeadType.G55: return this.ActPosA55;
                case HeadType.G56: return this.ActPosA56;
                case HeadType.G57: return this.ActPosA57;
                case HeadType.G58: return this.ActPosA58;
                case HeadType.G59: return this.ActPosA59;

                case HeadType.G60: return this.ActPosA60;
                case HeadType.G61: return this.ActPosA61;
                case HeadType.G62: return this.ActPosA62;
                case HeadType.G63: return this.ActPosA63;
                case HeadType.G64: return this.ActPosA64;
                case HeadType.G65: return this.ActPosA65;
            }
            return 0;
        }

        public decimal GetActPosB(string axisType)
        {
            switch (axisType)
            {
                case HeadType.G54: return this.ActPosB;
                case HeadType.G55: return this.ActPosB55;
                case HeadType.G56: return this.ActPosB56;
                case HeadType.G57: return this.ActPosB57;
                case HeadType.G58: return this.ActPosB58;
                case HeadType.G59: return this.ActPosB59;

                case HeadType.G60: return this.ActPosB60;
                case HeadType.G61: return this.ActPosB61;
                case HeadType.G62: return this.ActPosB62;
                case HeadType.G63: return this.ActPosB63;
                case HeadType.G64: return this.ActPosB64;
                case HeadType.G65: return this.ActPosB65;
            }
            return 0;
        }

        public decimal GetActPosC(string axisType)
        {
            switch (axisType)
            {
                case HeadType.G54: return this.ActPosC;
                case HeadType.G55: return this.ActPosC55;
                case HeadType.G56: return this.ActPosC56;
                case HeadType.G57: return this.ActPosC57;
                case HeadType.G58: return this.ActPosC58;
                case HeadType.G59: return this.ActPosC59;

                case HeadType.G60: return this.ActPosC60;
                case HeadType.G61: return this.ActPosC61;
                case HeadType.G62: return this.ActPosC62;
                case HeadType.G63: return this.ActPosC63;
                case HeadType.G64: return this.ActPosC64;
                case HeadType.G65: return this.ActPosC65;
            }
            return 0;
        }

        public decimal GetActPosZ(string axisType)
        {
            switch (axisType)
            {
                case HeadType.G54: return this.ActPosZ;
                case HeadType.G55: return this.ActPosZ55;
                case HeadType.G56: return this.ActPosZ56;
                case HeadType.G57: return this.ActPosZ57;
                case HeadType.G58: return this.ActPosZ58;
                case HeadType.G59: return this.ActPosZ59;

                case HeadType.G60: return this.ActPosZ60;
                case HeadType.G61: return this.ActPosZ61;
                case HeadType.G62: return this.ActPosZ62;
                case HeadType.G63: return this.ActPosZ63;
                case HeadType.G64: return this.ActPosZ64;
                case HeadType.G65: return this.ActPosZ65;
            }
            return 0;
        }
        #endregion

        #region SetActPos
        public void SetActPosX(string axisType, decimal value)
        {
            switch (axisType)
            {
                case HeadType.G54: this.TempLogPosX += value - this.ActPosX; break;
                case HeadType.G55: this.TempLogPosX55 += value - this.ActPosX55; break;
                case HeadType.G56: this.TempLogPosX56 += value - this.ActPosX56; break;
                case HeadType.G57: this.TempLogPosX57 += value - this.ActPosX57; break;
                case HeadType.G58: this.TempLogPosX58 += value - this.ActPosX58; break;
                case HeadType.G59: this.TempLogPosX59 += value - this.ActPosX59; break;
                case HeadType.G60: this.TempLogPosX60 += value - this.ActPosX60; break;
                case HeadType.G61: this.TempLogPosX61 += value - this.ActPosX61; break;
                case HeadType.G62: this.TempLogPosX62 += value - this.ActPosX62; break;
                case HeadType.G63: this.TempLogPosX63 += value - this.ActPosX63; break;
                case HeadType.G64: this.TempLogPosX64 += value - this.ActPosX64; break;
                case HeadType.G65: this.TempLogPosX65 += value - this.ActPosX65; break;
            }
        }

        public void SetActPosY(string axisType, decimal value)
        {
            switch (axisType)
            {
                case HeadType.G54: this.TempLogPosY += value - this.ActPosY; break;
                case HeadType.G55: this.TempLogPosY55 += value - this.ActPosY55; break;
                case HeadType.G56: this.TempLogPosY56 += value - this.ActPosY56; break;
                case HeadType.G57: this.TempLogPosY57 += value - this.ActPosY57; break;
                case HeadType.G58: this.TempLogPosY58 += value - this.ActPosY58; break;
                case HeadType.G59: this.TempLogPosY59 += value - this.ActPosY59; break;

                case HeadType.G60: this.TempLogPosY60 += value - this.ActPosY60; break;
                case HeadType.G61: this.TempLogPosY61 += value - this.ActPosY61; break;
                case HeadType.G62: this.TempLogPosY62 += value - this.ActPosY62; break;
                case HeadType.G63: this.TempLogPosY63 += value - this.ActPosY63; break;
                case HeadType.G64: this.TempLogPosY64 += value - this.ActPosY64; break;
                case HeadType.G65: this.TempLogPosY65 += value - this.ActPosY65; break;
            }
        }

        public void SetActPosW(string axisType, decimal value)
        {
            switch (axisType)
            {
                case HeadType.G54: this.TempLogPosW += value - this.ActPosW; break;
                case HeadType.G55: this.TempLogPosW55 += value - this.ActPosW55; break;
                case HeadType.G56: this.TempLogPosW56 += value - this.ActPosW56; break;
                case HeadType.G57: this.TempLogPosW57 += value - this.ActPosW57; break;
                case HeadType.G58: this.TempLogPosW58 += value - this.ActPosW58; break;
                case HeadType.G59: this.TempLogPosW59 += value - this.ActPosW59; break;

                case HeadType.G60: this.TempLogPosW60 += value - this.ActPosW60; break;
                case HeadType.G61: this.TempLogPosW61 += value - this.ActPosW61; break;
                case HeadType.G62: this.TempLogPosW62 += value - this.ActPosW62; break;
                case HeadType.G63: this.TempLogPosW63 += value - this.ActPosW63; break;
                case HeadType.G64: this.TempLogPosW64 += value - this.ActPosW64; break;
                case HeadType.G65: this.TempLogPosW65 += value - this.ActPosW65; break;
            }
        }

        public void SetActPosB(string axisType, decimal value)
        {
            switch (axisType)
            {
                case HeadType.G54: this.TempLogPosB += value - this.ActPosB; break;
                case HeadType.G55: this.TempLogPosB55 += value - this.ActPosB55; break;
                case HeadType.G56: this.TempLogPosB56 += value - this.ActPosB56; break;
                case HeadType.G57: this.TempLogPosB57 += value - this.ActPosB57; break;
                case HeadType.G58: this.TempLogPosB58 += value - this.ActPosB58; break;
                case HeadType.G59: this.TempLogPosB59 += value - this.ActPosB59; break;

                case HeadType.G60: this.TempLogPosB60 += value - this.ActPosB60; break;
                case HeadType.G61: this.TempLogPosB61 += value - this.ActPosB61; break;
                case HeadType.G62: this.TempLogPosB62 += value - this.ActPosB62; break;
                case HeadType.G63: this.TempLogPosB63 += value - this.ActPosB63; break;
                case HeadType.G64: this.TempLogPosB64 += value - this.ActPosB64; break;
                case HeadType.G65: this.TempLogPosB65 += value - this.ActPosB65; break;
            }
        }

        public void SetActPosC(string axisType, decimal value)
        {
            switch (axisType)
            {
                case HeadType.G54: this.TempLogPosC += value - this.ActPosC; break;
                case HeadType.G55: this.TempLogPosC55 += value - this.ActPosC55; break;
                case HeadType.G56: this.TempLogPosC56 += value - this.ActPosC56; break;
                case HeadType.G57: this.TempLogPosC57 += value - this.ActPosC57; break;
                case HeadType.G58: this.TempLogPosC58 += value - this.ActPosC58; break;
                case HeadType.G59: this.TempLogPosC59 += value - this.ActPosC59; break;

                case HeadType.G60: this.TempLogPosC60 += value - this.ActPosC60; break;
                case HeadType.G61: this.TempLogPosC61 += value - this.ActPosC61; break;
                case HeadType.G62: this.TempLogPosC62 += value - this.ActPosC62; break;
                case HeadType.G63: this.TempLogPosC63 += value - this.ActPosC63; break;
                case HeadType.G64: this.TempLogPosC64 += value - this.ActPosC64; break;
                case HeadType.G65: this.TempLogPosC65 += value - this.ActPosC65; break;
            }
        }

        public void SetActPosZ(string axisType, decimal value)
        {
            switch (axisType)
            {
                case HeadType.G54: this.TempLogPosZ += value - this.ActPosZ; break;
                case HeadType.G55: this.TempLogPosZ55 += value - this.ActPosZ55; break;
                case HeadType.G56: this.TempLogPosZ56 += value - this.ActPosZ56; break;
                case HeadType.G57: this.TempLogPosZ57 += value - this.ActPosZ57; break;
                case HeadType.G58: this.TempLogPosZ58 += value - this.ActPosZ58; break;
                case HeadType.G59: this.TempLogPosZ59 += value - this.ActPosZ59; break;

                case HeadType.G60: this.TempLogPosZ60 += value - this.ActPosZ60; break;
                case HeadType.G61: this.TempLogPosZ61 += value - this.ActPosZ61; break;
                case HeadType.G62: this.TempLogPosZ62 += value - this.ActPosZ62; break;
                case HeadType.G63: this.TempLogPosZ63 += value - this.ActPosZ63; break;
                case HeadType.G64: this.TempLogPosZ64 += value - this.ActPosZ64; break;
                case HeadType.G65: this.TempLogPosZ65 += value - this.ActPosZ65; break;
            }
        }
        #endregion

        #region IsPlus
        private bool isXPlus = true;
        private bool isYPlus = true;
        private bool isWPlus = true;
        private bool isAPlus = true;
        private bool isBPlus = true;
        private bool isCPlus = true;
        #endregion

        #region G54
        public decimal ActPosX { get { return this.LogPosX + TempLogPosX; } }
        public decimal ActPosY { get { return this.LogPosY + TempLogPosY; } }
        public decimal ActPosW { get { return this.LogPosW + TempLogPosW; } }
        public decimal ActPosA { get { return this.LogPosA + TempLogPosA; } }
        public decimal ActPosB { get { return this.LogPosB + TempLogPosB; } }
        public decimal ActPosC { get { return this.LogPosC + TempLogPosC; } }
        public decimal ActPosZ { get { return this.LogPosZ + TempLogPosZ; } }

        private decimal logPosX;
        public decimal LogPosX
        {
            get { return decimal.Round(logPosX, 3); }
            set
            {
                var v = decimal.Round(value, 3);
                isXPlus = v >= logPosX;
                this.logPosX = decimal.Round(value, 3);
            }
        }

        private decimal logPosY;
        public decimal LogPosY
        {
            get { return decimal.Round(logPosY, 3); }
            set
            {
                var v = decimal.Round(value, 3);
                isYPlus = v >= logPosY;
                this.logPosY = decimal.Round(value, 3);
            }
        }

        private decimal logPosW;
        public decimal LogPosW
        {
            get { return decimal.Round(logPosW, 3); }
            set
            {
                var v = decimal.Round(value, 3);
                isWPlus = v >= logPosW;
                this.logPosW = decimal.Round(value, 3);
            }
        }

        private decimal logPosA;
        public decimal LogPosA
        {
            get { return decimal.Round(logPosA, 3); }
            set
            {
                var v = decimal.Round(value, 3);
                isAPlus = v >= logPosA;
                this.logPosA = decimal.Round(value, 3);
            }
        }

        private decimal logPosB;
        public decimal LogPosB
        {
            get { return decimal.Round(logPosB, 3); }
            set
            {
                var v = decimal.Round(value, 3);
                isBPlus = v >= logPosB;
                this.logPosB = decimal.Round(value, 3);
            }
        }

        private decimal logPosC;
        public decimal LogPosC
        {
            get { return decimal.Round(logPosC, 3); }
            set
            {
                var v = decimal.Round(value, 3);
                isCPlus = v >= logPosC;
                this.logPosC = decimal.Round(value, 3);
            }
        }

        private decimal logPosZ;
        public decimal LogPosZ
        {
            get { return decimal.Round(logPosZ, 3); }
            set { this.logPosZ = decimal.Round(value, 3); }
        }

        public decimal TempLogPosX { get; set; }
        public decimal TempLogPosY { get; set; }
        public decimal TempLogPosW { get; set; }
        public decimal TempLogPosA { get; set; }
        public decimal TempLogPosB { get; set; }
        public decimal TempLogPosC { get; set; }
        public decimal TempLogPosZ { get; set; }
        #endregion

        #region G55
        public decimal ActPosX55 { get { return this.LogPosX + TempLogPosX55; } }
        public decimal ActPosY55 { get { return this.LogPosY + TempLogPosY55; } }
        public decimal ActPosW55 { get { return this.LogPosW + TempLogPosW55; } }
        public decimal ActPosA55 { get { return this.LogPosA + TempLogPosA55; } }
        public decimal ActPosB55 { get { return this.LogPosB + TempLogPosB55; } }
        public decimal ActPosC55 { get { return this.LogPosC + TempLogPosC55; } }
        public decimal ActPosZ55 { get { return this.LogPosZ + TempLogPosZ55; } }

        public decimal TempLogPosX55 { get; set; }
        public decimal TempLogPosY55 { get; set; }
        public decimal TempLogPosW55 { get; set; }
        public decimal TempLogPosA55 { get; set; }
        public decimal TempLogPosB55 { get; set; }
        public decimal TempLogPosC55 { get; set; }
        public decimal TempLogPosZ55 { get; set; }
        #endregion

        #region G56
        public decimal ActPosX56 { get { return this.LogPosX + TempLogPosX56; } }
        public decimal ActPosY56 { get { return this.LogPosY + TempLogPosY56; } }
        public decimal ActPosW56 { get { return this.LogPosW + TempLogPosW56; } }
        public decimal ActPosA56 { get { return this.LogPosA + TempLogPosA56; } }
        public decimal ActPosB56 { get { return this.LogPosB + TempLogPosB56; } }
        public decimal ActPosC56 { get { return this.LogPosC + TempLogPosC56; } }
        public decimal ActPosZ56 { get { return this.LogPosZ + TempLogPosZ56; } }

        public decimal TempLogPosX56 { get; set; }
        public decimal TempLogPosY56 { get; set; }
        public decimal TempLogPosW56 { get; set; }
        public decimal TempLogPosA56 { get; set; }
        public decimal TempLogPosB56 { get; set; }
        public decimal TempLogPosC56 { get; set; }
        public decimal TempLogPosZ56 { get; set; }
        #endregion

        #region G57
        public decimal ActPosX57 { get { return this.LogPosX + TempLogPosX57; } }
        public decimal ActPosY57 { get { return this.LogPosY + TempLogPosY57; } }
        public decimal ActPosW57 { get { return this.LogPosW + TempLogPosW57; } }
        public decimal ActPosA57 { get { return this.LogPosA + TempLogPosA57; } }
        public decimal ActPosB57 { get { return this.LogPosB + TempLogPosB57; } }
        public decimal ActPosC57 { get { return this.LogPosC + TempLogPosC57; } }
        public decimal ActPosZ57 { get { return this.LogPosZ + TempLogPosZ57; } }

        public decimal TempLogPosX57 { get; set; }
        public decimal TempLogPosY57 { get; set; }
        public decimal TempLogPosW57 { get; set; }
        public decimal TempLogPosA57 { get; set; }
        public decimal TempLogPosB57 { get; set; }
        public decimal TempLogPosC57 { get; set; }
        public decimal TempLogPosZ57 { get; set; }
        #endregion

        #region G58
        public decimal ActPosX58 { get { return this.LogPosX + TempLogPosX58; } }
        public decimal ActPosY58 { get { return this.LogPosY + TempLogPosY58; } }
        public decimal ActPosW58 { get { return this.LogPosW + TempLogPosW58; } }
        public decimal ActPosA58 { get { return this.LogPosA + TempLogPosA58; } }
        public decimal ActPosB58 { get { return this.LogPosB + TempLogPosB58; } }
        public decimal ActPosC58 { get { return this.LogPosC + TempLogPosC58; } }
        public decimal ActPosZ58 { get { return this.LogPosZ + TempLogPosZ58; } }

        public decimal TempLogPosX58 { get; set; }
        public decimal TempLogPosY58 { get; set; }
        public decimal TempLogPosW58 { get; set; }
        public decimal TempLogPosA58 { get; set; }
        public decimal TempLogPosB58 { get; set; }
        public decimal TempLogPosC58 { get; set; }
        public decimal TempLogPosZ58 { get; set; }
        #endregion

        #region G59
        public decimal ActPosX59 { get { return this.LogPosX + TempLogPosX59; } }
        public decimal ActPosY59 { get { return this.LogPosY + TempLogPosY59; } }
        public decimal ActPosW59 { get { return this.LogPosW + TempLogPosW59; } }
        public decimal ActPosA59 { get { return this.LogPosA + TempLogPosA59; } }
        public decimal ActPosB59 { get { return this.LogPosB + TempLogPosB59; } }
        public decimal ActPosC59 { get { return this.LogPosC + TempLogPosC59; } }
        public decimal ActPosZ59 { get { return this.LogPosZ + TempLogPosZ59; } }

        public decimal TempLogPosX59 { get; set; }
        public decimal TempLogPosY59 { get; set; }
        public decimal TempLogPosW59 { get; set; }
        public decimal TempLogPosA59 { get; set; }
        public decimal TempLogPosB59 { get; set; }
        public decimal TempLogPosC59 { get; set; }
        public decimal TempLogPosZ59 { get; set; }
        #endregion

        #region G60
        public decimal ActPosX60 { get { return this.LogPosX + TempLogPosX60; } }
        public decimal ActPosY60 { get { return this.LogPosY + TempLogPosY60; } }
        public decimal ActPosW60 { get { return this.LogPosW + TempLogPosW60; } }
        public decimal ActPosA60 { get { return this.LogPosA + TempLogPosA60; } }
        public decimal ActPosB60 { get { return this.LogPosB + TempLogPosB60; } }
        public decimal ActPosC60 { get { return this.LogPosC + TempLogPosC60; } }
        public decimal ActPosZ60 { get { return this.LogPosZ + TempLogPosZ60; } }

        public decimal TempLogPosX60 { get; set; }
        public decimal TempLogPosY60 { get; set; }
        public decimal TempLogPosW60 { get; set; }
        public decimal TempLogPosA60 { get; set; }
        public decimal TempLogPosB60 { get; set; }
        public decimal TempLogPosC60 { get; set; }
        public decimal TempLogPosZ60 { get; set; }
        #endregion

        #region G61
        public decimal ActPosX61 { get { return this.LogPosX + TempLogPosX61; } }
        public decimal ActPosY61 { get { return this.LogPosY + TempLogPosY61; } }
        public decimal ActPosW61 { get { return this.LogPosW + TempLogPosW61; } }
        public decimal ActPosA61 { get { return this.LogPosA + TempLogPosA61; } }
        public decimal ActPosB61 { get { return this.LogPosB + TempLogPosB61; } }
        public decimal ActPosC61 { get { return this.LogPosC + TempLogPosC61; } }
        public decimal ActPosZ61 { get { return this.LogPosZ + TempLogPosZ61; } }

        public decimal TempLogPosX61 { get; set; }
        public decimal TempLogPosY61 { get; set; }
        public decimal TempLogPosW61 { get; set; }
        public decimal TempLogPosA61 { get; set; }
        public decimal TempLogPosB61 { get; set; }
        public decimal TempLogPosC61 { get; set; }
        public decimal TempLogPosZ61 { get; set; }
        #endregion

        #region G62
        public decimal ActPosX62 { get { return this.LogPosX + TempLogPosX62; } }
        public decimal ActPosY62 { get { return this.LogPosY + TempLogPosY62; } }
        public decimal ActPosW62 { get { return this.LogPosW + TempLogPosW62; } }
        public decimal ActPosA62 { get { return this.LogPosA + TempLogPosA62; } }
        public decimal ActPosB62 { get { return this.LogPosB + TempLogPosB62; } }
        public decimal ActPosC62 { get { return this.LogPosC + TempLogPosC62; } }
        public decimal ActPosZ62 { get { return this.LogPosZ + TempLogPosZ62; } }

        public decimal TempLogPosX62 { get; set; }
        public decimal TempLogPosY62 { get; set; }
        public decimal TempLogPosW62 { get; set; }
        public decimal TempLogPosA62 { get; set; }
        public decimal TempLogPosB62 { get; set; }
        public decimal TempLogPosC62 { get; set; }
        public decimal TempLogPosZ62 { get; set; }
        #endregion

        #region G63
        public decimal ActPosX63 { get { return this.LogPosX + TempLogPosX63; } }
        public decimal ActPosY63 { get { return this.LogPosY + TempLogPosY63; } }
        public decimal ActPosW63 { get { return this.LogPosW + TempLogPosW63; } }
        public decimal ActPosA63 { get { return this.LogPosA + TempLogPosA63; } }
        public decimal ActPosB63 { get { return this.LogPosB + TempLogPosB63; } }
        public decimal ActPosC63 { get { return this.LogPosC + TempLogPosC63; } }
        public decimal ActPosZ63 { get { return this.LogPosZ + TempLogPosZ63; } }

        public decimal TempLogPosX63 { get; set; }
        public decimal TempLogPosY63 { get; set; }
        public decimal TempLogPosW63 { get; set; }
        public decimal TempLogPosA63 { get; set; }
        public decimal TempLogPosB63 { get; set; }
        public decimal TempLogPosC63 { get; set; }
        public decimal TempLogPosZ63 { get; set; }
        #endregion

        #region G64
        public decimal ActPosX64 { get { return this.LogPosX + TempLogPosX64; } }
        public decimal ActPosY64 { get { return this.LogPosY + TempLogPosY64; } }
        public decimal ActPosW64 { get { return this.LogPosW + TempLogPosW64; } }
        public decimal ActPosA64 { get { return this.LogPosA + TempLogPosA64; } }
        public decimal ActPosB64 { get { return this.LogPosB + TempLogPosB64; } }
        public decimal ActPosC64 { get { return this.LogPosC + TempLogPosC64; } }
        public decimal ActPosZ64 { get { return this.LogPosZ + TempLogPosZ64; } }

        public decimal TempLogPosX64 { get; set; }
        public decimal TempLogPosY64 { get; set; }
        public decimal TempLogPosW64 { get; set; }
        public decimal TempLogPosA64 { get; set; }
        public decimal TempLogPosB64 { get; set; }
        public decimal TempLogPosC64 { get; set; }
        public decimal TempLogPosZ64 { get; set; }
        #endregion

        #region G65
        public decimal ActPosX65 { get { return this.LogPosX + TempLogPosX65; } }
        public decimal ActPosY65 { get { return this.LogPosY + TempLogPosY65; } }
        public decimal ActPosW65 { get { return this.LogPosW + TempLogPosW65; } }
        public decimal ActPosA65 { get { return this.LogPosA + TempLogPosA65; } }
        public decimal ActPosB65 { get { return this.LogPosB + TempLogPosB65; } }
        public decimal ActPosC65 { get { return this.LogPosC + TempLogPosC65; } }
        public decimal ActPosZ65 { get { return this.LogPosZ + TempLogPosZ65; } }

        public decimal TempLogPosX65 { get; set; }
        public decimal TempLogPosY65 { get; set; }
        public decimal TempLogPosW65 { get; set; }
        public decimal TempLogPosA65 { get; set; }
        public decimal TempLogPosB65 { get; set; }
        public decimal TempLogPosC65 { get; set; }
        public decimal TempLogPosZ65 { get; set; }
        #endregion

        #region GetWTemp
        public decimal GetWActPos(decimal logPos, string axisType)
        {
            switch (axisType)
            {
                case "G54": return logPos + TempLogPosW;
                case "G55": return logPos + TempLogPosW55;
                case "G56": return logPos + TempLogPosW56;
                case "G57": return logPos + TempLogPosW57;
                case "G58": return logPos + TempLogPosW58;
                case "G59": return logPos + TempLogPosW59;
                case "G60": return logPos + TempLogPosW60;
                case "G61": return logPos + TempLogPosW61;
                case "G62": return logPos + TempLogPosW62;
                case "G63": return logPos + TempLogPosW63;
                case "G64": return logPos + TempLogPosW64;
                case "G65": return logPos + TempLogPosW65;
            }
            return logPos + TempLogPosW;
        }
        #endregion

        private int stepLength;
        public int StepLength
        {
            get { return stepLength; }
            set { this.stepLength = value; }
        }

        /// <summary>
        /// 获得考虑反向间隙的值
        /// </summary>
        /// <param name="axisType"></param>
        /// <param name="value"></param>
        /// <param name="value2"></param>
        /// <param name="setInfo"></param>
        /// <param name="jianxi"></param>
        /// <returns></returns>
        internal decimal GetRealValue(string axisType, decimal value, AxisSetInfo axisSet, bool flag, bool flag2, out decimal outValue)
        {
            outValue = 0;
            //if (axisType == "X" && flag)
            //{
            //    if (flag2)
            //    {
            //        value -= axisSet.JianxiX;
            //        outValue = axisSet.JianxiX;
            //    }
            //    else
            //    {
            //        value += axisSet.JianxiX;
            //        outValue = 0 - axisSet.JianxiX;
            //    }
            //}
            //if (axisType == "Y" && flag)
            //{
            //    if (flag2)
            //    {
            //        value -= axisSet.JianxiY;
            //        outValue = axisSet.JianxiY;
            //    }
            //    else
            //    {
            //        value += axisSet.JianxiY;
            //        outValue = 0 - axisSet.JianxiY;
            //    }
            //}
            //if (axisType == "W" && flag)
            //{
            //    if (flag2)
            //    {
            //        value -= axisSet.JianxiW;
            //        outValue = axisSet.JianxiW;
            //    }
            //    else
            //    {
            //        value += axisSet.JianxiW;
            //        outValue = 0 - axisSet.JianxiW;
            //    }
            //}
            //if (axisType == "Z" && flag)
            //{
            //    if (flag2)
            //    {
            //        value -= axisSet.JianxiZ;
            //        outValue = axisSet.JianxiZ;
            //    }
            //    else
            //    {
            //        value += axisSet.JianxiZ;
            //        outValue = 0 - axisSet.JianxiZ;
            //    }
            //}
            //if (axisType == "B" && flag)
            //{
            //    if (flag2)
            //    {
            //        value -= axisSet.JianxiB;
            //        outValue = axisSet.JianxiB;
            //    }
            //    else
            //    {
            //        value += axisSet.JianxiB;
            //        outValue = 0 - axisSet.JianxiB;
            //    }
            //}
            //if (axisType == "C" && flag)
            //{
            //    if (flag2)
            //    {
            //        value -= axisSet.JianxiC;
            //        outValue = axisSet.JianxiC;
            //    }
            //    else
            //    {
            //        value += axisSet.JianxiC;
            //        outValue = 0 - axisSet.JianxiC;
            //    }
            //}
            return value;
        }

        internal decimal GetJianXiValue(string axisType, decimal value, decimal value2, AxisSetInfo axisSet)
        {
            //if (axisType == "X")
            //{
            //    if (isXPlus && value < value2)
            //    {
            //        return axisSet.JianxiX;
            //    }
            //    else if (!isXPlus && value >= value2)
            //    {
            //        return 0 - axisSet.JianxiX;
            //    }
            //}
            //if (axisType == "Y")
            //{
            //    if (isYPlus && value < value2)
            //    {
            //        return axisSet.JianxiY;
            //    }
            //    else if (!isYPlus && value >= value2)
            //    {
            //        return 0 - axisSet.JianxiY;
            //    }
            //}
            //if (axisType == "W")
            //{
            //    if (isWPlus && value < value2)
            //    {
            //        return axisSet.JianxiW;
            //    }
            //    else if (!isWPlus && value >= value2)
            //    {
            //        return 0 - axisSet.JianxiW;
            //    }
            //}
            //if (axisType == "Z")
            //{
            //    if (isAPlus && value < value2)
            //    {
            //        return axisSet.JianxiZ;
            //    }
            //    else if (!isAPlus && value >= value2)
            //    {
            //        return 0 - axisSet.JianxiZ;
            //    }
            //}
            //if (axisType == "B")
            //{
            //    if (isBPlus && value < value2)
            //    {
            //        return axisSet.JianxiB;
            //    }
            //    else if (!isBPlus && value >= value2)
            //    {
            //        return 0 - axisSet.JianxiB;
            //    }
            //}
            return 0;
        }

        public void ZeroZ(decimal zeroHeight)
        {
            this.TempLogPosZ += -this.ActPosZ + zeroHeight;
            this.TempLogPosZ55 += -this.ActPosZ55 + zeroHeight;
            this.TempLogPosZ56 += -this.ActPosZ56 + zeroHeight;
            this.TempLogPosZ57 += -this.ActPosZ57 + zeroHeight;
            this.TempLogPosZ58 += -this.ActPosZ58 + zeroHeight;
            this.TempLogPosZ59 += -this.ActPosZ59 + zeroHeight;

            this.TempLogPosZ60 += -this.ActPosZ60 + zeroHeight;
            this.TempLogPosZ61 += -this.ActPosZ61 + zeroHeight;
            this.TempLogPosZ62 += -this.ActPosZ62 + zeroHeight;
            this.TempLogPosZ63 += -this.ActPosZ63 + zeroHeight;
            this.TempLogPosZ64 += -this.ActPosZ64 + zeroHeight;
            this.TempLogPosZ65 += -this.ActPosZ65 + zeroHeight;
        }

        #region W安全高度
        public bool UseSafeHeight { get; set; }

        public decimal SafeHeight { get; set; }
        #endregion

        #region 检测W安全高度
        public decimal LNSCheckSafeWHeight { get; set; }
        #endregion

        #region 加工超时
        public int JiaGongOverTime
        {
            get;
            set;
        }
        #endregion
    }
}
