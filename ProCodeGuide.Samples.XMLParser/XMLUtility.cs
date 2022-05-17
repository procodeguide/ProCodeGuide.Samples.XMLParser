using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace ProCodeGuide.Samples.XMLParser
{
    internal class XMLUtility
    {
        internal static void ReadXMLFileUsingXMLDocument()
        {
            XmlDocument xmlDcoument = new XmlDocument();

            xmlDcoument.Load(@"EmployeeData.xml");

            XmlNodeList? xmlNodeList = xmlDcoument.DocumentElement.SelectNodes("/Employees/Employee");

            Console.WriteLine("Output using XMLDocument");
            foreach (XmlNode xmlNode in xmlNodeList)
            {
                Console.WriteLine("Id of the Employee is : " + xmlNode.SelectSingleNode("Id").InnerText);
                Console.WriteLine("Name of the Employee is : " + xmlNode.SelectSingleNode("Name").InnerText);
                Console.WriteLine();
            }
        }
    

        internal static void ReadXMLFileUsingXMLReader()
        {
            using (XmlReader xmlReader = XmlReader.Create(@"EmployeeData.xml"))
            {
                Console.WriteLine("Output using XMLReader");
                while (xmlReader.Read())
                {
                    if (xmlReader.IsStartElement())
                    {
                        switch (xmlReader.Name.ToString())
                        {
                            case "Id":
                                Console.WriteLine("Id of the Employee is : " + xmlReader.ReadString());
                                break;
                            case "Name":
                                Console.WriteLine("Name of the Employee is : " + xmlReader.ReadString());
                                Console.WriteLine("");
                                break;
                        }
                    }
                }
            }
        }

        internal static void ReadXMLFileUsingLINQ()
        {
            Console.WriteLine("Output using LINQ");
            foreach (XElement xElement in XElement.Load(@"EmployeeData.xml").Elements("Employee"))
            {
                Console.WriteLine("Id of the Employee is : " + xElement.Element("Id").Value);
                Console.WriteLine("Name of the Employee is : " + xElement.Element("Name").Value);
                Console.WriteLine();
            }
        }
    }
}
