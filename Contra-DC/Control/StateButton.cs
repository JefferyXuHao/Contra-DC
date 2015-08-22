using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using System.ComponentModel;
using Contra.Properties;

namespace Contra
{
    public class StateButton : SimpleButton
    {
        public StateButton()
        {
            this.Image = Resources.off;
            this.ValueChanged += new EventHandler(StateButton_ValueChanged);
        }

        void StateButton_ValueChanged(object sender, EventArgs e)
        {
            switch (this.Value)
            {
                case 1: this.Image = Resources.cc; break;//黄色
                case 2: this.Image = Resources.off; break; //绿色
                default: this.Image = Resources.on; break;//红色
            }
        }

        private static object EventValue = new object();

        public event EventHandler ValueChanged
        {
            add { this.Events.AddHandler(EventValue, value); }
            remove { this.Events.RemoveHandler(EventValue, value); }
        }

        protected virtual void OnValueChanged(EventArgs e)
        {
            EventHandler handler = base.Events[EventValue] as EventHandler;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        private int value;
        [Bindable(true)]
        public int Value
        {
            get { return this.value; }
            set
            {
                if (this.value != value)
                {
                    this.value = value;
                    OnValueChanged(EventArgs.Empty);
                }
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }
    }
}
