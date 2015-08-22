using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contra
{
    public class HoleCollection : List<HoleInfo>, ICloneable
    {
        public BaseInfoCollection ToScript()
        {
            BaseInfoCollection collection = new BaseInfoCollection();
            collection.Add(new StartInfo());
            foreach (var hole in this)
            {
                collection.Add(new SingleMoveInfo()
                {
                    X = hole.X,
                    Y = hole.Y,
                    W = hole.W,
                    B = hole.B,
                    C = hole.C,
                    Param = hole.Param
                });
                if (hole.IsJiaGong)
                {
                    collection.Add(new M21Info());
                }
            }
            collection.Add(new EndInfo());
            return collection;
        }

        public static HoleCollection LoadFromFile(string fileName)
        {
            BaseInfoCollection collection = new BaseInfoCollection(fileName);
            HoleCollection holeCollection = new HoleCollection();
            for (int i = 0; i < collection.Count; i++)
            {
                var baseInfo = collection[i];
                if (baseInfo is SingleMoveInfo)
                {
                    var singleMove = baseInfo as SingleMoveInfo;
                    var holeInfo = new HoleInfo()
                    {
                        X = singleMove.X,
                        Y = singleMove.Y,
                        W = singleMove.W,
                        B = singleMove.B,
                        C = singleMove.C,
                        Param = singleMove.Param
                    };
                    if (i < collection.Count - 1 && collection[i + 1] is M21Info)
                    {
                        holeInfo.IsJiaGong = true;
                    }
                    holeCollection.Add(holeInfo);
                }
            }
            return holeCollection;
        }

        public object Clone()
        {
            var newCollection = new HoleCollection();
            foreach (var item in this)
            {
                newCollection.Add(item.Clone() as HoleInfo);
            }
            return newCollection;
        }
    }
}
