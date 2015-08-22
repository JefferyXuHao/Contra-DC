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
    public partial class AxisControl : UserControl
    {
        private static object actualDoubleClickHandler = new object();
        private int itemHeight = 68;

        public AxisControl()
        {
            InitializeComponent();
            foreach (AxisItem control in this.Controls)
            {
                control.ActualDoubleClick += new EventHandler(ItemActualDoubleClick);
                control.Height = itemHeight;
            }
        }

        public void SetBinding(BindingSource bsSource, string axixType)
        {
            string suffix = "";
            if (axixType != "G54")
            {
                suffix = axixType.Replace("G", "");
            }
            foreach (AxisItem control in this.Controls)
            {
                control.DataBindings.Clear();
                control.DataBindings.Add("ValueLogic", bsSource, "LogPos" + control.Axis, true, DataSourceUpdateMode.OnPropertyChanged);
                control.DataBindings.Add("ValueActual", bsSource, "ActPos" + control.Axis + suffix, true, DataSourceUpdateMode.OnPropertyChanged);
            }
        }

        public void SetHighlightAxis(string axis)
        {
            foreach (AxisItem control in this.Controls)
            {
                if (control != null)
                {
                    control.Highlight = axis == control.Axis;
                }
            }
        }

        public void SetVisible(AxisSetInfo axisInfo)
        {
            this.axisItem1.Visible = !axisInfo.IgnoreX;
            this.axisItem2.Visible = !axisInfo.IgnoreY;
            this.axisItem3.Visible = !axisInfo.IgnoreW;
            this.axisItem4.Visible = !axisInfo.IgnoreB;
            this.axisItem5.Visible = !axisInfo.IgnoreC;
            this.axisItem6.Visible = !axisInfo.IgnoreZ;
        }

        public int ItemHeight
        {
            get { return this.itemHeight; }
            set
            {
                this.itemHeight = value;
                foreach (AxisItem control in this.Controls)
                {
                    control.Height = itemHeight;
                }
            }
        }

        public event EventHandler ActualDoubleClick
        {
            add { this.Events.AddHandler(actualDoubleClickHandler, value); }
            remove { this.Events.RemoveHandler(actualDoubleClickHandler, value); }
        }

        public void ItemActualDoubleClick(object sender, EventArgs e)
        {
            var handler = this.Events[actualDoubleClickHandler] as EventHandler;
            if (handler != null)
            {
                handler(sender, EventArgs.Empty);
            }
        }
    }
}
