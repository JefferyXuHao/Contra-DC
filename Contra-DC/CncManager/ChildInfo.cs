using System;
using System.Collections.Generic;
using System.Text;

namespace Contra
{
    public class ChildInfo : BaseInfo
    {
        public ChildInfo()
        {

        }

        public ChildInfo(string text)
            : base(text)
        {
        }

        protected override void ResolveText(string[] list)
        {
            base.ResolveText(list);
            this.Child = string.Format("O00{0}", list[1].Substring(1));
            this.Count = int.Parse(list[2].Substring(1));
        }

        public string Child
        {
            get;
            set;
        }

        public int Count
        {
            get;
            set;
        }
    }
}
