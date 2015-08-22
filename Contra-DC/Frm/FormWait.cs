using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using DevExpress.XtraEditors;
using ContraLibrary;
using Contra.Properties;

namespace Contra
{
    public partial class FormWait : FormBase
    {
        Thread thread;
        public AutoResetEvent Ar;

        public FormWait()
        {
            Ar = new AutoResetEvent(false);
            InitializeComponent();
            thread = new Thread(() => OnShowWait());

            
        }

        private void OnShowWait()
        {
            string language = Settings.Default.Set.OtherSet.LanguageType;
            LanguageHelper.SetLanguage(language);
            if (this.label1.InvokeRequired)
            {
                RaiseEvent();
                this.label1.Invoke(new WaitEventHandler(OnShowWait));
            }
            else
            {
                Thread.Sleep(1000);
                this.Close();
            }
        }

        private void RaiseEvent()
        {
            if (WaitEvent != null)
            {
                WaitEvent();
            }
        }

        public event WaitEventHandler WaitEvent;

        public void SetProgressText(string text)
        {
            if (this.label1.InvokeRequired)
            {
                //this.label1.Invoke(new WaitShowHandler(SetProgressText), text);
            }
            else
            {
                this.label1.Text = text;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            thread.Start();
        }
    }
}
