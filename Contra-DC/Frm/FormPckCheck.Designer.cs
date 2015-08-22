namespace Contra
{
    partial class FormPckCheck
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
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridViewCnc = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemSpinEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox6 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.btnLoad = new DevExpress.XtraEditors.SimpleButton();
            this.btnStandardCheck = new DevExpress.XtraEditors.SimpleButton();
            this.btnReadCheck = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnStop = new DevExpress.XtraEditors.SimpleButton();
            this.spSafeHeight = new DevExpress.XtraEditors.SpinEdit();
            this.bindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCnc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spSafeHeight.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl2
            // 
            this.gridControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl2.DataSource = this.bindingSource;
            this.gridControl2.Location = new System.Drawing.Point(12, 39);
            this.gridControl2.MainView = this.gridViewCnc;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox6,
            this.repositoryItemSpinEdit1,
            this.repositoryItemComboBox1});
            this.gridControl2.Size = new System.Drawing.Size(745, 443);
            this.gridControl2.TabIndex = 18;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewCnc});
            // 
            // gridViewCnc
            // 
            this.gridViewCnc.ColumnPanelRowHeight = 48;
            this.gridViewCnc.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn16,
            this.gridColumn17,
            this.gridColumn18,
            this.gridColumn2,
            this.gridColumn3});
            this.gridViewCnc.GridControl = this.gridControl2;
            this.gridViewCnc.IndicatorWidth = 50;
            this.gridViewCnc.Name = "gridViewCnc";
            this.gridViewCnc.OptionsBehavior.ReadOnly = true;
            this.gridViewCnc.OptionsView.ShowGroupPanel = false;
            this.gridViewCnc.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridViewCnc_CustomDrawCell);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "坐标系";
            this.gridColumn1.ColumnEdit = this.repositoryItemComboBox1;
            this.gridColumn1.FieldName = "AxisType";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 68;
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
            "G64"});
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
            this.gridColumn13.OptionsFilter.AllowFilter = false;
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 1;
            this.gridColumn13.Width = 97;
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
            this.gridColumn14.OptionsFilter.AllowFilter = false;
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 2;
            this.gridColumn14.Width = 97;
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
            this.gridColumn15.OptionsFilter.AllowFilter = false;
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 3;
            this.gridColumn15.Width = 97;
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
            this.gridColumn16.OptionsFilter.AllowFilter = false;
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 4;
            this.gridColumn16.Width = 97;
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
            this.gridColumn17.OptionsFilter.AllowFilter = false;
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 5;
            this.gridColumn17.Width = 97;
            // 
            // gridColumn18
            // 
            this.gridColumn18.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn18.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn18.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.gridColumn18.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn18.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn18.Caption = "基准W";
            this.gridColumn18.ColumnEdit = this.repositoryItemSpinEdit1;
            this.gridColumn18.FieldName = "StandardValue";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.OptionsColumn.AllowMove = false;
            this.gridColumn18.OptionsColumn.AllowSize = false;
            this.gridColumn18.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn18.OptionsFilter.AllowFilter = false;
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 6;
            this.gridColumn18.Width = 83;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "实测W";
            this.gridColumn2.ColumnEdit = this.repositoryItemSpinEdit1;
            this.gridColumn2.FieldName = "RealValue";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 7;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "判定";
            this.gridColumn3.FieldName = "State";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 8;
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
            // btnLoad
            // 
            this.btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLoad.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad.Appearance.Options.UseFont = true;
            this.btnLoad.Location = new System.Drawing.Point(12, 490);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(89, 35);
            this.btnLoad.TabIndex = 19;
            this.btnLoad.Text = "加载";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnStandardCheck
            // 
            this.btnStandardCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStandardCheck.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStandardCheck.Appearance.Options.UseFont = true;
            this.btnStandardCheck.Location = new System.Drawing.Point(202, 490);
            this.btnStandardCheck.Name = "btnStandardCheck";
            this.btnStandardCheck.Size = new System.Drawing.Size(89, 35);
            this.btnStandardCheck.TabIndex = 20;
            this.btnStandardCheck.Text = "基准检测";
            this.btnStandardCheck.Click += new System.EventHandler(this.btnStandardCheck_Click);
            // 
            // btnReadCheck
            // 
            this.btnReadCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReadCheck.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReadCheck.Appearance.Options.UseFont = true;
            this.btnReadCheck.Location = new System.Drawing.Point(297, 490);
            this.btnReadCheck.Name = "btnReadCheck";
            this.btnReadCheck.Size = new System.Drawing.Size(89, 35);
            this.btnReadCheck.TabIndex = 21;
            this.btnReadCheck.Text = "工件测定";
            this.btnReadCheck.Click += new System.EventHandler(this.btnReadCheck_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Location = new System.Drawing.Point(107, 490);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(89, 35);
            this.btnSave.TabIndex = 22;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(487, 490);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(89, 35);
            this.btnClose.TabIndex = 23;
            this.btnClose.Text = "关闭";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStop.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.Appearance.Options.UseFont = true;
            this.btnStop.Location = new System.Drawing.Point(392, 490);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(89, 35);
            this.btnStop.TabIndex = 24;
            this.btnStop.Text = "停止";
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // spSafeHeight
            // 
            this.spSafeHeight.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource2, "LNSCheckSafeWHeight", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.spSafeHeight.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spSafeHeight.Location = new System.Drawing.Point(126, 10);
            this.spSafeHeight.Name = "spSafeHeight";
            this.spSafeHeight.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spSafeHeight.Properties.Appearance.Options.UseFont = true;
            this.spSafeHeight.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, false, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.spSafeHeight.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.spSafeHeight.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.spSafeHeight.Properties.MinValue = new decimal(new int[] {
            300,
            0,
            0,
            -2147483648});
            this.spSafeHeight.Size = new System.Drawing.Size(104, 26);
            this.spSafeHeight.TabIndex = 79;
            this.spSafeHeight.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 24);
            this.label1.TabIndex = 80;
            this.label1.Text = "W安全高度";
            // 
            // FormPckCheck
            // 
            this.ClientSize = new System.Drawing.Size(769, 533);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.spSafeHeight);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnReadCheck);
            this.Controls.Add(this.btnStandardCheck);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.gridControl2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(250, 117);
            this.Name = "FormPckCheck";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "检测";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCnc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spSafeHeight.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewCnc;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraEditors.SimpleButton btnLoad;
        private DevExpress.XtraEditors.SimpleButton btnStandardCheck;
        private DevExpress.XtraEditors.SimpleButton btnReadCheck;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private System.Windows.Forms.BindingSource bindingSource;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraEditors.SimpleButton btnStop;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.SpinEdit spSafeHeight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource bindingSource2;
    }
}