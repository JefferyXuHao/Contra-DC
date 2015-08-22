using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ContraLibrary;

namespace Contra
{
    public partial class FormJiagongTimeSet : FormBase
    {
        public FormJiagongTimeSet(ContraInfo contraInfo)
        {
            InitializeComponent();
            this.spOverTime.Value = contraInfo.JiaGongOverTime;
        }

        public int JiaGongOverTime
        {
            get { return (int)this.spOverTime.Value; }
        }
    }
}
