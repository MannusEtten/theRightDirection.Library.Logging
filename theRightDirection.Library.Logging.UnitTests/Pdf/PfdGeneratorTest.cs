using System.Collections.Generic;
using theRightDirection.Library.Pdf;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace theRightDirection.Library.UnitTests.Pdf
{
    [TestClass]
    public class PfdGeneratorTest
    {
        [TestMethod]
        public void GeneratePdf()
        {
            Assert.Inconclusive();
            PdfGenerator generator = new PdfGenerator(@"D:\pdfformulier.pdf", @"D:\exportformulier.pdf");
            List<PdfFormField> fields = new List<PdfFormField>();
            fields.Add(new PdfFormField() { FieldType = PdfFormFieldType.Text, Key = "naam", Value = "Mannus Etten" });
            fields.Add(new PdfFormField() { FieldType = PdfFormFieldType.Text, Key = "adres", Value = "Saffierstraat 214, 9743LN" });
            fields.Add(new PdfFormField() { FieldType = PdfFormFieldType.Text, Key = "plaats", Value = "Groningen" });
            fields.Add(new PdfFormField() { FieldType = PdfFormFieldType.Text, Key = "land", Value = "Nederland" });
            generator.GeneratePdf(fields);
        }
    }
}