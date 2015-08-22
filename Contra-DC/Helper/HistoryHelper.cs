using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using ContraLibrary;

namespace Contra
{
    public class HistoryHelper
    {
        public static void Save(string fileName, List<JiagongHistoryInfo> list)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(string.Format(L.R("HistoryHelper.Format", "行号\t坐标系\tX\tY\tW\tB\tC\t设定深度\t穿透深度\t铜管损耗\t孔深")));
                    foreach (var item in list)
                    {
                        sw.WriteLine(string.Format("{0}\t{1}\t{2:0.000}\t{3:0.000}\t{4:0.000}\t{5:0.000}\t{6:0.000}\t{7:0.000}\t{8:0.000}\t{9:0.000}\t{10:0.000}", item.Line, item.AxisType, item.X, item.Y, item.W, item.B, item.C, item.MachineHeight, item.ThrowHeight, item.ZeroHeight, item.HoleHeight));
                    }
                }
            }
        }
    }
}
