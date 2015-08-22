namespace Contra
{
    partial class FormToZero
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
            this.chkX = new DevExpress.XtraEditors.CheckEdit();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.chkY = new DevExpress.XtraEditors.CheckEdit();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnAccept = new DevExpress.XtraEditors.SimpleButton();
            this.chkB = new DevExpress.XtraEditors.CheckEdit();
            this.btnAll = new DevExpress.XtraEditors.SimpleButton();
            this.chkZ = new DevExpress.XtraEditors.CheckEdit();
            this.chkC = new DevExpress.XtraEditors.CheckEdit();
            this.chkW = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.chkX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkY.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkZ.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkW.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // chkX
            // 
            this.chkX.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource1, "IsZeroX", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkX.Location = new System.Drawing.Point(20, 12);
            this.chkX.Name = "chkX";
            this.chkX.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkX.Properties.Appearance.Options.UseFont = true;
            this.chkX.Properties.Caption = "回退X轴";
            this.chkX.Size = new System.Drawing.Size(109, 29);
            this.chkX.TabIndex = 0;
            // 
            // chkY
            // 
            this.chkY.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource1, "IsZeroY", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkY.Location = new System.Drawing.Point(20, 38);
            this.chkY.Name = "chkY";
            this.chkY.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkY.Properties.Appearance.Options.UseFont = true;
            this.chkY.Properties.Caption = "回退Y轴";
            this.chkY.Size = new System.Drawing.Size(109, 29);
            this.chkY.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(274, 115);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(106, 32);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "取消(&C)";
            // 
            // btnAccept
            // 
            this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAccept.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccept.Appearance.Options.UseFont = true;
            this.btnAccept.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAccept.Location = new System.Drawing.Point(18, 115);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(124, 32);
            this.btnAccept.TabIndex = 5;
            this.btnAccept.Text = "选中回零(&O)";
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // chkB
            // 
            this.chkB.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource1, "IsZeroB", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkB.Location = new System.Drawing.Point(135, 38);
            this.chkB.Name = "chkB";
            this.chkB.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkB.Properties.Appearance.Options.UseFont = true;
            this.chkB.Properties.Caption = "回退B轴";
            this.chkB.Size = new System.Drawing.Size(109, 29);
            this.chkB.TabIndex = 3;
            // 
            // btnAll
            // 
            this.btnAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAll.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAll.Appearance.Options.UseFont = true;
            this.btnAll.Location = new System.Drawing.Point(148, 115);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(120, 32);
            this.btnAll.TabIndex = 6;
            this.btnAll.Text = "全部回零(&A)";
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // chkZ
            // 
            this.chkZ.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource1, "IsZeroZ", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkZ.Location = new System.Drawing.Point(135, 12);
            this.chkZ.Name = "chkZ";
            this.chkZ.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkZ.Properties.Appearance.Options.UseFont = true;
            this.chkZ.Properties.Caption = "回退Z轴";
            this.chkZ.Size = new System.Drawing.Size(109, 29);
            this.chkZ.TabIndex = 2;
            // 
            // chkC
            // 
            this.chkC.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource1, "IsZeroC", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkC.Location = new System.Drawing.Point(135, 67);
            this.chkC.Name = "chkC";
            this.chkC.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkC.Properties.Appearance.Options.UseFont = true;
            this.chkC.Properties.Caption = "回退C轴";
            this.chkC.Size = new System.Drawing.Size(109, 29);
            this.chkC.TabIndex = 3;
            // 
            // chkW
            // 
            this.chkW.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource1, "IsZeroW", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkW.Location = new System.Drawing.Point(20, 68);
            this.chkW.Name = "chkW";
            this.chkW.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkW.Properties.Appearance.Options.UseFont = true;
            this.chkW.Properties.Caption = "回退W轴";
            this.chkW.Size = new System.Drawing.Size(109, 29);
            this.chkW.TabIndex = 8;
            // 
            // FormToZero
            // 
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(389, 159);
            this.Controls.Add(this.chkW);
            this.Controls.Add(this.chkZ);
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.chkC);
            this.Controls.Add(this.chkB);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.chkY);
            this.Controls.Add(this.chkX);
            this.Location = new System.Drawing.Point(300, 159);
            this.MinimumSize = new System.Drawing.Size(320, 176);
            this.Name = "FormToZero";
            this.ShowInTaskbar = false;
            this.Text = "机械回零";
            ((System.ComponentModel.ISupportInitialize)(this.chkX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkY.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkZ.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkW.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.CheckEdit chkX;
        private DevExpress.XtraEditors.CheckEdit chkY;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnAccept;
        private DevExpress.XtraEditors.CheckEdit chkB;
        private DevExpress.XtraEditors.SimpleButton btnAll;
        private System.Windows.Forms.BindingSource bindingSource1;
        private DevExpress.XtraEditors.CheckEdit chkZ;
        private DevExpress.XtraEditors.CheckEdit chkC;
        private DevExpress.XtraEditors.CheckEdit chkW;
    }
}