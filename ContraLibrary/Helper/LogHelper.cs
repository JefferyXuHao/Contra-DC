using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using System.IO;
using System.Windows.Forms;

namespace ContraLibrary
{
    public static class LogHelper
    {
        private static ILog fileLog = LogManager.GetLogger("FileLogger");

        public static void Init2(string configFileName = "log4net.config")
        {
            var filePath = Path.Combine(Application.StartupPath, configFileName);
            log4net.Config.XmlConfigurator.Configure(new FileInfo(filePath));
            fileLog = LogManager.GetLogger("FileLogger");
        }

        public static void LogInfo(string info)
        {
            if (fileLog != null)
                fileLog.Info(info);
        }

        public static void LogError(Exception e)
        {
            if (fileLog != null)
                fileLog.Error("", e);
        }
    }
}
