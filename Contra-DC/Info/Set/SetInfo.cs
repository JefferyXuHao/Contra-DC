using System;
using System.Collections.Generic;
using System.Text;
using Contra.Properties;
using Contra.Info;
using System.Configuration;

namespace Contra
{
    public class SetInfo : BaseSetInfo
    {
        public SetInfo()
        {

        }

        public static void InitSet()
        {
            if (Settings.Default.Set == null)
            {
                SetInfo setInfo = new SetInfo();
                setInfo.AxisSet = new AxisSetInfo();
                setInfo.IOSet = new IOSetInfo();
                setInfo.OtherSet = new OtherSetInfo();
                setInfo.AbsolutePosSet = new AbsolutePosSetInfo();
                setInfo.ButtonSet = new ButtonSetInfo();
                Settings.Default.Set = setInfo;
                Settings.Default.Save();
            }
            if (Settings.Default.Set.AbsolutePosSet == null)
            {
                Settings.Default.Set.AbsolutePosSet = new AbsolutePosSetInfo();
                Settings.Default.Save();
            }
            if (Settings.Default.Set.ButtonSet == null)
            {
                Settings.Default.Set.ButtonSet = new ButtonSetInfo();
                Settings.Default.Save();
            }
        }

        public AbsolutePosSetInfo AbsolutePosSet { get; set; }

        public AxisSetInfo AxisSet { get; set; }

        public IOSetInfo IOSet { get; set; }

        public OtherSetInfo OtherSet { get; set; }

        public ButtonSetInfo ButtonSet { get; set; }

        public override void Validate()
        {
            base.Validate();
            if (AxisSet != null)
                AxisSet.Validate();
            if (IOSet != null)
                IOSet.Validate();
            if (OtherSet != null)
                OtherSet.Validate();
            if (AbsolutePosSet != null)
                AbsolutePosSet.Validate();
            if (ButtonSet != null)
                ButtonSet.Validate();
        }

        public override object Clone()
        {
            var newSet = this.MemberwiseClone() as SetInfo;
            if (AxisSet != null)
                newSet.AxisSet = this.AxisSet.Clone() as AxisSetInfo;
            if (IOSet != null)
                newSet.IOSet = this.IOSet.Clone() as IOSetInfo;
            if (OtherSet != null)
                newSet.OtherSet = this.OtherSet.Clone() as OtherSetInfo;
            if (AbsolutePosSet != null)
                newSet.AbsolutePosSet = this.AbsolutePosSet.Clone() as AbsolutePosSetInfo;
            return newSet;
        }
    }
}
