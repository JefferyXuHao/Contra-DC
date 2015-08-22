using System;
using System.Collections.Generic;
using System.Text;

namespace Contra
{
    public class M21Info : BaseInfo
    {
        public M21Info()
        {

        }

        public M21Info(string text)
            : base(text)
        {

        }

        protected override void ResolveText(string[] list)
        {
            base.ResolveText(list);
            if (!list[0].StartsWith("M21"))
            {
                throw new Exception("Error");
            }
            if (!list[1].StartsWith("E"))
            {
                throw new Exception("Error");
            }
            int i = int.Parse(list[1].Replace("E", ""));
            if (i <= 0 || i > 10)
            {
                throw new Exception("Error");
            }
            this.E = list[1];
        }

        public string E
        {
            get;
            set;
        }

        public override string Value
        {
            get
            {
                return "M21";
            }
        }
    }
}
