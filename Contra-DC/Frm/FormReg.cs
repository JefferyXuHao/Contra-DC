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
using ContraReg2;

namespace Contra
{
    public partial class FormReg : FormBase
    {
        public FormReg()
        {
            InitializeComponent();
            this.txtCompany.Text = Settings.Default.CompanyName;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            var companyName = this.txtCompany.Text.Trim();
            if (string.IsNullOrEmpty(companyName))
            {
                throw new WarningException("公司名称不能为空！");
            }
            Register.SaveMachineCodeFile(companyName);
            Settings.Default.CompanyName = companyName;
            Settings.Default.Save();
        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            if (Register.ReadRegCodeFile(this.txtCompany.Text))
            {
                ContraHelper.ShowMessage(L.R("FormReg.RegSuccess", "注册成功!"));
                Settings.Default.CompanyName = this.txtCompany.Text;
                Settings.Default.Save();
                this.Close();
            }
        }

        //private void btnReg_Click(object sender, EventArgs e)
        //{
        //    int days = ContraRegManager.Reg(this.txtCompany.Text.Trim(), this.txtRegCode.Text.Trim());
        //    ContraHelper.ShowMessage(L.R("FormReg.RegSucces","注册成功"));
        //    Settings.Default.CompanyName = this.txtCompany.Text.Trim();
        //    Settings.Default.LeftDays = days;
        //    Settings.Default.Save();
        //    this.Close();
        //}

        //private void btnPaste_Click(object sender, EventArgs e)
        //{
        //    IDataObject obj = Clipboard.GetDataObject();
        //    var data = obj.GetData(DataFormats.Text);
        //    this.txtRegCode.Text = data.ToString();
        //}

    }
}
