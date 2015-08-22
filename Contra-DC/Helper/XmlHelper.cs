using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using Microsoft.VisualBasic;
using System.IO.Compression;

namespace Contra
{
    internal static class XmlHelper
    {
        public static XmlElement AppendNode(XmlDocument document, string name)
        {
            XmlElement element = document.CreateElement(name);
            document.AppendChild(element);
            return element;
        }

        public static XmlElement AppendNode(XmlDocument document, XmlElement parentNode, string name)
        {
            XmlElement element = document.CreateElement(name);
            parentNode.AppendChild(element);
            return element;
        }

        public static XmlAttribute AppendAttribute(XmlDocument document, XmlElement parentNode, string name, string value)
        {
            XmlAttribute attribute = document.CreateAttribute(name);
            attribute.Value = value;
            parentNode.Attributes.Append(attribute);
            return attribute;
        }

        public static decimal GetDecimalValue(XmlNode item, string attribute)
        {
            XmlAttribute attr = item.Attributes[attribute];
            if (attr != null && attr.Value != string.Empty)
            {
                return Convert.ToDecimal(attr.Value);
            }
            return 0;
        }

        public static bool GetBoolValue(XmlNode item, string attribute)
        {
            XmlAttribute attr = item.Attributes[attribute];
            if (attr != null && attr.Value != string.Empty)
            {
                return Convert.ToBoolean(attr.Value);
            }
            return false;
        }

        public static int GetIntValue(XmlNode item, string attribute)
        {
            XmlAttribute attr = item.Attributes[attribute];
            if (attr != null && attr.Value != string.Empty)
            {
                return Convert.ToInt32(attr.Value);
            }
            return 0;
        }

        public static string GetStringValue(XmlNode item, string attribute)
        {
            XmlAttribute attr = item.Attributes[attribute];
            if (attr != null && attr.Value != string.Empty)
            {
                return attr.Value;
            }
            return "";
        }

        public static short GetShortValue(XmlNode item, string attribute)
        {
            XmlAttribute attr = item.Attributes[attribute];
            if (attr != null && attr.Value != string.Empty)
            {
                return Convert.ToInt16(attr.Value);
            }
            return 0;
        }

    }
}
