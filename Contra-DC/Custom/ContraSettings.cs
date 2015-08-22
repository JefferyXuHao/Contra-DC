using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contra.Properties;
using System.Configuration;
using ContraLibrary;

namespace Contra.Custom
{
    [SettingsProvider(typeof(ContraSettingsProvider))]
    public class ContraSettings : ApplicationSettingsBase
    {
        private static ContraSettings defaultInstance = ((ContraSettings)(System.Configuration.ApplicationSettingsBase.Synchronized(new ContraSettings())));

        public static ContraSettings Default
        {
            get
            {
                return defaultInstance;
            }
        }

        [System.Configuration.UserScopedSettingAttribute()]
        public string Style
        {
            get
            {
                return ((string)(this["Style"]));
            }
            set
            {
                this["Style"] = value;
            }
        }


    }
}
