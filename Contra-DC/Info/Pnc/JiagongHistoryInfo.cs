using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contra
{
    public class JiagongHistoryInfo
    {
        public int Line { get; set; }

        public string AxisType { get; set; }

        public Nullable<decimal> X { get; set; }

        public Nullable<decimal> Y { get; set; }

        public Nullable<decimal> W { get; set; }

        public Nullable<decimal> B { get; set; }

        public Nullable<decimal> C { get; set; }

        public Nullable<decimal> Z { get; set; }

        public Nullable<decimal> MachineHeight { get; set; }

        public Nullable<decimal> ThrowHeight { get; set; }

        public Nullable<int> Seconds { get; set; }

        public Nullable<decimal> ZeroHeight { get; set; }

        public Nullable<decimal> HoleHeight { get; set; }
    }
}
