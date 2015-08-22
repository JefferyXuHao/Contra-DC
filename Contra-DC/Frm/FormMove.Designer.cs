namespace Contra
{
    partial class FormMove
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
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.lbTotalTime = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.btnCMinus = new DevExpress.XtraEditors.SimpleButton();
            this.btnCPlus = new DevExpress.XtraEditors.SimpleButton();
            this.btnBMinus = new DevExpress.XtraEditors.SimpleButton();
            this.btnBPlus = new DevExpress.XtraEditors.SimpleButton();
            this.btnXPlus = new DevExpress.XtraEditors.SimpleButton();
            this.btnYMinus = new DevExpress.XtraEditors.SimpleButton();
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.btnAPlus = new DevExpress.XtraEditors.SimpleButton();
            this.btnXMinus = new DevExpress.XtraEditors.SimpleButton();
            this.btnWMinus = new DevExpress.XtraEditors.SimpleButton();
            this.btnYPlus = new DevExpress.XtraEditors.SimpleButton();
            this.btnWPlus = new DevExpress.XtraEditors.SimpleButton();
            this.btnAMinus = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // lbTotalTime
            // 
            this.lbTotalTime.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalTime.Appearance.Options.UseFont = true;
            this.lbTotalTime.Location = new System.Drawing.Point(32, 423);
            this.lbTotalTime.Name = "lbTotalTime";
            this.lbTotalTime.Size = new System.Drawing.Size(211, 24);
            this.lbTotalTime.TabIndex = 41;
            this.lbTotalTime.Text = "提示：按住Ctrl解除防撞";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.simpleButton1.Location = new System.Drawing.Point(12, 453);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(251, 47);
            this.simpleButton1.TabIndex = 40;
            this.simpleButton1.Text = "关闭";
            // 
            // btnCMinus
            // 
            this.btnCMinus.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCMinus.Appearance.Options.UseFont = true;
            this.btnCMinus.Location = new System.Drawing.Point(211, 367);
            this.btnCMinus.Name = "btnCMinus";
            this.btnCMinus.Size = new System.Drawing.Size(52, 47);
            this.btnCMinus.TabIndex = 39;
            this.btnCMinus.Text = "C-";
            this.btnCMinus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnCMinus_MouseDown);
            this.btnCMinus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_MouseUp);
            // 
            // btnCPlus
            // 
            this.btnCPlus.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCPlus.Appearance.Options.UseFont = true;
            this.btnCPlus.Location = new System.Drawing.Point(211, 311);
            this.btnCPlus.Name = "btnCPlus";
            this.btnCPlus.Size = new System.Drawing.Size(52, 47);
            this.btnCPlus.TabIndex = 38;
            this.btnCPlus.Text = "C+";
            this.btnCPlus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnCPlus_MouseDown);
            this.btnCPlus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_MouseUp);
            // 
            // btnBMinus
            // 
            this.btnBMinus.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBMinus.Appearance.Options.UseFont = true;
            this.btnBMinus.Location = new System.Drawing.Point(143, 367);
            this.btnBMinus.Name = "btnBMinus";
            this.btnBMinus.Size = new System.Drawing.Size(52, 47);
            this.btnBMinus.TabIndex = 35;
            this.btnBMinus.Text = "B-";
            this.btnBMinus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnBMinus_MouseDown);
            this.btnBMinus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_MouseUp);
            // 
            // btnBPlus
            // 
            this.btnBPlus.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBPlus.Appearance.Options.UseFont = true;
            this.btnBPlus.Location = new System.Drawing.Point(143, 311);
            this.btnBPlus.Name = "btnBPlus";
            this.btnBPlus.Size = new System.Drawing.Size(52, 47);
            this.btnBPlus.TabIndex = 34;
            this.btnBPlus.Text = "B+";
            this.btnBPlus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnBPlus_MouseDown);
            this.btnBPlus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_MouseUp);
            // 
            // btnXPlus
            // 
            this.btnXPlus.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXPlus.Appearance.Options.UseFont = true;
            this.btnXPlus.Location = new System.Drawing.Point(46, 194);
            this.btnXPlus.Name = "btnXPlus";
            this.btnXPlus.Size = new System.Drawing.Size(52, 47);
            this.btnXPlus.TabIndex = 26;
            this.btnXPlus.Text = "X+";
            this.btnXPlus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnXPlus_MouseDown);
            this.btnXPlus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_MouseUp);
            // 
            // btnYMinus
            // 
            this.btnYMinus.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnYMinus.Appearance.Options.UseFont = true;
            this.btnYMinus.Location = new System.Drawing.Point(107, 132);
            this.btnYMinus.Name = "btnYMinus";
            this.btnYMinus.Size = new System.Drawing.Size(52, 45);
            this.btnYMinus.TabIndex = 29;
            this.btnYMinus.Text = "Y-";
            this.btnYMinus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnYMinus_MouseDown);
            this.btnYMinus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_MouseUp);
            // 
            // radioGroup1
            // 
            this.radioGroup1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource, "StepLength", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.radioGroup1.Location = new System.Drawing.Point(18, 12);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.radioGroup1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioGroup1.Properties.Appearance.Options.UseBackColor = true;
            this.radioGroup1.Properties.Appearance.Options.UseFont = true;
            this.radioGroup1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "  0.001mm"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(10, "  0.01mm"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(100, "  0.1mm"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1000, "  1mm"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "  连续移动")});
            this.radioGroup1.Size = new System.Drawing.Size(262, 124);
            this.radioGroup1.TabIndex = 25;
            // 
            // btnAPlus
            // 
            this.btnAPlus.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAPlus.Appearance.Options.UseFont = true;
            this.btnAPlus.Location = new System.Drawing.Point(77, 311);
            this.btnAPlus.Name = "btnAPlus";
            this.btnAPlus.Size = new System.Drawing.Size(52, 47);
            this.btnAPlus.TabIndex = 30;
            this.btnAPlus.Text = "Z+";
            this.btnAPlus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnAPlus_MouseDown);
            this.btnAPlus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnAPlus_MouseUp);
            // 
            // btnXMinus
            // 
            this.btnXMinus.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXMinus.Appearance.Options.UseFont = true;
            this.btnXMinus.Location = new System.Drawing.Point(167, 198);
            this.btnXMinus.Name = "btnXMinus";
            this.btnXMinus.Size = new System.Drawing.Size(52, 47);
            this.btnXMinus.TabIndex = 27;
            this.btnXMinus.Text = "X-";
            this.btnXMinus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnXMinus_MouseDown);
            this.btnXMinus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_MouseUp);
            // 
            // btnWMinus
            // 
            this.btnWMinus.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWMinus.Appearance.Options.UseFont = true;
            this.btnWMinus.Location = new System.Drawing.Point(12, 369);
            this.btnWMinus.Name = "btnWMinus";
            this.btnWMinus.Size = new System.Drawing.Size(52, 45);
            this.btnWMinus.TabIndex = 37;
            this.btnWMinus.Text = "W-";
            this.btnWMinus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnWMinus_MouseDown);
            this.btnWMinus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_MouseUp);
            // 
            // btnYPlus
            // 
            this.btnYPlus.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnYPlus.Appearance.Options.UseFont = true;
            this.btnYPlus.Location = new System.Drawing.Point(107, 250);
            this.btnYPlus.Name = "btnYPlus";
            this.btnYPlus.Size = new System.Drawing.Size(52, 46);
            this.btnYPlus.TabIndex = 28;
            this.btnYPlus.Text = "Y+";
            this.btnYPlus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnYPlus_MouseDown);
            this.btnYPlus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_MouseUp);
            // 
            // btnWPlus
            // 
            this.btnWPlus.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWPlus.Appearance.Options.UseFont = true;
            this.btnWPlus.Location = new System.Drawing.Point(12, 311);
            this.btnWPlus.Name = "btnWPlus";
            this.btnWPlus.Size = new System.Drawing.Size(52, 47);
            this.btnWPlus.TabIndex = 36;
            this.btnWPlus.Text = "W+";
            this.btnWPlus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnWPlus_MouseDown);
            this.btnWPlus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_MouseUp);
            // 
            // btnAMinus
            // 
            this.btnAMinus.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAMinus.Appearance.Options.UseFont = true;
            this.btnAMinus.Location = new System.Drawing.Point(77, 367);
            this.btnAMinus.Name = "btnAMinus";
            this.btnAMinus.Size = new System.Drawing.Size(52, 47);
            this.btnAMinus.TabIndex = 31;
            this.btnAMinus.Text = "Z-";
            this.btnAMinus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnAMinus_MouseDown);
            this.btnAMinus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnAMinus_MouseUp);
            // 
            // FormMove
            // 
            this.ClientSize = new System.Drawing.Size(278, 510);
            this.Controls.Add(this.lbTotalTime);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.btnCMinus);
            this.Controls.Add(this.btnCPlus);
            this.Controls.Add(this.btnBMinus);
            this.Controls.Add(this.btnBPlus);
            this.Controls.Add(this.btnXPlus);
            this.Controls.Add(this.btnYMinus);
            this.Controls.Add(this.radioGroup1);
            this.Controls.Add(this.btnAPlus);
            this.Controls.Add(this.btnXMinus);
            this.Controls.Add(this.btnWMinus);
            this.Controls.Add(this.btnYPlus);
            this.Controls.Add(this.btnWPlus);
            this.Controls.Add(this.btnAMinus);
            this.Name = "FormMove";
            this.Text = "运动控制";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSource;
        private DevExpress.XtraEditors.SimpleButton btnCMinus;
        private DevExpress.XtraEditors.SimpleButton btnCPlus;
        private DevExpress.XtraEditors.SimpleButton btnBMinus;
        private DevExpress.XtraEditors.SimpleButton btnBPlus;
        private DevExpress.XtraEditors.SimpleButton btnXPlus;
        private DevExpress.XtraEditors.SimpleButton btnYMinus;
        private DevExpress.XtraEditors.RadioGroup radioGroup1;
        private DevExpress.XtraEditors.SimpleButton btnAPlus;
        private DevExpress.XtraEditors.SimpleButton btnXMinus;
        private DevExpress.XtraEditors.SimpleButton btnWMinus;
        private DevExpress.XtraEditors.SimpleButton btnYPlus;
        private DevExpress.XtraEditors.SimpleButton btnWPlus;
        private DevExpress.XtraEditors.SimpleButton btnAMinus;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.LabelControl lbTotalTime;
        private System.Windows.Forms.Timer timer;
    }
}