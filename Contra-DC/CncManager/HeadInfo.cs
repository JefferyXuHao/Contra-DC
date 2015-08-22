using System;
using System.Collections.Generic;
using System.Text;

namespace Contra
{
    public class HeadInfo : BaseInfo
    {
        public HeadInfo()
        {

        }

        public HeadInfo(string text)
            : base(text)
        {
            
        }

        protected override void ResolveText(string[] list)
        {
            AxisType = list[0]; 
            Coordinate = list[1];
        }

        public string Coordinate { get; set; }

        public string AxisType { get; set; }

    }
}
