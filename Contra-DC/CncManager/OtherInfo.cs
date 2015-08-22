using System;
using System.Collections.Generic;
using System.Text;

namespace Contra
{
    public class OtherInfo : BaseInfo
    {
        public OtherInfo()
        {

        }

        public OtherInfo(string text)
            : base(text)
        {

        }

        protected override void ResolveText(string[] list)
        {
            base.ResolveText(list);
        }
    }
}
