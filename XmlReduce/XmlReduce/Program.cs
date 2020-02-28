using System;
using System.Xml;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;

namespace XmlReduce
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(@"C:\Users\vishnu\Downloads\Sample.xml");
            string xStr = xml.InnerXml.ToString();
            var xDocument = XDocument.Parse(xStr);
            
            var selectedNodes = from nodes in xDocument.Descendants("enetxmldatarow").Descendants("enetxmldata")
                                select nodes;
            Dictionary<string, string> dict = new Dictionary<string, string>
            {
                { "storeid" , "StoreId" }
            };
            foreach(var node in selectedNodes)
            {
                node.Attribute("fieldname").Value = dict[node.Attribute("fieldname").Value];
            }
            Console.Read();
        }
    }
}
