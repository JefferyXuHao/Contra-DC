using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace ContraLibrary
{
    public class ContraSettingsProvider : SettingsProvider, IApplicationSettingsProvider
    {

        private string appName = "123";

        public override string ApplicationName
        {
            get { return appName; }
            set { appName = value; }
        }

        SettingsPropertyValue value;

        public override SettingsPropertyValueCollection GetPropertyValues(SettingsContext context, SettingsPropertyCollection collection)
        {
            SettingsPropertyValueCollection v = new SettingsPropertyValueCollection();
            value = new SettingsPropertyValue(new SettingsProperty("Style"));
            value.PropertyValue = "null";
            v.Add(value);
            return v;
        }

        public override void SetPropertyValues(SettingsContext context, SettingsPropertyValueCollection collection)
        {

        }

        public SettingsPropertyValue GetPreviousVersion(SettingsContext context, SettingsProperty property)
        {
            return value;
        }

        public void Reset(SettingsContext context)
        {

        }

        public void Upgrade(SettingsContext context, SettingsPropertyCollection properties)
        {

        }
    }
}
