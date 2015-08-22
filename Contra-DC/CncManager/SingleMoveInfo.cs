using System;
using System.Collections.Generic;
using System.Text;

namespace Contra
{
    public class SingleMoveInfo : BaseInfo
    {
        public SingleMoveInfo()
        {

        }

        public SingleMoveInfo(string text)
            : base(text)
        {

        }

        protected override void ResolveText(string[] list)
        {
            for (int i = 1; i < list.Length; i++)
            {
                if (list[i].StartsWith("X")) this.X = decimal.Parse(list[i].Substring(1));
                else if (list[i].StartsWith("Y")) this.Y = decimal.Parse(list[i].Substring(1));
                else if (list[i].StartsWith("W")) this.W = decimal.Parse(list[i].Substring(1));
                else if (list[i].StartsWith("A")) this.A = decimal.Parse(list[i].Substring(1));
                else if (list[i].StartsWith("B")) this.B = decimal.Parse(list[i].Substring(1));
                else if (list[i].StartsWith("C")) this.C = decimal.Parse(list[i].Substring(1));
                else if (list[i].StartsWith("Z")) this.A = decimal.Parse(list[i].Substring(1));
            }
        }

        public Nullable<decimal> X { get; set; }
        public Nullable<decimal> Y { get; set; }
        public Nullable<decimal> W { get; set; }
        public Nullable<decimal> A { get; set; }
        public Nullable<decimal> B { get; set; }
        public Nullable<decimal> C { get; set; }

        public string Param { get; set; }

        public string AxisType { get; set; }

        public override string Value
        {
            get
            {
                string v = "G0 ";
                if (X.HasValue)
                {
                    v += "X" + X.Value + " ";
                }
                if (Y.HasValue)
                {
                    v += "Y" + Y.Value + " ";
                }
                if (W.HasValue)
                {
                    v += "W" + W.Value + " ";
                }
                if (B.HasValue)
                {
                    v += "B" + B.Value + " ";
                }
                if (C.HasValue)
                {
                    v += "C" + C.Value + " ";
                }
                return v;
            }
        }
    }
}
