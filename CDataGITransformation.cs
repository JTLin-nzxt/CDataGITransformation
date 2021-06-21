using System;
using System.IO;
using System.Xml;

namespace CDataGITransformation
{
    class CDataGITransformation
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the xml folder path :");

            //string folderPath = Console.ReadLine();
            string folderPath = Directory.GetCurrentDirectory();

            string[] xmlFiles = Directory.GetFiles(folderPath, "*.xml", SearchOption.AllDirectories);
            foreach (string xmlFile in xmlFiles)
            {
                Console.WriteLine(xmlFile);
                CDataGITransforming(xmlFile);
            }
        }
        public static void CDataGITransforming(string filePath)
        {
            var xmldoc = new XmlDocument();
            xmldoc.Load(filePath);

            // trans every GIResult.Caption to upper case
            XmlNodeList giresultNodes = xmldoc.GetElementsByTagName("GIResult");
            foreach (XmlNode giresultNode in giresultNodes)
            {
                try
                {
                    string upperCaption = giresultNode.Attributes["Caption"].Value.ToUpper();
                    giresultNode.Attributes["Caption"].Value = upperCaption;
                }
                catch (Exception e)
                {
                    //do nothing
                }
            }

            xmldoc.Save(filePath);
        }
    }
}
