using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contra
{
    public class ParamInfo
    {
        public ParamInfo()
        {
            V = 40;
            Speed = 10;
            ThrowMode = "0";
        }

        public int TOn { get; set; }

        public int TOff { get; set; }

        public int I { get; set; }

        public int I2 { get; set; }

        public decimal Depth { get; set; }

        public decimal Depth2 { get; set; }

        public int StopTime { get; set; }

        public int Speed { get; set; }

        public int V { get; set; }

        public bool Fanjixing { get; set; }

        public bool Rotate { get; set; }

        public string ThrowMode { get; set; }

    }
}
