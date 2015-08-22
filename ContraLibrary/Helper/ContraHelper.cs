using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraEditors;
using System.Windows.Forms;

namespace ContraLibrary
{
    public class ContraHelper
    {
        public const int Step0 = 1;
        public const int Step1 = 10;
        public const int Step2 = 100;
        public const int Step3 = 1000;
        public const int Step5 = 0;

        public static string FilterPnc = L.R("ContraHelper.FilterPnc", "Pnc文件(*.pnc)|*.pnc|所有文件|*.*");
        public static string FilterCnc = L.R("ContraHelper.FilterCnc", "Cnc脚本文件(*.cnc)|*.cnc|所有文件|*.*");
        public static string FilterTxt = L.R("ContraHelper.FilterTxt", "txt文件(*.txt)|*.txt|所有文件|*.*");
        public static string FilterPck = L.R("ContraHelper.FilterPck", "Pck文件(*.pck)|*.pck|Pnc文件(*.pnc)|*.pnc|Cnc文件(*.cnc)|*.cnc");
        public static string FilterPck2 = L.R("ContraHelper.FilterPck2", "Pck文件(*.pck)|*.pck");

        public static void SetNullableDecimalEditor(TextEdit editor)
        {
            editor.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            editor.Properties.Mask.EditMask = @"-?\d{0,9}(\.\d{0,3})?";
            editor.Properties.Mask.ShowPlaceHolders = false;
        }

        public static void SetIntEditor(TextEdit editor)
        {
            editor.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            editor.Properties.Mask.EditMask = @"\d{0,3}";
            editor.Properties.Mask.ShowPlaceHolders = false;
        }

        public static void ShowMessage(string message)
        {
            FormMessage.ShowMessage(message);
        }

        public static void ShowError(string message)
        {
            FormMessage.ShowMessage(message);
        }

        public static bool ShowQuestion(string message)
        {
            bool flag = FormMessage.ShowQuestion(message);
            return flag;
        }

        public static bool ShowQuestion(string message, int autoCloseSeconds)
        {
            bool flag = FormMessage.ShowQuestion(message, autoCloseSeconds);
            return flag;
        }

        public static DialogResult ShowQuestion2(string message)
        {
            return FormMessage2.ShowQuestion(message);
        }
    }
}
