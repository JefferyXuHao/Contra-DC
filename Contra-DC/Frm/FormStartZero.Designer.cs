namespace Contra
{
    partial class FormStartZero
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
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.btnAccept = new DevExpress.XtraEditors.SimpleButton();
            this.chkZ = new DevExpress.XtraEditors.CheckEdit();
            this.chkX = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkZ.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkX.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAccept
            // 
            this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAccept.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccept.Appearance.Options.UseFont = true;
            this.btnAccept.Location = new System.Drawing.Point(14, 54);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(130, 32);
            this.btnAccept.TabIndex = 6;
            this.btnAccept.Text = "选中回零(&O)";
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // chkZ
            // 
            this.chkZ.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource1, "IsZeroAll", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkZ.Enabled = false;
            this.chkZ.Location = new System.Drawing.Point(120, 13);
            this.chkZ.Name = "chkZ";
            this.chkZ.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkZ.Properties.Appearance.Options.UseFont = true;
            this.chkZ.Properties.Caption = "回退所有轴";
            this.chkZ.Size = new System.Drawing.Size(130, 29);
            this.chkZ.TabIndex = 4;
            // 
            // chkX
            // 
            this.chkX.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource1, "IsZeroZ", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkX.Location = new System.Drawing.Point(12, 13);
            this.chkX.Name = "chkX";
            this.chkX.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkX.Properties.Appearance.Options.UseFont = true;
            this.chkX.Properties.Caption = "回退Z轴";
            this.chkX.Size = new System.Drawing.Size(102, 29);
            this.chkX.TabIndex = 3;
            // 
            // FormStartZero
            // 
            this.ClientSize = new System.Drawing.Size(323, 98);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.chkZ);
            this.Controls.Add(this.chkX);
            this.Name = "FormStartZero";
            this.Text = "回零选择";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkZ.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkX.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.CheckEdit chkZ;
        private DevExpress.XtraEditors.CheckEdit chkX;
        private DevExpress.XtraEditors.SimpleButton btnAccept;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}