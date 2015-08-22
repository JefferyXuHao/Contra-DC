using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contra
{
    public class PCKInfo : PCKStandardInfo
    {
        public PCKInfo()
        {
            CheckValue = 0.1m;
        }

        internal decimal CheckValue { get; set; }

        public Nullable<decimal> RealValue { get; set; }

        public string State
        {
            get
            {
                if (!StandardValue.HasValue || !RealValue.HasValue)
                {
                    return "未检测";
                }
                if (Math.Abs((StandardValue - RealValue).Value) <= CheckValue)
                {
                    return "YES";
                }
                else
                {
                    return "NO";
                }
            }
        }
    }
}
