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
    public partial class FormToZero : FormBase
    {
        public FormToZero(ToZeroInfo info,AxisSetInfo setInfo)
        {
            InitializeComponent();
            this.bindingSource1.DataSource = info;
            this.chkW.Enabled = !setInfo.IgnoreW;
            this.chkZ.Enabled = !setInfo.IgnoreZ;
            this.chkB.Enabled = !setInfo.IgnoreB;
            this.chkC.Enabled = !setInfo.IgnoreC;
            this.chkX.Enabled = !setInfo.IgnoreX;
            this.chkY.Enabled = !setInfo.IgnoreY;
        }

        public ToZeroInfo ZeroInfo
        {
            get { return this.bindingSource1.DataSource as ToZeroInfo; }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }
    }
}
