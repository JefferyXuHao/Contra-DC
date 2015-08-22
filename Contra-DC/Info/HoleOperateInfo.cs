using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contra
{
    public class HoleOperateInfo
    {
        public HoleOperateInfo()
        {
            Repeat = 10;
            Param = "E1";
        }

        public Nullable<decimal> XStart { get; set; }
        public Nullable<decimal> YStart { get; set; }
        public Nullable<decimal> WStart { get; set; }
        public Nullable<decimal> BStart { get; set; }
        public Nullable<decimal> CStart { get; set; }

        public Nullable<decimal> XInterval { get; set; }
        public Nullable<decimal> YInterval { get; set; }
        public Nullable<decimal> WInterval { get; set; }
        public Nullable<decimal> BInterval { get; set; }
        public Nullable<decimal> CInterval { get; set; }

        public int Repeat { get; set; }

        public string AxisType { get; set; }

        public bool IsJiagong { get; set; }
        public string Param { get; set; }
    }
}
