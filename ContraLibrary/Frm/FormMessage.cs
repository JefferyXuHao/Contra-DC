using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ContraLibrary;

namespace ContraLibrary
{
    public partial class FormMessage : FormBase
    {
        private Timer timer;

        public FormMessage(string message, bool isQuestion, int autoCloseSeconds, FormClosedEventHandler closeHandler)
        {
            InitializeComponent();
            this.labelControl15.Text = message;
            this.btnYes.Visible = isQuestion;
            this.btnNo.Visible = isQuestion;
            this.btnOK.Visible = !isQuestion;
            if (closeHandler != null)
            {
                this.FormClosed += closeHandler;
            }
            if (autoCloseSeconds != 0)
            {
                timer = new Timer();
                timer.Interval = autoCloseSeconds * 1000;
                timer.Tick += (sender, e) => { 
                    this.DialogResult = System.Windows.Forms.DialogResult.Yes; 
                    this.Close(); };
                timer.Start();
            }
        }

        public static void ShowMessage(string message)
        {
            FormMessage formMessage = new FormMessage(message, false, 0, null);
            formMessage.ShowDialog();
        }

        public static void ShowMessage(string message, FormClosedEventHandler closeHandler)
        {
            FormMessage formMessage = new FormMessage(message, false, 0, closeHandler);
            formMessage.ShowDialog();
        }

        public static bool ShowQuestion(string message, int autoCloseSeconds)
        {
            FormMessage formMessage = new FormMessage(message, true, autoCloseSeconds, null);
            return formMessage.ShowDialog() == DialogResult.Yes;
        }

        public static bool ShowQuestion(string message)
        {
            FormMessage formMessage = new FormMessage(message, true, 0, null);
            return formMessage.ShowDialog() == DialogResult.Yes;
        }
    }


}
