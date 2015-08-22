using System;
using System.Collections.Generic;
using System.Text;

namespace Contra
{
    public class EndInfo : BaseInfo
    {
        public EndInfo()
        {

        }

        public EndInfo(string text)
            : base(text)
        {

        }

        public override string Value
        {
            get
            {
                return "M30";
            }
        }
    }
}
