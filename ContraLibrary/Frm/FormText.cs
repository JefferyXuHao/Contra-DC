using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ContraLibrary
{
    public partial class FormText : FormBase
    {
        public FormText()
        {
            InitializeComponent();
        }

        public void SetText(String text)
        {
            this.textBox1.Text = text;
        }
    }
}
