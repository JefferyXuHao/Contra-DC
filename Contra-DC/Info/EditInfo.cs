using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Contra
{
    public class EditInfo
    {
        public EditInfo()
        {
            this.AxisType = HeadType.G90;
            this.Axis = HeadType.G54;

            this.MoveType = HeadType.G0;
            this.Mode = HeadType.M21;

            this.ChildMode = HeadType.M98;
        }

        public string AxisType { get; set; }
        public string Axis { get; set; }
        public string MoveType { get; set; }
        public string Mode { get; set; }
        public string Value { get; set; }

        public string ChildMode { get; set; }
        public string ChildValue { get; set; }



        public string X { get; set; }
        public string Y { get; set; }
        public string W { get; set; }
        public string C { get; set; }
    }
}
