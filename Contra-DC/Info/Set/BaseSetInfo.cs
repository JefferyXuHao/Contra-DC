using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contra
{
    public class BaseSetInfo
    {
        public virtual void Validate()
        {

        }

        public virtual object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
