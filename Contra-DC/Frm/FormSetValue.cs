using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars.Ribbon;
using ContraLibrary;

namespace Contra
{
    public partial class FormSetValue : FormBase
    {
        public FormSetValue(decimal value)
        {
            InitializeComponent();
            SetValueInfo info = new SetValueInfo() { Value = value };
            this.bindingSource1.DataSource = info;
            ContraHelper.SetNullableDecimalEditor(this.txtNewValue);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.txtNewValue.Focus();
            this.txtNewValue.SelectAll();
        }

        public SetValueInfo SetInfo
        {
            get { return this.bindingSource1.DataSource as SetValueInfo; }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
