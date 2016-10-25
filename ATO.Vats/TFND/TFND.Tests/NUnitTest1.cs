using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

using NUnit.Framework;
using OfficeOpenXml;
using OfficeOpenXml.FormulaParsing;

namespace NUnitTestProject1
{
    [TestFixture]
    public class NUnitTest1
    {
        const string fileName = @"C:\Users\rjjon\OneDrive\ATO\TFND\Responses\2010 Response.xml";
        private XDocument doc;

        [NUnit.Framework.SetUp]
        public void Initialise()
        {
            doc = XDocument.Load(fileName);
        }

        [Test]
        public void ClientIdentifierAustralianBusinessNumberIsValid()
        {
            List<XElement> formLineItems = doc.Descendants().Where(x => x.Name.LocalName.Equals("FormLineItem")).ToList();
            Assert.IsTrue(formLineItems.Any());

            var element =
                formLineItems.FirstOrDefault(
                    x =>
                        x.Attribute("FDFFieldLogicalName").Value.Equals("ClientIdentifierAustralianBusinessNumber") &&
                        x.Attribute("FDFFieldUsage").Value.Equals("Payer"));


            Assert.IsNotNull(element);
            Assert.IsTrue(element.Value.Equals("12089922823"));
        }

        [Test]
        public void OpenExcelFile()
        {
            ExcelPackage excelPackage = new ExcelPackage(new FileInfo(@"C:\Users\rjjon\OneDrive\ATO\TFND\2010\TFND.0001 2010 AP361 Mapping Rules ICP.xlsx"));
            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets["Mapping Rules"];

            var range = worksheet.Dimension;


            Console.WriteLine(range.Address);

            // get mapping manual rules

            string buildRange = $"R" + (range.Start.Row + 1) + ":S" + (range.End.Row);

            ExcelRange mappingRulesRange = worksheet.Cells[buildRange];
            Console.WriteLine(buildRange);
            Assert.IsNotNull(mappingRulesRange);
            int counter = 0;

            foreach (ExcelRangeBase  excelRangeBase in mappingRulesRange)
            {
                if (counter % 2 == 0)
                {
                    Console.WriteLine(excelRangeBase.GetValue<string>());
                }
                counter++;
            }



            



        }
    }
}