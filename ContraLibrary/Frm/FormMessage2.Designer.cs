namespace ContraLibrary
{
    partial class FormMessage2
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
            this.btnNo = new DevExpress.XtraEditors.SimpleButton();
            this.btnYes = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // btnNo
            // 
            this.btnNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNo.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNo.Appearance.Options.UseFont = true;
            this.btnNo.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnNo.Location = new System.Drawing.Point(124, 95);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(97, 50);
            this.btnNo.TabIndex = 25;
            this.btnNo.Text = "否";
            // 
            // btnYes
            // 
            this.btnYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnYes.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnYes.Appearance.Options.UseFont = true;
            this.btnYes.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnYes.Location = new System.Drawing.Point(12, 95);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(106, 50);
            this.btnYes.TabIndex = 24;
            this.btnYes.Text = "是";
            // 
            // labelControl15
            // 
            this.labelControl15.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl15.Appearance.Options.UseFont = true;
            this.labelControl15.Appearance.Options.UseTextOptions = true;
            this.labelControl15.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.labelControl15.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl15.Location = new System.Drawing.Point(16, 12);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Size = new System.Drawing.Size(311, 77);
            this.labelControl15.TabIndex = 23;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.simpleButton1.Location = new System.Drawing.Point(227, 95);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(106, 50);
            this.simpleButton1.TabIndex = 26;
            this.simpleButton1.Text = "更换电极";
            // 
            // FormMessage2
            // 
            this.ClientSize = new System.Drawing.Size(339, 156);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.btnYes);
            this.Controls.Add(this.labelControl15);
            this.Name = "FormMessage2";
            this.Text = "提示信息";
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnNo;
        private DevExpress.XtraEditors.SimpleButton btnYes;
        private DevExpress.XtraEditors.LabelControl labelControl15;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}