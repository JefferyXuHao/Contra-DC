using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using ContraLibrary;

namespace Contra
{
    public class AbsolutePosSetInfo : BaseSetInfo
    {
        private string[] fushiStartCodes = new string[] { "01", "02", "03", "04", "05" };

        public AbsolutePosSetInfo()
        {
            PartXNo = 1;
            PartYNo = 2;
            PartWNo = 3;
            PartBNo = 4;
            PartCNo = 5;
        }

        public bool UseAbsolutePos { get; set; }

        public decimal BCircleSingle { get; set; }
        public decimal BCircleDouble { get; set; }
        public decimal CCircleSingle { get; set; }
        public decimal CCircleDouble { get; set; }

        public decimal BCircleSingleCurrent { get; set; }
        public decimal BCircleDoubleCurrent { get; set; }
        public decimal CCircleSingleCurrent { get; set; }
        public decimal CCircleDoubleCurrent { get; set; }

        public bool IsBBatteryWarning { get; set; }
        public bool IsCBatteryWarning { get; set; }

        public void ReadData(string msg)
        {
            if (msg != null)
            {
                try
                {
                    if (msg.StartsWith("0B00")) //B轴
                    {
                        string value1 = msg.Substring(14, 2);
                        string value2 = msg.Substring(16, 2);
                        string value3 = msg.Substring(18, 2);
                        string value4 = msg.Substring(20, 2);
                        string value5 = msg.Substring(22, 2);
                        string valueWarning = msg.Substring(10, 4);
                        IsBBatteryWarning = valueWarning != "0000";
                        BCircleSingleCurrent = int.Parse(value3 + value2 + value1, NumberStyles.HexNumber);
                        BCircleDoubleCurrent = int.Parse(value5 + value4, NumberStyles.HexNumber);
                    }
                    else
                    {
                        string value1 = msg.Substring(14, 2);
                        string value2 = msg.Substring(16, 2);
                        string value3 = msg.Substring(18, 2);
                        string value4 = msg.Substring(20, 2);
                        string value5 = msg.Substring(22, 2);
                        string valueWarning = msg.Substring(10, 4);
                        IsCBatteryWarning = valueWarning != "0000";
                        CCircleSingleCurrent = int.Parse(value3 + value2 + value1, NumberStyles.HexNumber);
                        CCircleDoubleCurrent = int.Parse(value5 + value4, NumberStyles.HexNumber);
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.LogError(ex);
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public decimal GetBValue()
        {
            var bCircleDouble = BCircleDouble > 32768 ? (-65536 + BCircleDouble) : BCircleDouble;
            var bCircleDoubleCurrent = BCircleDoubleCurrent > 32768 ? (-65536 + BCircleDoubleCurrent) : BCircleDoubleCurrent;

            return (bCircleDoubleCurrent - bCircleDouble) * 4 + (BCircleSingleCurrent - BCircleSingle) / 131072 * 4;
        }

        public decimal GetCValue()
        {
            var cCircleDouble = CCircleDouble > 32768 ? (-65536 + CCircleDouble) : CCircleDouble;
            var cCircleDoubleCurrent = CCircleDoubleCurrent > 32768 ? (-65536 + CCircleDoubleCurrent) : CCircleDoubleCurrent;

            return (cCircleDoubleCurrent - cCircleDouble) * 36 + (CCircleSingleCurrent - CCircleSingle) / 131072 * 36;
        }

        //使用富士绝对编码器
        public bool UseFushiAbsolutePos { get; set; }

        public bool UsePartX { get; set; }

        public bool UsePartY { get; set; }

        public bool UsePartW { get; set; }

        public bool UsePartB { get; set; }

        public bool UsePartC { get; set; }

        //局号X
        public int PartXNo { get; set; }
        //局号Y
        public int PartYNo { get; set; }
        //局号W
        public int PartWNo { get; set; }
        //局号X
        public int PartBNo { get; set; }
        //局号X
        public int PartCNo { get; set; }

        //局号X
        public string PartXData { get; set; }
        //局号Y
        public string PartYData { get; set; }
        //局号W
        public string PartWData { get; set; }
        //局号X
        public string PartBData { get; set; }
        //局号X
        public string PartCData { get; set; }

        public int ReadFushiData(string result, int defaultValue)
        {
            if (result != null && result.Length > 14)
            {
                while (result.Length > 8)
                {
                    string start = result.Substring(0, 2);
                    if (fushiStartCodes.Contains(start))
                    {
                        break;
                    }
                }
                string data = result.Substring(6, 8);
                return Convert.ToInt32(data, 16);
            }
            return defaultValue;
        }
    }
}
