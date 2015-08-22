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
    public partial class FormDaoKu : FormBase
    {
        private PortHelper plcHelper;
        private FormMain formMain;
        public FormDaoKu(FormMain formMain, PortHelper plcHelper)
        {
            InitializeComponent();
            this.formMain = formMain;
            this.plcHelper = plcHelper;
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            formMain.ChangeDaoMove(false);
        }

        private void btnRotate_Click(object sender, EventArgs e)
        {
            plcHelper.SendMsg(PortHelper.DaoRotate);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
