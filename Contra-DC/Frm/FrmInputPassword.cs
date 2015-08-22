using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Ribbon;
using ContraLibrary;

namespace Contra
{
    public partial class FrmInputPassword : FormBase
    {
        public FrmInputPassword()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.Equals(this.edit.EditValue, "85811888")
                || string.Equals(this.edit.EditValue, "85185518"))
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                throw new WarningException(L.R("FrmInputPassword.PasswordNotCorrect", "密码不正确!"));
            }
        }

        private void FrmInputPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnOK_Click(sender, e);
            }
        }
    }
}
