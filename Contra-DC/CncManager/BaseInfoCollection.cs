using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using ContraLibrary;

namespace Contra
{
    public class BaseInfoCollection : List<BaseInfo>, ICloneable
    {
        public BaseInfoCollection()
        {

        }

        public BaseInfoCollection(string fileName)
        {
            StreamReader reader = null;
            try
            {
                reader = new StreamReader(fileName);
                this.Clear();
                string line = null;
                while ((line = reader.ReadLine()) != null)
                {
                    this.Add(CreateBaseInfoByString(line));
                }
                this.Calclate();
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }

        }

        public string CreateString()
        {
            StringBuilder build = new StringBuilder();
            foreach (BaseInfo info in this)
            {
                build.AppendLine(info.Value);
            }
            return build.ToString();
        }

        public static BaseInfo CreateBaseInfoByString(string line)
        {
            line = line.ToUpper();
            BaseInfo info = null;
            try
            {
                if (In(line, HeadType.G90, HeadType.G91)) info = new HeadInfo(line);
                else if (In(line, HeadType.G0)) info = new SingleMoveInfo(line);
                else if (In(line, HeadType.G1)) info = new UnionMoveInfo(line);
                else if (In(line, HeadType.M21)) info = new M21Info(line);
                else if (In(line, HeadType.Start)) info = new StartInfo(line);
                else if (In(line, HeadType.M30)) info = new EndInfo(line);
                else if (In(line, HeadType.M98)) info = new ChildInfo(line);
                else if (In(line, HeadType.M99))
                    info = new OtherInfo(line);
                else throw new Exception();
            }
            catch (Exception)
            {
                throw new WarningException(L.R("BaseInfoCollection.NotAnalyse", "行{0}未能解析!"), line);
            }
            return info;
        }

        public void Calclate()
        {
            int lineCount = 1;
            foreach (BaseInfo info in this)
            {
                info.LineNum = lineCount++;
            }
        }

        public static bool In(string line, params string[] headTypes)
        {
            foreach (string item in headTypes)
            {
                if (line.StartsWith(item)) return true;
            }
            return false;
        }

        public BaseInfo Add(params string[] items)
        {
            if (items != null)
            {
                string value = string.Join(" ", items);
                BaseInfo info = CreateBaseInfoByString(value);
                this.Add(info);
                this.Calclate();
                return info;
            }
            return null;
        }

        public new BaseInfo Add(BaseInfo info)
        {
            if (info != null)
            {
                base.Add(info);
                this.Calclate();
            }
            return info;
        }

        public BaseInfo Insert(int index, params string[] items)
        {
            if (items != null)
            {
                string value = string.Join(" ", items);
                BaseInfo info = CreateBaseInfoByString(value);
                this.Insert(index, info);
                this.Calclate();
                return info;
            }
            return null;
        }

        public new BaseInfo Insert(int index, BaseInfo info)
        {
            if (info != null)
            {
                base.Insert(index, info);
                this.Calclate();
            }
            return info;
        }

        #region ICloneable 成员

        public object Clone()
        {
            BaseInfoCollection cloneTable = new BaseInfoCollection();

            foreach (BaseInfo record in this)
            {
                cloneTable.Add((BaseInfo)record.Clone());
            }
            return cloneTable;
        }

        #endregion
    }
}
