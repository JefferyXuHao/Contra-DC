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
    public partial class FormRestart : RibbonForm
    {
        private BaseInfoCollection collection;
        public FormRestart()
        {
            InitializeComponent();
            ContraHelper.SetIntEditor(this.txtNewValue);
        }

        public FormRestart(int lineNum, BaseInfoCollection collection)
            : this()
        {
            if (lineNum < 0)
            {
                lineNum = 0;
            }
            else if (lineNum > collection.Count - 1)
            {
                lineNum = collection.Count - 1;
            }
            ReStartLineNumInfo info = new ReStartLineNumInfo { LineNum = lineNum + 1 };
            this.bindingSource1.DataSource = info;
            this.collection = collection;
        }

        public ReStartLineNumInfo LineNumInfo
        {
            get { return this.bindingSource1.DataSource as ReStartLineNumInfo; }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (this.LineNumInfo.LineNum > this.collection.Count ||
                this.LineNumInfo.LineNum < 1)
            {
                throw new WarningException("不存在行{0}", this.LineNumInfo.LineNum);
            }
            this.DialogResult = DialogResult.OK;
        }
    }
}
