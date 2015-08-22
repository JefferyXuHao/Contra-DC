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
    public partial class FormMessage2 : FormBase
    {
        public FormMessage2(string message)
        {
            InitializeComponent();
            this.labelControl15.Text = message;
        }

        public static DialogResult ShowQuestion(string message)
        {
            FormMessage2 formMessage = new FormMessage2(message);
            return formMessage.ShowDialog();
        }
    }
}
