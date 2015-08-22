namespace Contra
{
    partial class FormRestart
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
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.txtNewValue = new DevExpress.XtraEditors.TextEdit();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnAccept = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ApplicationIcon = null;
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaximumSize = new System.Drawing.Size(264, 125);
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.ShowToolbarCustomizeItem = false;
            this.ribbonControl1.Size = new System.Drawing.Size(254, 32);
            this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
            // 
            // txtNewValue
            // 
            this.txtNewValue.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource1, "LineNum", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtNewValue.Location = new System.Drawing.Point(99, 50);
            this.txtNewValue.MenuManager = this.ribbonControl1;
            this.txtNewValue.Name = "txtNewValue";
            this.txtNewValue.Size = new System.Drawing.Size(117, 21);
            this.txtNewValue.TabIndex = 5;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(19, 53);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(64, 14);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "重启的行号:";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(99, 97);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(82, 25);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "取消(&C)";
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(10, 97);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(82, 25);
            this.btnAccept.TabIndex = 6;
            this.btnAccept.Text = "确定(&O)";
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // FormRestart
            // 
            this.AcceptButton = this.btnAccept;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(254, 130);
            this.Controls.Add(this.txtNewValue);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.ribbonControl1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(476, 253);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(262, 134);
            this.Name = "FormRestart";
            this.Ribbon = this.ribbonControl1;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "断点重启";
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraEditors.TextEdit txtNewValue;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnAccept;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}