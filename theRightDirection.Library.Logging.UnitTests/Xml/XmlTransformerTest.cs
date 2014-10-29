using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using theRightDirection.Library.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using theRightDirection.Library.Extensions;
using System.Reflection;
namespace theRightDirection.Library.UnitTests.Xml
{
    [TestClass]
    public class XmlTransformerTest
    {
        private const string XMLFILENAME = "675a1ed5-6333-44e8-ac23-d08b1c5be477.xml";
        private const string XSLTFILENAME = "dataconversie.xslt";

        [TestMethod]
        public void TransformXml()
        {
            var xml = GetXmlFileName();
            var xslt = GetXsltFileName();
            XsltTransformer transformer = new XsltTransformer();
            transformer.PathToXmlFile = xml;
            transformer.PathToXsltFile = xslt;
            transformer.TransformXml();
        }

        private string GetXsltFileName()
        {
            return AssemblyExtension.FindFileNextToAssembly(Assembly.GetExecutingAssembly(), XSLTFILENAME);
        }

        private string GetXmlFileName()
        {
            return AssemblyExtension.FindFileNextToAssembly(Assembly.GetExecutingAssembly(), XMLFILENAME);
        }

    }
}
