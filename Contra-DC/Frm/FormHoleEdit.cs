using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ContraLibrary;
using Contra.Properties;

namespace Contra
{
    public partial class FormHoleEdit : FormBase
    {
        private ContraInfo contra;
        private string axisType;
        public FormHoleEdit(HoleCollection collection, ContraInfo contra, string axisType)
        {
            InitializeComponent();
            this.bindingSourceHole.DataSource = collection.Clone();
            this.bindingSource.DataSource = new HoleOperateInfo() { AxisType = axisType };
            this.bindingSource2.DataSource = new HoleOperateInfo() { AxisType = axisType };
            this.contra = contra;
            this.axisType = axisType;
        }

        public HoleCollection HoleCollection { get { return this.bindingSourceHole.DataSource as HoleCollection; } }
        public HoleOperateInfo HoleOperate { get { return this.bindingSource.DataSource as HoleOperateInfo; } }
        public HoleOperateInfo HoleOperate2 { get { return this.bindingSource2.DataSource as HoleOperateInfo; } }

        public void btnAddHole_Click(object sender, EventArgs e)
        {
            var holeInfo = new HoleInfo()
                {
                    IsJiaGong = true,
                    X = contra.GetActPosX(axisType),
                    Y = contra.GetActPosY(axisType),
                    W = contra.GetActPosW(axisType),
                    B = contra.GetActPosB(axisType),
                    C = contra.GetActPosC(axisType),
                    AxisType = axisType,
                    Param = "E1"
                };
            HoleCollection.Insert(this.bindingSourceHole.Position + 1, holeInfo);
            bindingSourceHole.ResetBindings(false);
        }

        public void btnDeleteHole_Click(object sender, EventArgs e)
        {
            if (this.bindingSourceHole.Current != null)
            {
                this.bindingSourceHole.RemoveCurrent();
            }
        }

        public void btnPreviousHole_Click(object sender, EventArgs e)
        {
            if (this.bindingSourceHole.Position > 0)
            {
                var a = this.bindingSourceHole[this.bindingSourceHole.Position];
                this.bindingSourceHole[this.bindingSourceHole.Position] = this.bindingSourceHole[this.bindingSourceHole.Position - 1];
                this.bindingSourceHole[this.bindingSourceHole.Position - 1] = a;
                this.bindingSourceHole.Position--;
            }
        }

        public void btnNextHole_Click(object sender, EventArgs e)
        {
            if (this.bindingSourceHole.Position < this.bindingSourceHole.Count - 1)
            {
                var a = this.bindingSourceHole[this.bindingSourceHole.Position];
                this.bindingSourceHole[this.bindingSourceHole.Position] = this.bindingSourceHole[this.bindingSourceHole.Position + 1];
                this.bindingSourceHole[this.bindingSourceHole.Position + 1] = a;
                this.bindingSourceHole.Position++;
            }
        }

        public void FocusedPrevious()
        {
            if (this.bindingSourceHole.Position > 0)
            {
                this.bindingSourceHole.Position--;
            }
        }

        public void FocusedNext()
        {
            if (this.bindingSourceHole.Position < this.bindingSourceHole.Count - 1)
            {
                this.bindingSourceHole.Position++;
            }
        }

        public HoleInfo GetMoveInfo()
        {
            var holeInfo = this.bindingSourceHole.Current as HoleInfo;
            if (holeInfo != null)
            {
                return new HoleInfo()
                {
                    X = holeInfo.X,
                    Y = holeInfo.Y,
                    W = holeInfo.W,
                    B = holeInfo.B,
                    C = holeInfo.C,
                    AxisType = holeInfo.AxisType,
                    Param = holeInfo.Param
                };
            }
            return null;
        }

        private void btnBatchCreate_Click(object sender, EventArgs e)
        {
            var x = HoleOperate.XStart;
            var y = HoleOperate.YStart;
            var w = HoleOperate.WStart;
            var b = HoleOperate.BStart;
            var c = HoleOperate.CStart;
            for (int i = 0; i < HoleOperate.Repeat; i++)
            {
                var holeInfo = new HoleInfo()
                {
                    IsJiaGong = HoleOperate.IsJiagong,
                    X = x + HoleOperate.XInterval,
                    Y = y + HoleOperate.YInterval,
                    W = w + HoleOperate.WInterval,
                    B = b + HoleOperate.BInterval,
                    C = c + HoleOperate.CInterval,
                    AxisType = HoleOperate.AxisType,
                    Param = HoleOperate.Param
                };
                x += HoleOperate.XInterval;
                y += HoleOperate.YInterval;
                w += HoleOperate.WInterval;
                b += HoleOperate.BInterval;
                c += HoleOperate.CInterval;
                HoleCollection.Insert(this.bindingSourceHole.Position + 1 + i, holeInfo);
            }
            bindingSourceHole.ResetBindings(false);
        }

        private void gridViewCnc_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void btnBatchCreate2_Click(object sender, EventArgs e)
        {
            var operate = HoleOperate2;
            var x = operate.XStart;
            var y = operate.YStart;
            var w = operate.WStart;
            var b = operate.BStart;
            var c = operate.CStart;
            var xe = operate.XInterval;
            var ye = operate.YInterval;
            var we = operate.WInterval;
            var be = operate.BInterval;
            var ce = operate.CInterval;
            decimal? xs = (xe - x) / (operate.Repeat + 1);
            decimal? ys = (ye - y) / (operate.Repeat + 1);
            decimal? ws = (we - w) / (operate.Repeat + 1);
            decimal? bs = (be - b) / (operate.Repeat + 1);
            decimal? cs = (ce - c) / (operate.Repeat + 1);

            for (int i = 0; i < operate.Repeat; i++)
            {
                var holeInfo = new HoleInfo()
                {
                    IsJiaGong = operate.IsJiagong,
                    X = x + xs,
                    Y = y + ys,
                    W = w + ws,
                    B = b + bs,
                    C = c + cs,
                    AxisType = operate.AxisType,
                    Param = operate.Param
                };
                x += xs;
                y += ys;
                w += ws;
                b += bs;
                c += cs;
                HoleCollection.Insert(this.bindingSourceHole.Position + 1 + i, holeInfo);
            }
            bindingSourceHole.ResetBindings(false);
        }

        public string FileName
        {
            get;
            set;
        }

        private void gridViewCnc_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0)
            {
                var holeInfo = this.bindingSourceHole.Current as HoleInfo;
                var holeOperator = this.bindingSource.Current as HoleOperateInfo;
                var holeOperator2 = this.bindingSource2.Current as HoleOperateInfo;
                holeOperator.XStart = holeOperator2.XStart = holeInfo.X;
                holeOperator.YStart = holeOperator2.YStart = holeInfo.Y;
                holeOperator.WStart = holeOperator2.WStart = holeInfo.W;
                holeOperator.BStart = holeOperator2.BStart = holeInfo.B;
                holeOperator.CStart = holeOperator2.CStart = holeInfo.C;
                holeOperator.AxisType = holeOperator2.AxisType = holeInfo.AxisType;

                var holeInfo2 = holeInfo;
                if (e.FocusedRowHandle < this.bindingSourceHole.Count - 1)
                {
                    holeInfo2 = this.bindingSourceHole[e.FocusedRowHandle + 1] as HoleInfo;
                }
                holeOperator2.XInterval = holeInfo2.X;
                holeOperator2.YInterval = holeInfo2.Y;
                holeOperator2.WInterval = holeInfo2.W;
                holeOperator2.BInterval = holeInfo2.B;
                holeOperator2.CInterval = holeInfo2.C;

                this.bindingSource.ResetBindings(false);
                this.bindingSource2.ResetBindings(false);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = ContraHelper.FilterCnc;
            dialog.FileName = "newFile1.cnc";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                PNCHelper.SaveCnc(HoleCollection, dialog.FileName, Settings.Default.Set.OtherSet.ScriptMode);
                FileName = dialog.FileName.Replace(".cnc", ".pnc");
                ContraHelper.ShowMessage(L.R("FormHoleEdit.DaoChuChengGong", "导出成功!"));
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = ContraHelper.FilterCnc;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.bindingSourceHole.DataSource = PNCHelper.LoadCnc(dialog.FileName, Settings.Default.Set.OtherSet.ScriptMode);
                this.bindingSourceHole.ResetBindings(false);
                FileName = dialog.FileName.Replace(".cnc", ".pnc");
                ContraHelper.ShowMessage(L.R("FormHoleEidt.DaoRuChengGong", "导入成功!"));
            }
        }
    }
}
