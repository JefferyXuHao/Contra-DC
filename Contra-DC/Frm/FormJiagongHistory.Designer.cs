namespace Contra
{
    partial class FormJiagongHistory
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridViewCnc = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemSpinEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox6 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCnc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox6)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl2
            // 
            this.gridControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl2.Location = new System.Drawing.Point(6, 5);
            this.gridControl2.MainView = this.gridViewCnc;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox6,
            this.repositoryItemSpinEdit1,
            this.repositoryItemComboBox1});
            this.gridControl2.Size = new System.Drawing.Size(750, 308);
            this.gridControl2.TabIndex = 0;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewCnc});
            // 
            // gridViewCnc
            // 
            this.gridViewCnc.ColumnPanelRowHeight = 48;
            this.gridViewCnc.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn12,
            this.gridColumn1,
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn16,
            this.gridColumn17,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6});
            this.gridViewCnc.GridControl = this.gridControl2;
            this.gridViewCnc.IndicatorWidth = 50;
            this.gridViewCnc.Name = "gridViewCnc";
            this.gridViewCnc.OptionsView.ShowGroupPanel = false;
            this.gridViewCnc.OptionsView.ShowIndicator = false;
            // 
            // gridColumn12
            // 
            this.gridColumn12.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn12.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn12.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn12.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn12.Caption = "孔号";
            this.gridColumn12.FieldName = "Line";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowMove = false;
            this.gridColumn12.OptionsColumn.AllowSize = false;
            this.gridColumn12.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn12.OptionsColumn.ReadOnly = true;
            this.gridColumn12.OptionsFilter.AllowFilter = false;
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 0;
            this.gridColumn12.Width = 53;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "坐标系";
            this.gridColumn1.ColumnEdit = this.repositoryItemComboBox1;
            this.gridColumn1.FieldName = "AxisType";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 55;
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Items.AddRange(new object[] {
            "G54",
            "G55",
            "G56",
            "G57",
            "G58",
            "G59",
            "G60",
            "G61",
            "G62",
            "G63",
            "G64",
            "G65"});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // gridColumn13
            // 
            this.gridColumn13.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn13.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn13.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.gridColumn13.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn13.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn13.Caption = "X";
            this.gridColumn13.ColumnEdit = this.repositoryItemSpinEdit1;
            this.gridColumn13.FieldName = "X";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowMove = false;
            this.gridColumn13.OptionsColumn.AllowSize = false;
            this.gridColumn13.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn13.OptionsColumn.ReadOnly = true;
            this.gridColumn13.OptionsFilter.AllowFilter = false;
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 2;
            // 
            // repositoryItemSpinEdit1
            // 
            this.repositoryItemSpinEdit1.AutoHeight = false;
            this.repositoryItemSpinEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, false, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.repositoryItemSpinEdit1.DisplayFormat.FormatString = "0.000";
            this.repositoryItemSpinEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.repositoryItemSpinEdit1.EditFormat.FormatString = "0.000";
            this.repositoryItemSpinEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.repositoryItemSpinEdit1.MaxValue = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.repositoryItemSpinEdit1.MinValue = new decimal(new int[] {
            999999,
            0,
            0,
            -2147483648});
            this.repositoryItemSpinEdit1.Name = "repositoryItemSpinEdit1";
            // 
            // gridColumn14
            // 
            this.gridColumn14.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn14.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn14.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.gridColumn14.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn14.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn14.Caption = "Y";
            this.gridColumn14.ColumnEdit = this.repositoryItemSpinEdit1;
            this.gridColumn14.FieldName = "Y";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowMove = false;
            this.gridColumn14.OptionsColumn.AllowSize = false;
            this.gridColumn14.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn14.OptionsColumn.ReadOnly = true;
            this.gridColumn14.OptionsFilter.AllowFilter = false;
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 3;
            // 
            // gridColumn15
            // 
            this.gridColumn15.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn15.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn15.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.gridColumn15.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn15.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn15.Caption = "W";
            this.gridColumn15.ColumnEdit = this.repositoryItemSpinEdit1;
            this.gridColumn15.FieldName = "W";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.OptionsColumn.AllowMove = false;
            this.gridColumn15.OptionsColumn.AllowSize = false;
            this.gridColumn15.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn15.OptionsColumn.ReadOnly = true;
            this.gridColumn15.OptionsFilter.AllowFilter = false;
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 4;
            // 
            // gridColumn16
            // 
            this.gridColumn16.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn16.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn16.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.gridColumn16.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn16.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn16.Caption = "B";
            this.gridColumn16.ColumnEdit = this.repositoryItemSpinEdit1;
            this.gridColumn16.FieldName = "B";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.OptionsColumn.AllowMove = false;
            this.gridColumn16.OptionsColumn.AllowSize = false;
            this.gridColumn16.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn16.OptionsColumn.ReadOnly = true;
            this.gridColumn16.OptionsFilter.AllowFilter = false;
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 5;
            // 
            // gridColumn17
            // 
            this.gridColumn17.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn17.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn17.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.gridColumn17.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn17.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn17.Caption = "C";
            this.gridColumn17.ColumnEdit = this.repositoryItemSpinEdit1;
            this.gridColumn17.FieldName = "C";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.OptionsColumn.AllowMove = false;
            this.gridColumn17.OptionsColumn.AllowSize = false;
            this.gridColumn17.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn17.OptionsColumn.ReadOnly = true;
            this.gridColumn17.OptionsFilter.AllowFilter = false;
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 6;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "设定深度";
            this.gridColumn2.ColumnEdit = this.repositoryItemSpinEdit1;
            this.gridColumn2.FieldName = "MachineHeight";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 7;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "穿透深度";
            this.gridColumn3.ColumnEdit = this.repositoryItemSpinEdit1;
            this.gridColumn3.FieldName = "ThrowHeight";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 8;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "耗时";
            this.gridColumn4.FieldName = "Seconds";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 9;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "铜管消耗";
            this.gridColumn5.FieldName = "ZeroHeight";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 10;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "孔深";
            this.gridColumn6.FieldName = "HoleHeight";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 11;
            // 
            // repositoryItemComboBox6
            // 
            this.repositoryItemComboBox6.AutoHeight = false;
            this.repositoryItemComboBox6.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox6.DropDownRows = 10;
            this.repositoryItemComboBox6.Items.AddRange(new object[] {
            "E1",
            "E2",
            "E3",
            "E4",
            "E5",
            "E6",
            "E7",
            "E8",
            "E9",
            "E10",
            "E11",
            "E12",
            "E13",
            "E14",
            "E15",
            "E16",
            "E17",
            "E18",
            "E19",
            "E20",
            "E21",
            "E22",
            "E23",
            "E24",
            "E25",
            "E26",
            "E27",
            "E28",
            "E29",
            "E30"});
            this.repositoryItemComboBox6.Name = "repositoryItemComboBox6";
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClear.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Appearance.Options.UseFont = true;
            this.btnClear.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClear.Location = new System.Drawing.Point(7, 319);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(123, 30);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "清空";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.simpleButton2.Location = new System.Drawing.Point(136, 319);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(123, 30);
            this.simpleButton2.TabIndex = 2;
            this.simpleButton2.Text = "关闭";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSave.Location = new System.Drawing.Point(633, 319);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(123, 30);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FormJiagongHistory
            // 
            this.CancelButton = this.simpleButton2;
            this.ClientSize = new System.Drawing.Size(762, 353);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.gridControl2);
            this.Name = "FormJiagongHistory";
            this.Text = "加工历史";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCnc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewCnc;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
    }
}