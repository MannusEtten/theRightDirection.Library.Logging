using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using theRightDirection.Library.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using theRightDirection.Library.Extensions;
using System.Reflection;
namespace theRightDirection.Library.UnitTests.Xml
{
    [TestClass]
    public class CsvToXmlConverterTest
    {
        private const string csvDataFileName = "testdata.csv";

        [TestMethod]
        public void ConvertCsvToXml_Record_Count_Is_30()
        {
            XElement convertedDocument = ReadXmlDocument();
            Assert.AreEqual(30, convertedDocument.Elements().Count());
        }

        [TestMethod]
        public void ConvertCsvToXml_Column_Count_Is_5()
        {
            XElement convertedDocument = ReadXmlDocument();
            XElement oneElement = convertedDocument.Elements().First();
            Assert.AreEqual(5, oneElement.Elements().Count());
        }

        [TestMethod]
        public void CreateXmlElement_With_Name_Mannus_And_Value_Etten()
        {
            CsvToXmlConverter converter = new CsvToXmlConverter(csvDataFileName);
            XElement xmlElement = converter.CreateXmlElement("etten", "mannus");
            Assert.AreEqual("mannus", xmlElement.Name);
            Assert.AreEqual("etten", xmlElement.Value);
        }

        [TestMethod]
        public void CreateXmlElement_With_Two_Sub_Elements_First_ElementName_Is_kolom1_Second_ElementValue_Is_def()
        {
            string data = "abc;def";
            List<string> headers = new List<string>();
            headers.Add("kolom1");
            headers.Add("kolom2");
            CsvToXmlConverter converter = new CsvToXmlConverter(csvDataFileName);
            XElement xmlElement = converter.CreateXmlElement(data, headers);
            Assert.AreEqual("kolom1", xmlElement.Elements().First().Name);
            Assert.AreEqual("def", xmlElement.Elements().Last().Value);
        }

        private string GetDataFile()
        {
            return AssemblyExtension.FindFileNextToAssembly(Assembly.GetExecutingAssembly(), csvDataFileName);
        }

        private XElement ReadXmlDocument()
        {
            var dataFileLocation = GetDataFile();
            CsvToXmlConverter converter = new CsvToXmlConverter(dataFileLocation);
            converter.ColumnSplitCharacter = ",";
            return converter.ConvertCsvToXml();
        }
    }
}