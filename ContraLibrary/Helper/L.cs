using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContraLibrary
{
    public class L
    {
        public static string R(string key, string defaultValue)
        {
            return LanguageHelper.GetText(key, defaultValue);
        }
    }
}
