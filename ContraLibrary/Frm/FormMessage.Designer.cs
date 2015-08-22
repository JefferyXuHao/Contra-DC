namespace ContraLibrary
{
    partial class FormMessage
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
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            this.btnYes = new DevExpress.XtraEditors.SimpleButton();
            this.btnNo = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOK.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Appearance.Options.UseFont = true;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(14, 98);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(313, 50);
            this.btnOK.TabIndex = 17;
            this.btnOK.Text = "确定";
            // 
            // labelControl15
            // 
            this.labelControl15.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl15.Appearance.Options.UseFont = true;
            this.labelControl15.Appearance.Options.UseTextOptions = true;
            this.labelControl15.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.labelControl15.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl15.Location = new System.Drawing.Point(14, 14);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Size = new System.Drawing.Size(311, 77);
            this.labelControl15.TabIndex = 20;
            // 
            // btnYes
            // 
            this.btnYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnYes.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnYes.Appearance.Options.UseFont = true;
            this.btnYes.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnYes.Location = new System.Drawing.Point(14, 98);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(150, 50);
            this.btnYes.TabIndex = 21;
            this.btnYes.Text = "是";
            // 
            // btnNo
            // 
            this.btnNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNo.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNo.Appearance.Options.UseFont = true;
            this.btnNo.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnNo.Location = new System.Drawing.Point(177, 98);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(150, 50);
            this.btnNo.TabIndex = 22;
            this.btnNo.Text = "否";
            // 
            // FormMessage
            // 
            this.ClientSize = new System.Drawing.Size(339, 156);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.btnYes);
            this.Controls.Add(this.labelControl15);
            this.Controls.Add(this.btnOK);
            this.Name = "FormMessage";
            this.Text = "提示信息";
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.LabelControl labelControl15;
        private DevExpress.XtraEditors.SimpleButton btnYes;
        private DevExpress.XtraEditors.SimpleButton btnNo;
    }
}