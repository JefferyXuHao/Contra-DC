using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Contra.Properties;
using ContraLibrary;
using System.Configuration;
using Contra.Custom;
using ContraReg2;

namespace Contra
{
    public partial class FrmLogin : FormBase
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Register.CheckCodeValid(Settings.Default.CompanyName);
            Register.CheckDaysValid(Settings.Default.LastCaclRegDate);
            Settings.Default.LastLoginDay = DateTime.Today;
            //Settings.Default.LeftDays = leftDays;
            Settings.Default.Save();
            this.DialogResult = DialogResult.OK;
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            FormReg regForm = new FormReg();
            regForm.ShowDialog();
        }
    }
}
