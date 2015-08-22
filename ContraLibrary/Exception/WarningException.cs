using System;
using System.Collections.Generic;
using System.Text;

namespace ContraLibrary
{
    public class WarningException:Exception
    {
        public WarningException(string message, params object[] param)
            : base(string.Format(message, param))
        {
        }
    }
}
