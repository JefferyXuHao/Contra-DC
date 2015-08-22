using System;
using System.Collections.Generic;
using System.Text;

namespace Contra
{
    public class WarningException:Exception
    {
        public WarningException(string message, params object[] param)
            : base(string.Format(message, param))
        {
        }
    }
}
