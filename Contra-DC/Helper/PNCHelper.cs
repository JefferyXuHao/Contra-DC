using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Reflection;
using System.Xml.Serialization;
using System.Text.RegularExpressions;
using ContraLibrary;

namespace Contra
{
    [Serializable]
    public static class PNCHelper
    {
        public static PNCInfo LoadPnc(string fileName)
        {
            if (File.Exists(fileName))
            {
                try
                {
                    using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(PNCInfo));
                        return serializer.Deserialize(fs) as PNCInfo;
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.LogError(ex);
                }
            }
            return new PNCInfo();
        }

        public static void SavePnc(PNCInfo info, string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(PNCInfo));
                serializer.Serialize(fs, info);
            }
        }

        public static HoleCollection LoadCnc(string fileName, string mode)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    var collection = new HoleCollection();
                    var axisType = "G54";
                    string line = sr.ReadLine().Replace(" ", "");
                    if (string.IsNullOrEmpty(line) || !line.StartsWith("O1234"))
                    {
                        throw new WarningException(L.R("PNCHelper.FileError1", "文件格式错误：缺少开始符!"));
                    }
                    HoleInfo holeInfo = null;
                    int index = 2;
                    Regex reg = new Regex(@"([X,Y,W,B,C])([-]?\d+(\.\d+)?)");
                    while (true)
                    {
                        line = sr.ReadLine().Replace(" ", "");
                        if (!string.IsNullOrEmpty(line))
                        {
                            if (mode == "2")
                            {
                                if (line.StartsWith("G"))
                                {
                                    holeInfo = new HoleInfo() { IsJiaGong = false, AxisType = axisType };
                                    string[] list = line.Split(new char[] { '	' }, StringSplitOptions.RemoveEmptyEntries);
                                    if (list.Length != 7 && list.Length != 8)
                                    {
                                        throw new WarningException("无效的脚本:" + line);
                                    }
                                    holeInfo.AxisType = list[0];
                                    holeInfo.X = Convert.ToDecimal(list[1]);
                                    holeInfo.Y = Convert.ToDecimal(list[2]);
                                    holeInfo.W = Convert.ToDecimal(list[3]);
                                    holeInfo.B = Convert.ToDecimal(list[4]);
                                    holeInfo.C = Convert.ToDecimal(list[5]);
                                    holeInfo.Param = list[6];
                                    if (list.Length == 8)
                                        holeInfo.IsJiaGong = list[7] == "M21";
                                    collection.Add(holeInfo);
                                }
                                else if ((line.StartsWith("M11") || line.StartsWith("M21")) && holeInfo != null)
                                {
                                    holeInfo.IsJiaGong = true;
                                }
                                else if (line.StartsWith("M30"))
                                {
                                    break;
                                }
                                else
                                {
                                    throw new WarningException(L.R("PNCHelper.FileError3", "文件格式错误：无法解析的行[{0}]，行{0}"), line, index);
                                }
                            }
                            else
                            {
                                if (line.StartsWith("G0"))
                                {
                                    holeInfo = new HoleInfo() { IsJiaGong = false, AxisType = axisType };
                                    MatchCollection matchs = reg.Matches(line);
                                    foreach (Match match in matchs)
                                    {
                                        switch (match.Groups[1].Value)
                                        {
                                            case "X": holeInfo.X = Convert.ToDecimal(match.Groups[2].Value); break;
                                            case "Y": holeInfo.Y = Convert.ToDecimal(match.Groups[2].Value); break;
                                            case "W": holeInfo.W = Convert.ToDecimal(match.Groups[2].Value); break;
                                            case "B": holeInfo.B = Convert.ToDecimal(match.Groups[2].Value); break;
                                            case "C": holeInfo.C = Convert.ToDecimal(match.Groups[2].Value); break;
                                        }
                                    }
                                    collection.Add(holeInfo);
                                }
                                else if (line == "G54" || line == "G55" || line == "G56" || line == "G57" || line == "G58" || line == "G59")
                                {
                                    axisType = line;
                                }
                                else if ((line.StartsWith("M11") || line.StartsWith("M21")) && holeInfo != null)
                                {
                                    holeInfo.IsJiaGong = true;
                                }
                                else if (line.StartsWith("M30"))
                                {
                                    break;
                                }
                                else
                                {
                                    throw new WarningException(L.R("PNCHelper.FileError3", "文件格式错误：无法解析的行[{0}]，行{0}"), line, index);
                                }
                            }

                            index++;
                        }
                    }
                    return collection;
                }
            }
        }

        public static void SaveCnc(HoleCollection holes, string fileName, string scriptMode)
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine("O1234");
                    foreach (var item in holes)
                    {
                        if (scriptMode == "2")
                        {
                            sw.Write(item.AxisType);
                            if (item.X.HasValue) sw.Write(string.Format("	{0:0.###}", item.X));
                            if (item.Y.HasValue) sw.Write(string.Format("	{0:0.###}", item.Y));
                            if (item.W.HasValue) sw.Write(string.Format("	{0:0.###}", item.W));
                            if (item.B.HasValue) sw.Write(string.Format("	{0:0.###}", item.B));
                            if (item.C.HasValue) sw.Write(string.Format("	{0:0.###}", item.C));
                            if (item.Param != null) sw.Write(string.Format("	{0}", item.Param));
                            if (item.IsJiaGong == true) sw.Write(string.Format("	{0}", "M21"));
                            sw.WriteLine();
                        }
                        else
                        {
                            sw.WriteLine(item.AxisType);
                            sw.Write("G0");
                            if (item.X.HasValue) sw.Write(string.Format(" X{0:0.###}", item.X));
                            if (item.Y.HasValue) sw.Write(string.Format(" Y{0:0.###}", item.Y));
                            if (item.W.HasValue) sw.Write(string.Format(" W{0:0.###}", item.W));
                            if (item.B.HasValue) sw.Write(string.Format(" B{0:0.###}", item.B));
                            if (item.C.HasValue) sw.Write(string.Format(" C{0:0.###}", item.C));
                            sw.WriteLine();
                            if (item.IsJiaGong)
                            {
                                sw.WriteLine("M21");
                            }
                        }
                    }
                    sw.WriteLine("M30");
                }
            }
        }
    }
}
