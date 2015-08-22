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
    public partial class FormWarning : FormBase
    {
        public FormWarning()
        {
            InitializeComponent();
        }

        public void AddWarning(string warning)
        {
            this.listBox1.Items.Insert(0, string.Format("[{0:yyyy-MM-dd HH:mm:ss}]{1}", DateTime.Now, warning));
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
