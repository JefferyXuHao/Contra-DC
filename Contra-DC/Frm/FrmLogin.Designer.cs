namespace Contra
{
    partial class FrmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.btnReg = new DevExpress.XtraEditors.SimpleButton();
            this.btnLogin = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // btnReg
            // 
            this.btnReg.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReg.Appearance.Options.UseFont = true;
            this.btnReg.Location = new System.Drawing.Point(12, 84);
            this.btnReg.Name = "btnReg";
            this.btnReg.Size = new System.Drawing.Size(305, 56);
            this.btnReg.TabIndex = 20;
            this.btnReg.Text = "注册";
            this.btnReg.Click += new System.EventHandler(this.btnReg_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Appearance.Options.UseFont = true;
            this.btnLogin.Location = new System.Drawing.Point(12, 12);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(305, 55);
            this.btnLogin.TabIndex = 19;
            this.btnLogin.Text = "启动";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // FrmLogin
            // 
            this.ClientSize = new System.Drawing.Size(329, 161);
            this.Controls.Add(this.btnReg);
            this.Controls.Add(this.btnLogin);
            this.Name = "FrmLogin";
            this.Text = "登录";
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnLogin;
        private DevExpress.XtraEditors.SimpleButton btnReg;
    }
}