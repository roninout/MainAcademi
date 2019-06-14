using System;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClassWork_5
{
    class Program
    {
        static void Main(string[] args)
        {

            XElement root = XElement.Load(uri: @"D:\C#\MainAcademy\MA\Basics\Module 5\Lesson_6\ClassWork\ClassWork_5\LINQOperationXML.xml");

            var contract = from el in root.Elements("contact")
                           where el.Element("lastname").Value == "Petrov"
                           select el;

            foreach (var item in contract)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }
}
