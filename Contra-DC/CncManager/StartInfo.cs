using System;
using System.Collections.Generic;
using System.Text;

namespace Contra
{
    public class StartInfo : BaseInfo
    {
        public StartInfo()
        {
        }

        public StartInfo(string text)
            : base(text)
        {

        }

        public override string Value
        {
            get
            {
                return "O1234";
            }
        }
    }
}
