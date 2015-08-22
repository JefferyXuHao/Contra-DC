using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ContraLibrary;
using System.Threading;
using System.Globalization;
using Contra.Properties;

namespace Contra
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            LogHelper.Init2();
            LogHelper.LogInfo("程序启动");
            SetInfo.InitSet();
            string language = Settings.Default.Set.OtherSet.LanguageType;
            LanguageHelper.SetLanguage(language);
            DevExpress.UserSkins.OfficeSkins.Register();
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                FrmLogin login = new FrmLogin();
                if (login.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new FormMain());
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex);

            }

        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            ContraHelper.ShowError(e.Exception.Message);
            LogHelper.LogError(e.Exception);
        }
    }
}
