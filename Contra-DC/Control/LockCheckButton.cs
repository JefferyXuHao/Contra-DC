using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using DevExpress.XtraEditors;
using Contra.Properties;

namespace Contra
{
    public partial class LockCheckButton : CheckButton
    {
        public LockCheckButton()
        {
            InitializeComponent();
        }

        public LockCheckButton(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        private void LockCheckButton_CheckedChanged(object sender, EventArgs e)
        {
            this.Image = this.Checked ? Resources.on : Resources.off;
            this.Invalidate();
        }
        [Bindable(true, BindingDirection.TwoWay)]
        public override bool Checked
        {
            get
            {
                return base.Checked;
            }
            set
            {
                base.Checked = value;
            }
        }
    }
}
