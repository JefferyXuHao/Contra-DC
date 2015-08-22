namespace Contra
{
    partial class FrmInputPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInputPassword));
            this.label1 = new System.Windows.Forms.Label();
            this.edit = new DevExpress.XtraEditors.TextEdit();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.edit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "请输入密码:";
            // 
            // edit
            // 
            this.edit.Location = new System.Drawing.Point(89, 15);
            this.edit.Name = "edit";
            this.edit.Properties.PasswordChar = '*';
            this.edit.Size = new System.Drawing.Size(133, 21);
            this.edit.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(103, 52);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(82, 25);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "取消(&C)";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOK.Location = new System.Drawing.Point(15, 52);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(82, 25);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "确定(&O)";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // FrmInputPassword
            // 
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(254, 89);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.edit);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(262, 151);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(262, 122);
            this.Name = "FrmInputPassword";
            this.Text = "输入密码";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmInputPassword_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.edit.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit edit;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOK;
    }
}