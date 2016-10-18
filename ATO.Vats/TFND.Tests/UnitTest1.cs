using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;

namespace TFND.Tests
{

    [TestClass]
    public class ExcelTest
    {
        [TestMethod]
        public void CreateExcelFile()
        {
            ExcelPackage p = new ExcelPackage(new FileInfo(@"C:\Users\rjjon\OneDrive\ATO\TFND\2010\TFND.0001 2010 AP361 Mapping Rules ICP.xlsx"));


            ExcelWorksheet mappingRulesWorkSheet = p.Workbook.Worksheets["Mapping Rules"];
            if (mappingRulesWorkSheet != null)
            {


                ExcelAddressBase dimensions = mappingRulesWorkSheet.Dimension;
                Console.WriteLine($"Total rows: {dimensions.Rows}");
                Console.WriteLine($"Total Cols: {dimensions.Columns}");


                var elementIDColumn = mappingRulesWorkSheet.Column(6);

                ExcelRangeBase range = mappingRulesWorkSheet.SelectedRange["F1:F15"];

                foreach (ExcelRangeBase rangeBase in range)
                {

                    
                        Console.WriteLine(rangeBase.Value);
                }

            }
            else
            {
                Console.WriteLine("Mapping Rules spreadsheet does not exist");
            }



        }
    }
    [TestClass]
    public class UnitTest1
    {
        private const string fileName = @"C:\Users\rjjon\OneDrive\ATO\Responses\2016 Response01.xml";

        private  XDocument _doc;

       

        [TestInitialize]
        public void TestInitialise()
        {
            _doc = XDocument.Load(fileName);
        }

        [TestMethod]
        public void TestMethod1()
        {
           
            Assert.IsNotNull(_doc);
        }


        [TestMethod]
        public void RequestService_IsValid()
        {
            string expectedRequestedService = "ProcessFormONBD";
            var requestedServiceElement = _doc.Descendants().FirstOrDefault(x => x.Name.LocalName.Equals("RequestedService")).Value;
            Assert.IsTrue(expectedRequestedService.Equals(requestedServiceElement));
        }

        [TestMethod]
        public void FormLineItem_TelephoneNumber_IsValid()
        {

            string expectedPhoneNumber = "92557125";
            string logicalNameAttributeName = "FDFFieldLogicalName";
            string FieldUsageAttributeName = "FDFFieldUsage";


            var formLineItemElements = _doc.Descendants().Where(x => x.Name.LocalName.Equals("FormLineItem"));
            Assert.IsTrue(formLineItemElements.Any());
        }


    }
}
