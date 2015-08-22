using System;
using System.Collections.Generic;
using System.Text;

namespace Contra
{
    public class SetValueInfo
    {
        private decimal value;
        public decimal Value
        {
            get { return decimal.Round(value, 3); }
            set { this.value = value; }
        }
    }
}
