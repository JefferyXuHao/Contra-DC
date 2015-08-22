namespace Contra
{
    partial class FormSetValue
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSetValue));
            this.btnAccept = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtNewValue = new DevExpress.XtraEditors.TextEdit();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.txtNewValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(10, 97);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(82, 25);
            this.btnAccept.TabIndex = 2;
            this.btnAccept.Text = "确定(&O)";
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(99, 97);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(82, 25);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消(&C)";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(19, 53);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "新坐标值:";
            // 
            // txtNewValue
            // 
            this.txtNewValue.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource1, "Value", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtNewValue.Location = new System.Drawing.Point(86, 50);
            this.txtNewValue.Name = "txtNewValue";
            this.txtNewValue.Properties.DisplayFormat.FormatString = "{0:0.000}";
            this.txtNewValue.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.txtNewValue.Properties.EditFormat.FormatString = "{0:0.000}";
            this.txtNewValue.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.txtNewValue.Size = new System.Drawing.Size(118, 21);
            this.txtNewValue.TabIndex = 1;
            // 
            // FormSetValue
            // 
            this.AcceptButton = this.btnAccept;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(218, 133);
            this.Controls.Add(this.txtNewValue);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(262, 137);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(226, 134);
            this.Name = "FormSetValue";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置坐标值";
            ((System.ComponentModel.ISupportInitialize)(this.txtNewValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnAccept;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtNewValue;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}