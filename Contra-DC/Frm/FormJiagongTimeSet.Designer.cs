namespace Contra
{
    partial class FormJiagongTimeSet
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.btnAccept = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.spOverTime = new DevExpress.XtraEditors.SpinEdit();
            this.lbTotalTime = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.spOverTime.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAccept
            // 
            this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAccept.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccept.Appearance.Options.UseFont = true;
            this.btnAccept.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAccept.Location = new System.Drawing.Point(12, 50);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(124, 32);
            this.btnAccept.TabIndex = 6;
            this.btnAccept.Text = "确定(&O)";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.simpleButton1.Location = new System.Drawing.Point(142, 50);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(124, 32);
            this.simpleButton1.TabIndex = 7;
            this.simpleButton1.Text = "关闭(&C)";
            // 
            // spOverTime
            // 
            this.spOverTime.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spOverTime.Location = new System.Drawing.Point(151, 13);
            this.spOverTime.Name = "spOverTime";
            this.spOverTime.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spOverTime.Properties.Appearance.Options.UseFont = true;
            this.spOverTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, false, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.spOverTime.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.spOverTime.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.spOverTime.Properties.MaxValue = new decimal(new int[] {
            6000,
            0,
            0,
            0});
            this.spOverTime.Size = new System.Drawing.Size(111, 26);
            this.spOverTime.TabIndex = 79;
            this.spOverTime.TabStop = false;
            // 
            // lbTotalTime
            // 
            this.lbTotalTime.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalTime.Appearance.Options.UseFont = true;
            this.lbTotalTime.Location = new System.Drawing.Point(12, 12);
            this.lbTotalTime.Name = "lbTotalTime";
            this.lbTotalTime.Size = new System.Drawing.Size(133, 24);
            this.lbTotalTime.TabIndex = 78;
            this.lbTotalTime.Text = "加工超时时间 :";
            // 
            // FormJiagongTimeSet
            // 
            this.ClientSize = new System.Drawing.Size(292, 94);
            this.Controls.Add(this.spOverTime);
            this.Controls.Add(this.lbTotalTime);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.btnAccept);
            this.Name = "FormJiagongTimeSet";
            this.Text = "时间设定";
            ((System.ComponentModel.ISupportInitialize)(this.spOverTime.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnAccept;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SpinEdit spOverTime;
        private DevExpress.XtraEditors.LabelControl lbTotalTime;
    }
}