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
    public partial class FormJiagongHistory : FormBase
    {
        public FormJiagongHistory(List<JiagongHistoryInfo> list)
        {
            InitializeComponent();
            this.gridViewCnc.GridControl.DataSource = list;
        }

        private List<JiagongHistoryInfo> List
        {
            get { return this.gridViewCnc.GridControl.DataSource as List<JiagongHistoryInfo>; }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (List.Count > 0
            && ContraHelper.ShowQuestion(L.R("FormJiagongHistory.Sure", "您确定要删除所有的加工历史吗？")))
            {
                List.Clear();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = ContraHelper.FilterTxt;
            dialog.FileName = string.Format("History{0:yyMMddHHmm}.txt", DateTime.Now);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                HistoryHelper.Save(dialog.FileName, List);
                ContraHelper.ShowMessage(L.R("FormJiagongHistory.SaveSuccess","保存成功!"));
            }
        }
    }
}
