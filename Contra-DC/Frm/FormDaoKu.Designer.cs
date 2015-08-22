namespace Contra
{
    partial class FormDaoKu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDaoKu));
            this.btnRun = new DevExpress.XtraEditors.SimpleButton();
            this.btnRotate = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // btnRun
            // 
            this.btnRun.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRun.Appearance.Options.UseFont = true;
            this.btnRun.Image = ((System.Drawing.Image)(resources.GetObject("btnRun.Image")));
            this.btnRun.Location = new System.Drawing.Point(12, 12);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(177, 49);
            this.btnRun.TabIndex = 4;
            this.btnRun.Text = "换刀";
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnRotate
            // 
            this.btnRotate.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRotate.Appearance.Options.UseFont = true;
            this.btnRotate.Image = ((System.Drawing.Image)(resources.GetObject("btnRotate.Image")));
            this.btnRotate.Location = new System.Drawing.Point(12, 67);
            this.btnRotate.Name = "btnRotate";
            this.btnRotate.Size = new System.Drawing.Size(177, 49);
            this.btnRotate.TabIndex = 5;
            this.btnRotate.Text = "旋转";
            this.btnRotate.Click += new System.EventHandler(this.btnRotate_Click);
            // 
            // btnClose
            // 
            this.btnClose.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(12, 122);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(177, 49);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FormDaoKu
            // 
            this.ClientSize = new System.Drawing.Size(200, 187);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.btnRotate);
            this.Name = "FormDaoKu";
            this.Text = "刀库控制";
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnRun;
        private DevExpress.XtraEditors.SimpleButton btnRotate;
        private DevExpress.XtraEditors.SimpleButton btnClose;
    }
}