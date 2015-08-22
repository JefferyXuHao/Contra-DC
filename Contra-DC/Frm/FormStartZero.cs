using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ContraLibrary;

namespace Contra
{
    public partial class FormStartZero : FormBase
    {
        public FormStartZero()
        {
            InitializeComponent();
            this.bindingSource1.DataSource = new StartToZeroInfo();
        }

        public StartToZeroInfo ZeroInfo
        {
            get { return this.bindingSource1.DataSource as StartToZeroInfo; }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (!ZeroInfo.IsZeroAll && !ZeroInfo.IsZeroZ)
            {
                throw new WarningException(L.R("FormStartZero.AtLeastOne", "请至少选择一个轴回零！"));
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
