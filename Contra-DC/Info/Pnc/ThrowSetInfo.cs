using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contra
{
    public class ThrowSetInfo
    {
        public ThrowSetInfo()
        {
            ThrowMode = "0";
            ThrowStartHeight = -1;
            ThrowResponse = 6;
        }


        //穿透模式 0 不使用 1使用模式1 2 使用模式2
        public string ThrowMode { get; set; }
        //穿透起始高度
        public decimal ThrowStartHeight { get; set; }
        //穿透余量
        public decimal ThrowLeft { get; set; }

        public int ThrowResponse { get; set; }

        //穿透起始高度
        public decimal ThrowStartHeight2 { get; set; }
        //穿透余量
        public decimal ThrowLeft2 { get; set; }

        public int ThrowResponse2 { get; set; }

        public decimal GetThrowLeft(int mode)
        {
            switch (mode)
            {
                case 1: return ThrowLeft;
                case 2: return ThrowLeft2;
                default:
                    return 0;
            }
        }

        public decimal GetThrowStartHeight(int mode)
        {
            switch (mode)
            {
                case 1: return ThrowStartHeight;
                case 2: return ThrowStartHeight2;
                default:
                    return 0;
            }
        }

        public int GetThrowResponse(int mode)
        {
            switch (mode)
            {
                case 1: return ThrowResponse;
                case 2: return ThrowResponse2;
                default:
                    return 0;
            }
        }
    }
}
