using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contra
{
    public class PNCInfo
    {
        public PNCInfo()
        {
            Holes = new HoleCollection();
            Params = new ParamCollection();
            ThrowSet = new ThrowSetInfo();
        }
        public ThrowSetInfo ThrowSet { get; set; }
        public HoleCollection Holes { get; set; }
        public ParamCollection Params { get; set; }
    }
}
