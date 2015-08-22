using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using ContraLibrary;

namespace Contra
{
    public class ParamCollection
    {
        public ParamCollection()
        {
            E1 = new ParamList();
            E2 = new ParamList();
            E3 = new ParamList();
            E4 = new ParamList();
            E5 = new ParamList();
            E6 = new ParamList();
            E7 = new ParamList();
            E8 = new ParamList();
            E9 = new ParamList();
            E10 = new ParamList();
            E11 = new ParamList();
            E12 = new ParamList();
            E13 = new ParamList();
            E14 = new ParamList();
            E15 = new ParamList();
            E16 = new ParamList();
            E17 = new ParamList();
            E18 = new ParamList();
            E19 = new ParamList();
            E20 = new ParamList();
            E21 = new ParamList();
            E22 = new ParamList();
            E23 = new ParamList();
            E24 = new ParamList();
            E25 = new ParamList();
            E26 = new ParamList();
            E27 = new ParamList();
            E28 = new ParamList();
            E29 = new ParamList();
            E30 = new ParamList();
            手动 = new ParamList();
        }

        public ParamList this[string name]
        {
            get
            {
                if (name == L.R("ParamCollection.Manual", "手动"))
                {
                    return 手动;
                }
                switch (name)
                {
                    case "E1": return E1;
                    case "E2": return E2;
                    case "E3": return E3;
                    case "E4": return E4;
                    case "E5": return E5;
                    case "E6": return E6;
                    case "E7": return E7;
                    case "E8": return E8;
                    case "E9": return E9;
                    case "E10": return E10;
                    case "E11": return E11;
                    case "E12": return E12;
                    case "E13": return E13;
                    case "E14": return E14;
                    case "E15": return E15;
                    case "E16": return E16;
                    case "E17": return E17;
                    case "E18": return E18;
                    case "E19": return E19;
                    case "E20": return E20;
                    case "E21": return E21;
                    case "E22": return E22;
                    case "E23": return E23;
                    case "E24": return E24;
                    case "E25": return E25;
                    case "E26": return E26;
                    case "E27": return E27;
                    case "E28": return E28;
                    case "E29": return E29;
                    case "E30": return E30;
                }
                return E1;
            }
        }

        public ParamList E1 { get; set; }
        public ParamList E2 { get; set; }
        public ParamList E3 { get; set; }
        public ParamList E4 { get; set; }
        public ParamList E5 { get; set; }
        public ParamList E6 { get; set; }
        public ParamList E7 { get; set; }
        public ParamList E8 { get; set; }
        public ParamList E9 { get; set; }
        public ParamList E10 { get; set; }
        public ParamList E11 { get; set; }
        public ParamList E12 { get; set; }
        public ParamList E13 { get; set; }
        public ParamList E14 { get; set; }
        public ParamList E15 { get; set; }
        public ParamList E16 { get; set; }
        public ParamList E17 { get; set; }
        public ParamList E18 { get; set; }
        public ParamList E19 { get; set; }
        public ParamList E20 { get; set; }
        public ParamList E21 { get; set; }
        public ParamList E22 { get; set; }
        public ParamList E23 { get; set; }
        public ParamList E24 { get; set; }
        public ParamList E25 { get; set; }
        public ParamList E26 { get; set; }
        public ParamList E27 { get; set; }
        public ParamList E28 { get; set; }
        public ParamList E29 { get; set; }
        public ParamList E30 { get; set; }
        public ParamList 手动 { get; set; }
        //[XmlIgnore]
        //public ParamList 手动
        //{
        //    get { return _手动; }
        //    set { _手动 = value; }
        //}
    }
}
