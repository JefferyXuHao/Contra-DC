using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Contra
{
    public partial class AxisItem : UserControl, IBindableComponent
    {
        private decimal valueLogic;
        private decimal valueActual;
        private bool highlight;
        private Color backColor;

        private static object actualDoubleClickHandler = new object();

        public AxisItem()
        {
            InitializeComponent();
            this.backColor = this.BackColor;
        }

        public string AxisText
        {
            get
            {
                return this.labelControl1.Text;
            }
            set
            {
                this.labelControl1.Text = value;
            }
        }

        public string Axis
        {
            get;
            set;
        }

        [Bindable(true)]
        public decimal ValueLogic
        {
            get
            {
                return this.valueLogic;
            }
            set
            {
                if (this.valueLogic != value)
                {
                    this.labelControl3.Text = string.Format("{0:0.000}", value);
                }
                this.valueLogic = value;
            }
        }

        [Bindable(true)]
        public decimal ValueActual
        {
            get
            {
                return this.valueActual;
            }
            set
            {
                if (this.valueActual != value)
                {
                    this.labelControl2.Text = string.Format("{0:0.000}", value);
                }
                this.valueActual = value;
            }
        }

        public bool ShowSmallTitle
        {
            get { return this.labelControl4.Visible; }
            set { this.labelControl4.Visible = value; }
        }

        public bool Highlight
        {
            get { return highlight; }
            set
            {
                highlight = value;
                this.BackColor = highlight == true ? SystemColors.Highlight : backColor;
            }
        }

        public event EventHandler ActualDoubleClick
        {
            add { this.Events.AddHandler(actualDoubleClickHandler, value); }
            remove { this.Events.RemoveHandler(actualDoubleClickHandler, value); }
        }

        private void labelControl2_DoubleClick(object sender, EventArgs e)
        {
            var handler = this.Events[actualDoubleClickHandler] as EventHandler;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
    }
}
