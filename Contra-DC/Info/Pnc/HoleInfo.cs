using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Contra
{
    public class HoleInfo : ICloneable
    {
        public HoleInfo()
        {
            IsJiaGong = true;
            AxisType = "G54";
            Param = "E1";
        }

        public bool IsJiaGong { get; set; }

        public string AxisType { get; set; }

        public Nullable<decimal> X { get; set; }

        public Nullable<decimal> Y { get; set; }

        public Nullable<decimal> W { get; set; }

        public Nullable<decimal> B { get; set; }

        public Nullable<decimal> C { get; set; }

        public Nullable<decimal> Z { get; set; }

        public string Param { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
