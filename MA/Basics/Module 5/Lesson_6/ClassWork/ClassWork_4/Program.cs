using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ClassWork_4
{
    class Program
    {
        static void Main(string[] args)
        {

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml("<test>InnerText is here</test>");
            Console.WriteLine(xmlDoc.DocumentElement.InnerText);
            Console.ReadKey();

            XmlDocument xmlDoc2 = new XmlDocument();
            xmlDoc2.LoadXml("<users><user>InnerText/InnerXml is here</user></users>");
            Console.WriteLine("InnerXml: " + xmlDoc2.DocumentElement.InnerXml);
            Console.WriteLine("OuterXml: " + xmlDoc2.DocumentElement.OuterXml);
            Console.ReadKey();
        }
    }
}
