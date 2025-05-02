using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
using Castle.Core.Internal;
using Lib.Model.ParseJson;
using Newtonsoft.Json;
using System.Security.Cryptography;

namespace Lib
{
    public class XmlHelper
    {
        public string XMLString(string xmlString)
        {
            XmlNodeList xnlstData;
            XmlNode xnBody, xnOccur;

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xmlString);
            int num = 0;

            xnlstData = xmlDocument.GetElementsByTagName("OCCUR");
            xnOccur = xnlstData[0];
            num += Convert.ToInt16(xnOccur?.InnerText?.Trim() ?? "0");
            xnlstData = xmlDocument.GetElementsByTagName("TxBody");
            XmlNode xmlNode2 = xnlstData[xnlstData.Count - 1];


            XmlDocument xmlDocument2 = new XmlDocument();
            xmlDocument2.LoadXml(xmlString);

            xnlstData = xmlDocument2.GetElementsByTagName("OCCUR");
            num += Convert.ToInt16(xnlstData[0]?.InnerText?.Trim() ?? "0");
            xnlstData = xmlDocument2.GetElementsByTagName("TxRepeat");
            for (int j = 0; j < xnlstData.Count; j++)
            {
                XmlElement xmlElement = xmlDocument.CreateElement(xnlstData[j].Name);
                xmlElement.InnerXml = xnlstData[j].InnerXml;
                xmlNode2.AppendChild(xmlElement);
            }
            if (xnOccur != null)
            {
                xnOccur.InnerText = num.ToString("000");
            }
            var b = xmlDocument.ToString();
            var c = xmlDocument.InnerXml;
            return c;
        }
    }
}
