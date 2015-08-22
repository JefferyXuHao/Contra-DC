using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Contra.Properties;

namespace Contra
{
    public class CloseButton : PictureBox
    {
        public CloseButton()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // CloseButton
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Image = global::Contra.Properties.Resources.Close2;
            this.Size = new System.Drawing.Size(66, 66);
            this.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.MouseLeave += new System.EventHandler(this.CloseButton_MouseLeave);
            this.MouseHover += new System.EventHandler(this.CloseButton_MouseHover);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        private void CloseButton_MouseHover(object sender, EventArgs e)
        {
            //this.Image = Resources.Close2;
        }

        private void CloseButton_MouseLeave(object sender, EventArgs e)
        {
            //this.Image = Resources.Close1;
        }
    }
}
