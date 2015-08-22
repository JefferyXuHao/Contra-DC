using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace Contra
{
    public class BaseInfo : ICloneable
    {
        public BaseInfo()
        {

        }

        protected BaseInfo(string text)
        {
            ResolveText(text);
        }

        public void SetValue(string text)
        {
            ResolveText(text);
        }

        private void ResolveText(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                string[] list = text.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                ValidateCount(list.Length);
                ResolveText(list);
            }
        }

        private void ValidateCount(int count)
        {
            if (count != StringCount)
            {
                //throw new Exception(string.Format("Cnc文件有错误,位置:{0}", textValue));
            }
        }

        protected virtual int StringCount { get { return 2; } }

        protected virtual void ResolveText(string[] list)
        {

        }

        public override string ToString()
        {
            return string.Format("L{0}:{1}", LineNum, this.Value);
        }

        public string Text
        {
            get
            {
                return string.Format("L{0}:{1}", LineNum, this.Value);
            }
        }

        public virtual string Value
        {
            get { return null; }
        }

        public int LineNum
        {
            get;
            set;
        }


        #region ICloneable 成员

        public object Clone()
        {
            Type type = this.GetType();
            BaseInfo record = (BaseInfo)Activator.CreateInstance(type);
            foreach (PropertyInfo property in type.GetProperties())
            {
                if (property.CanRead && property.CanWrite && property.GetIndexParameters().Length == 0)
                {
                    property.SetValue(record, property.GetValue(this, null), null);
                }
            }
            return record;
        }

        #endregion
    }
}
