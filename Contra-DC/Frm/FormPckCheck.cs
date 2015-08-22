using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ContraLibrary;
using System.IO;
using Contra.Properties;

namespace Contra
{
    public partial class FormPckCheck : FormBase
    {
        FormMain mainForm;
        public FormPckCheck(FormMain mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.bindingSource2.DataSource = mainForm.CurrInfo;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.timer1.Enabled = true;
            try
            {
                if (!string.IsNullOrEmpty(mainForm.fileName))
                {
                    string fileName = mainForm.fileName.Replace(".pnc", ".pck");
                    if (File.Exists(fileName))
                    {
                        this.bindingSource.DataSource = ConvertToPckList(PCKHelper.LoadPck(fileName));
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            this.timer1.Enabled = false;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = ContraHelper.FilterPck;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var ext = Path.GetExtension(dialog.FileName);
                if (ext == ".pck")
                {
                    this.bindingSource.DataSource = ConvertToPckList(PCKHelper.LoadPck(dialog.FileName));
                }
                else if (ext == ".pnc")
                {
                    this.bindingSource.DataSource = ConvertToPckList(PCKHelper.LoadPnc(dialog.FileName));
                }
                else if (ext == ".cnc")
                {
                    this.bindingSource.DataSource = ConvertToPckList(PCKHelper.LoadCnc(dialog.FileName, Settings.Default.Set.OtherSet.ScriptMode));
                }
                ContraHelper.ShowMessage(L.R("FormPckCheck.DaoRuChengGong", "加载成功!"));
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var list = this.bindingSource.DataSource as List<PCKInfo>;
            var pckList = ConvertToPckStandardList(list);
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = ContraHelper.FilterPck2;
            if (!string.IsNullOrEmpty(mainForm.fileName))
                dialog.FileName = mainForm.fileName.Replace(".pnc", ".pck");
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                PCKHelper.SavePck(pckList, dialog.FileName);
                ContraHelper.ShowMessage(L.R("FormPckCheck.BaoCunChengGong", "保存成功!"));
            }
        }

        private void btnStandardCheck_Click(object sender, EventArgs e)
        {
            var list = this.bindingSource.DataSource as List<PCKInfo>;
            if (list != null)
            {
                foreach (var item in list)
                {
                    item.StandardValue = null;
                }
                mainForm.lnsCheckCount = 0;
                mainForm.lnsCheckCurrentLine = 0;
                mainForm.lnsCheckType = 1;
                mainForm.pckList = list;
                mainForm.isLNSCheck = true;
            }
        }

        private void btnReadCheck_Click(object sender, EventArgs e)
        {
            var list = this.bindingSource.DataSource as List<PCKInfo>;
            if (list != null)
            {
                foreach (var item in list)
                {
                    item.RealValue = null;
                }
                mainForm.lnsCheckCount = 0;
                mainForm.lnsCheckCurrentLine = 0;
                mainForm.lnsCheckType = 2;
                mainForm.pckList = list;
                mainForm.isLNSCheck = true;
            }
        }

        private List<PCKInfo> ConvertToPckList(List<PCKStandardInfo> standardList)
        {
            List<PCKInfo> list = new List<PCKInfo>();
            foreach (var item in standardList)
            {
                PCKInfo pckInfo = new PCKInfo();
                pckInfo.AxisType = item.AxisType;
                pckInfo.X = item.X;
                pckInfo.Y = item.Y;
                pckInfo.W = item.W;
                pckInfo.B = item.B;
                pckInfo.C = item.C;
                pckInfo.StandardValue = item.StandardValue;
                pckInfo.RealValue = null;
                list.Add(pckInfo);
            }
            return list;
        }

        private List<PCKStandardInfo> ConvertToPckStandardList(List<PCKInfo> pckList)
        {
            List<PCKStandardInfo> list = new List<PCKStandardInfo>();
            foreach (var item in pckList)
            {
                PCKStandardInfo pckInfo = new PCKStandardInfo();
                pckInfo.AxisType = item.AxisType;
                pckInfo.X = item.X;
                pckInfo.Y = item.Y;
                pckInfo.W = item.W;
                pckInfo.B = item.B;
                pckInfo.C = item.C;
                pckInfo.StandardValue = item.StandardValue;

                list.Add(pckInfo);
            }
            return list;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            mainForm.isLNSCheck = false;
            mainForm.isLnsMove = false;
            mainForm.isLnsMoved = false;
            mainForm.isContinue = false;
            mainForm.card.OperateStopRun();
            mainForm.PlcHelpr.SendMsg(PortHelper.LNSOff);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (mainForm.isLNSCheck && this.bindingSource.DataSource != null)
            {
                this.bindingSource.Position = mainForm.lnsCheckCurrentLine;
            }
            this.btnLoad.Enabled = this.btnSave.Enabled = this.btnReadCheck.Enabled = this.btnStandardCheck.Enabled = !mainForm.isLNSCheck;
            this.btnStop.Enabled = mainForm.isLNSCheck;
            this.btnClose.Enabled = !mainForm.isLNSCheck;
            if (!mainForm.isLNSCheck)
            {
                this.bindingSource.ResetBindings(false);
            }
        }

        private void gridViewCnc_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            var pckInfo = this.gridViewCnc.GetRow(e.RowHandle) as PCKInfo;
            if (e.Column != null && e.Column.FieldName == "State")
            {
                if (pckInfo.State == "YES")
                {
                    e.Appearance.BackColor = Color.Green;
                }
                else if (pckInfo.State == "NO")
                {
                    e.Appearance.BackColor = Color.Red;
                }
            }

        }

    }
}
