namespace Contra
{
    partial class FormWarning
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnHide = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 14;
            this.listBox1.Location = new System.Drawing.Point(4, 3);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(393, 172);
            this.listBox1.TabIndex = 0;
            // 
            // btnHide
            // 
            this.btnHide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnHide.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnHide.Location = new System.Drawing.Point(161, 181);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(75, 25);
            this.btnHide.TabIndex = 16;
            this.btnHide.Text = "确定";
            this.btnHide.Click += new System.EventHandler(this.btnHide_Click);
            // 
            // FormWarning
            // 
            this.ClientSize = new System.Drawing.Size(401, 211);
            this.Controls.Add(this.btnHide);
            this.Controls.Add(this.listBox1);
            this.Name = "FormWarning";
            this.Text = "报警";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private DevExpress.XtraEditors.SimpleButton btnHide;
    }
}