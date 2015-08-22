using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using ContraLibrary;

namespace Contra
{
    public partial class FrmSet : FormBase
    {
        private CardHelper cardHelper;
        private PortHelper _232Helper;
        public FrmSet(SetInfo info, CardHelper cardHelper, PortHelper _232Helper)
        {
            InitializeComponent();
            var newInfo = info.Clone();
            this.cardHelper = cardHelper;
            this._232Helper = _232Helper;
            this.bindingSourceAxis.DataSource = newInfo;
            this.bindingSourceIO.DataSource = newInfo;
            this.bindingSourceOther.DataSource = newInfo;
            this.bindingSourceAbsolutePos.DataSource = newInfo;
            this.bindingSourceButton.DataSource = newInfo;

            var table = new DataTable();
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Name");
            table.Rows.Add(1, L.R("FrmSet.SimpleWheel", "普通手轮"));
            table.Rows.Add(2, L.R("FrmSet.AdvWheel", "多功能键手轮"));
            this.cmbShouLunType.Properties.DataSource = table;
            this.cmbShouLunType.Properties.DisplayMember = "Name";
            this.cmbShouLunType.Properties.ValueMember = "ID";

            table = new DataTable();
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Name");
            table.Rows.Add(1, L.R("FrmSet.UpLimit", "上负限位"));
            table.Rows.Add(2, L.R("FrmSet.DownLimit", "下负限位"));

            this.cmbMinusLimitMode.Properties.DataSource = table;
            this.cmbMinusLimitMode.Properties.DisplayMember = "Name";
            this.cmbMinusLimitMode.Properties.ValueMember = "ID";

            table = new DataTable();
            table.Columns.Add("ID");
            table.Columns.Add("Name");
            table.Rows.Add("zh-CN", "中文");
            table.Rows.Add("en-US", "English");

            this.lueLanguage.Properties.DataSource = table;
            this.lueLanguage.Properties.DisplayMember = "Name";
            this.lueLanguage.Properties.ValueMember = "ID";

            table = new DataTable();
            table.Columns.Add("ID");
            table.Columns.Add("Name");
            table.Rows.Add("1", L.R("FrmSet.ScriptMode1", "模式1(多行)"));
            table.Rows.Add("2", L.R("FrmSet.ScriptMode2", "模式2(单行)"));

            this.lueScriptMode.Properties.DataSource = table;
            this.lueScriptMode.Properties.DisplayMember = "Name";
            this.lueScriptMode.Properties.ValueMember = "ID";

            table = new DataTable();
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Name");
            table.Rows.Add(0,  L.R("FrmSet.ThrowMode1", "普通穿透"));
            table.Rows.Add(1, L.R("FrmSet.ThrowMode2", "位置模式穿透"));

            this.lueThrowMode.Properties.DataSource = table;
            this.lueThrowMode.Properties.DisplayMember = "Name";
            this.lueThrowMode.Properties.ValueMember = "ID";

            table = new DataTable();
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Name");
            table.Rows.Add(0, L.R("FrmSet.ThrowStartMode1", "穿透信号"));
            table.Rows.Add(1, L.R("FrmSet.ThrowStartMode2", "最低位置"));

            this.lueThrowStartMode.Properties.DataSource = table;
            this.lueThrowStartMode.Properties.DisplayMember = "Name";
            this.lueThrowStartMode.Properties.ValueMember = "ID";
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SetInfo.Validate();
            this.DialogResult = DialogResult.OK;
        }

        public SetInfo SetInfo
        {
            get { return this.bindingSourceAxis.DataSource as SetInfo; }
        }

        private void lbSetBOrigin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SetInfo.AbsolutePosSet.ReadData(_232Helper.SendMsg2(PortHelper.BSignal));
            SetInfo.AbsolutePosSet.BCircleSingle = SetInfo.AbsolutePosSet.BCircleSingleCurrent;
            SetInfo.AbsolutePosSet.BCircleDouble = SetInfo.AbsolutePosSet.BCircleDoubleCurrent;
            IsNeedZeroB = true;
            this.bindingSourceAbsolutePos.ResetBindings(false);
        }

        private void lbSetCOrigin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SetInfo.AbsolutePosSet.ReadData(_232Helper.SendMsg2(PortHelper.CSignal));
            SetInfo.AbsolutePosSet.CCircleSingle = SetInfo.AbsolutePosSet.CCircleSingleCurrent;
            SetInfo.AbsolutePosSet.CCircleDouble = SetInfo.AbsolutePosSet.CCircleDoubleCurrent;
            IsNeedZeroC = true;
            this.bindingSourceAbsolutePos.ResetBindings(false);
        }

        internal bool IsNeedZeroB { get; set; }
        internal bool IsNeedZeroC { get; set; }

        private void chkUseFushi_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkUseFushi.Checked)
            {
                this.chkUseSongXia.Checked = false;
            }
            UseAbsolutePosChanged(this.chkUseFushi.Checked ? 2 : 0);
        }

        private void chkUseSongXia_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkUseSongXia.Checked)
            {
                this.chkUseFushi.Checked = false;
            }
            UseAbsolutePosChanged(this.chkUseSongXia.Checked ? 1 : 0);
        }

        private void UseAbsolutePosChanged(int type)
        {
            lbSetBOrigin.Enabled = type == 1;
            lbSetCOrigin.Enabled = type == 1;
            sePartXNo.Properties.ReadOnly = type != 2 || SetInfo.AxisSet.IgnoreX || !SetInfo.AbsolutePosSet.UsePartX;
            sePartYNo.Properties.ReadOnly = type != 2 || SetInfo.AxisSet.IgnoreY || !SetInfo.AbsolutePosSet.UsePartY;
            sePartWNo.Properties.ReadOnly = type != 2 || SetInfo.AxisSet.IgnoreW || !SetInfo.AbsolutePosSet.UsePartW;
            sePartBNo.Properties.ReadOnly = type != 2 || SetInfo.AxisSet.IgnoreB || !SetInfo.AbsolutePosSet.UsePartB;
            sePartCNo.Properties.ReadOnly = type != 2 || SetInfo.AxisSet.IgnoreC || !SetInfo.AbsolutePosSet.UsePartC;
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (this.xtraTabControl1.TabPages.IndexOf(e.Page) == 4)
            {
                UseAbsolutePosChanged(chkUseFushi.Checked ? 2 : (chkUseSongXia.Checked ? 1 : 0));
            }
        }

        private void labelControl19_Click(object sender, EventArgs e)
        {

        }

        private void xtraTabPage1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ceUsePartX_CheckedChanged(object sender, EventArgs e)
        {
            sePartXNo.Properties.ReadOnly = !this.chkUseFushi.Checked || SetInfo.AxisSet.IgnoreX || !ceUsePartX.Checked;

        }

        private void cePartY_CheckedChanged(object sender, EventArgs e)
        {
            sePartYNo.Properties.ReadOnly = !this.chkUseFushi.Checked || SetInfo.AxisSet.IgnoreY || !cePartY.Checked;

        }

        private void cePartW_CheckedChanged(object sender, EventArgs e)
        {
            sePartWNo.Properties.ReadOnly = !this.chkUseFushi.Checked || SetInfo.AxisSet.IgnoreW || !cePartW.Checked;

        }

        private void cePartB_CheckedChanged(object sender, EventArgs e)
        {
            sePartBNo.Properties.ReadOnly = !this.chkUseFushi.Checked || SetInfo.AxisSet.IgnoreB || !cePartB.Checked;
        }

        private void cePartC_CheckedChanged(object sender, EventArgs e)
        {
            sePartCNo.Properties.ReadOnly = !this.chkUseFushi.Checked || SetInfo.AxisSet.IgnoreC || !cePartC.Checked;

        }
    }
}
