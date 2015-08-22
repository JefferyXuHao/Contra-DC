using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Reflection;
using System.Xml.Serialization;

namespace ContraLibrary
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
                catch (Exception)
                {
                }
            }
            return new PNCInfo();

            //if (File.Exists(fileName))
            //{
            //    try
            //    {
            //        XmlDocument document = new XmlDocument();
            //        document.Load(fileName);
            //        XmlNodeList nodes = document.SelectNodes("Holes/Hole");
            //        foreach (XmlNode node in nodes)
            //        {
            //            var holeInfo = new HoleInfo()
            //            {
            //                X = XmlHelper.GetDecimalValue(node, "X"),
            //                Y = XmlHelper.GetDecimalValue(node, "Y"),
            //                W = XmlHelper.GetDecimalValue(node, "W"),
            //                B = XmlHelper.GetDecimalValue(node, "B"),
            //                C = XmlHelper.GetDecimalValue(node, "C"),
            //                Param = XmlHelper.GetStringValue(node, "Param"),
            //                IsJiaGong = XmlHelper.GetBoolValue(node, "Jiagong")
            //            };
            //            info.Holes.Add(holeInfo);
            //        }
            //        for (int i = 1; i <= 10; i++)
            //        {
            //            string propertyName = string.Format("E{0}", i);
            //            nodes = document.SelectNodes(string.Format("Params/{0}/Param", propertyName));
            //            if (nodes.Count > 0)
            //            {
            //                ParamList list = new ParamList();
            //                foreach (XmlNode item in nodes)
            //                {
            //                    ParamInfo paramInfo = new ParamInfo();
            //                    paramInfo.TOn = XmlHelper.GetIntValue(item, "TOn");
            //                    paramInfo.TOff = XmlHelper.GetIntValue(item, "TOff");
            //                    paramInfo.I = XmlHelper.GetIntValue(item, "I");
            //                    paramInfo.I2 = XmlHelper.GetIntValue(item, "I2");
            //                    paramInfo.Depth = XmlHelper.GetDecimalValue(item, "Depth");
            //                    paramInfo.Depth2 = XmlHelper.GetDecimalValue(item, "Depth2");
            //                    paramInfo.StopTime = XmlHelper.GetIntValue(item, "StopTime");
            //                    paramInfo.Fanjixing = XmlHelper.GetBoolValue(item, "Fanjixing");
            //                    paramInfo.Rotate = XmlHelper.GetBoolValue(item, "Rotate");
            //                    list.Add(paramInfo);
            //                }
            //                PropertyInfo property = typeof(TControlList).GetProperty(propertyName);
            //                if (property != null)
            //                {
            //                    property.SetValue(list, list, null);
            //                }
            //            }
            //        }
            //    }
            //    catch
            //    {
            //    }
            //}
            //return info;
        }

        public static void SavePnc(PNCInfo info, string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(PNCInfo));
                serializer.Serialize(fs, info);
            }
            //XmlDocument document = new XmlDocument();
            //XmlElement parent = XmlHelper.AppendNode(document, "Holes");
            //foreach (HoleInfo hole in info.Holes)
            //{
            //    XmlElement child = XmlHelper.AppendNode(document, parent, "Hole");
            //    XmlHelper.AppendAttribute(document, child, "X", hole.X.ToString());
            //    XmlHelper.AppendAttribute(document, child, "Y", hole.Y.ToString());
            //    XmlHelper.AppendAttribute(document, child, "W", hole.W.ToString());
            //    XmlHelper.AppendAttribute(document, child, "B", hole.B.ToString());
            //    XmlHelper.AppendAttribute(document, child, "C", hole.C.ToString());
            //    XmlHelper.AppendAttribute(document, child, "Param", hole.Param.ToString());
            //    XmlHelper.AppendAttribute(document, child, "Jiagong", hole.IsJiaGong.ToString());
            //}
            //parent = XmlHelper.AppendNode(document, "Params");
            //PropertyInfo[] properties = info.Params.GetType().GetProperties();
            //foreach (var property in properties)
            //{
            //    ParamList list = property.GetValue(info.Params, null) as ParamList;
            //    if (list != null)
            //    {
            //        list.Add()
            //    }


            //    XmlElement child = XmlHelper.AppendNode(document, parent, "");
            //    XmlHelper.AppendAttribute(document, child, "X", hole.X.ToString());
            //    XmlHelper.AppendAttribute(document, child, "Y", hole.Y.ToString());
            //    XmlHelper.AppendAttribute(document, child, "W", hole.W.ToString());
            //    XmlHelper.AppendAttribute(document, child, "B", hole.B.ToString());
            //    XmlHelper.AppendAttribute(document, child, "C", hole.C.ToString());
            //    XmlHelper.AppendAttribute(document, child, "Param", hole.Param.ToString());
            //    XmlHelper.AppendAttribute(document, child, "Jiagong", hole.IsJiaGong.ToString());
            //}
            //if (File.Exists(filePath))
            //    File.Delete(filePath);
            //document.Save(filePath);
        }
    }
}
