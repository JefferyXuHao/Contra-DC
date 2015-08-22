using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using ContraLibrary;

namespace Contra
{
    public class PCKHelper
    {
        public static List<PCKStandardInfo> LoadPck(string fileName)
        {
            if (File.Exists(fileName))
            {
                try
                {
                    using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(List<PCKStandardInfo>));
                        return serializer.Deserialize(fs) as List<PCKStandardInfo>;
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.LogError(ex);
                }
            }
            return new List<PCKStandardInfo>();
        }

        public static List<PCKStandardInfo> LoadPnc(string fileName)
        {
            List<PCKStandardInfo> list = new List<PCKStandardInfo>();
            var pncInfo = PNCHelper.LoadPnc(fileName);
            foreach (var item in pncInfo.Holes)
            {
                PCKStandardInfo pckInfo = new PCKStandardInfo();
                pckInfo.AxisType = item.AxisType;
                pckInfo.X = item.X;
                pckInfo.Y = item.Y;
                pckInfo.W = item.W;
                pckInfo.B = item.C;
                pckInfo.C = item.C;
                list.Add(pckInfo);
            }
            return list;
        }

        public static List<PCKStandardInfo> LoadCnc(string fileName, string scriptMode)
        {
            List<PCKStandardInfo> list = new List<PCKStandardInfo>();
            var holes = PNCHelper.LoadCnc(fileName, scriptMode);
            foreach (var item in holes)
            {
                PCKStandardInfo pckInfo = new PCKStandardInfo();
                pckInfo.AxisType = item.AxisType;
                pckInfo.X = item.X;
                pckInfo.Y = item.Y;
                pckInfo.W = item.W;
                pckInfo.B = item.C;
                pckInfo.C = item.C;
                list.Add(pckInfo);
            }
            return list;
        }

        public static void SavePck(List<PCKStandardInfo> list, string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<PCKStandardInfo>));
                serializer.Serialize(fs, list);
            }
        }
    }
}
