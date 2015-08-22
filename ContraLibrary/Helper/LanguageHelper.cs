using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Globalization;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace ContraLibrary
{
    public class LanguageHelper
    {
        private static Dictionary<string, NameValueCollection> languages;

        private static Regex regexIsChinese = new Regex("[一-﨩]");

        private static string path = "Language";
        static LanguageHelper()
        {
            languages = new Dictionary<string, NameValueCollection>();
            string baseDir = Path.Combine(Application.StartupPath, path);
            if (Directory.Exists(baseDir))
            {
                string[] files = Directory.GetFiles(baseDir);
                foreach (var file in files)
                {
                    NameValueCollection collection = GetNameValueCollection(file);
                    string name = Path.GetFileNameWithoutExtension(file);
                    languages.Add(name, collection);
                }
            }
        }

        private static NameValueCollection GetNameValueCollection(string file)
        {
            NameValueCollection collection = new NameValueCollection();
            try
            {
                XDocument document = XDocument.Load(file);
                foreach (var item in document.Descendants("item"))
                {
                    string key = item.Attribute("name").Value;
                    string value = item.Value;
                    collection.Add(key, value);
                }
            }
            catch (Exception)
            {

            }
            return collection;
        }

        private static CultureInfo CurrentCulture
        {
            get { return Thread.CurrentThread.CurrentCulture; }
        }

        public static string GetText(string key, string defaultValue)
        {
            NameValueCollection collection = null;
            String language = CurrentCulture.Name;
            if (languages.TryGetValue(language, out collection))
            {
                string value = collection[key];
                if (value != null)
                {
                    return value;
                }
            }
            return defaultValue;
        }

        public static bool IsContainsChinese(String text)
        {
            if (text == null)
            {
                return false;
            }
            return regexIsChinese.IsMatch(text);
        }

        public static void SetLanguage(string language)
        {
            if (!string.IsNullOrEmpty(language))
            {
                try
                {
                    Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(language);
                }
                catch (Exception)
                {

                }
            }
        }

    }
}
