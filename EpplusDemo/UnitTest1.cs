using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;

namespace EpplusDemo
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void MapElement_NotNull()
        {
            MapElement<string> element = new MapElement<string>() { ExpectedValue = "Sydney",
                                                                    FormName = "OTH-PYR_DTLS",
                                                                    CanonicalName = "StructuredGeographicAddressLocalityName",
                                                                    DataElementName = "pyde.02.00:AddressDetails.LocalityName.Text",
                                                                    RuleId = "ATOTFND911419"};

            string requestFile = @"C:\Users\rjjon\OneDrive\ATO\TFND\Responses\2016 Request.xml";
            string responseFile = @"C:\Users\rjjon\OneDrive\ATO\TFND\Responses\2016 Response.xml";
            XDocument requestDocument =  XDocument.Load(requestFile);
            Assert.IsNotNull(requestDocument);

 




        }
        [TestMethod]
        public void TestMethod1()
        {

            const string FileName = @"D:\Temp\TFND.0003 2016 AP361 Mapping Rules ICP.xlsx";
            XDocument doc = new XDocument(new XElement("TFNDMappings"));

            
            var root = doc.Descendants().FirstOrDefault();

             
            var createdAttribute = new XAttribute("created", XmlConvert.ToDateTime(DateTime.Now.ToString("o"), XmlDateTimeSerializationMode.Local));
            var sourceSpreadSheet = new XAttribute("source",  FileName);
            root.Add(createdAttribute);
            root.Add(sourceSpreadSheet);

            using (ExcelPackage package = new ExcelPackage(new FileInfo(FileName)))
            {

               
                var workSheet = package.Workbook.Worksheets["Mapping Rules"];

                Assert.IsNotNull(workSheet);

                int rows = workSheet.Dimension.Rows;

                for (int x = 1; x < rows; x++)
                {
                    string rangeAddress = string.Format("M{0}", x);
                    string canonicalName = workSheet.Cells[rangeAddress].GetValue<string>();

                    rangeAddress = string.Format("C{0}", x);
                    string taxonomyDataElementName = workSheet.Cells[rangeAddress].GetValue<string>();

                    rangeAddress = string.Format("F{0}", x);
                    string elementId = workSheet.Cells[rangeAddress].GetValue<string>();

                    rangeAddress = string.Format("S{0}", x);
                    string mappingRuleDetail = workSheet.Cells[rangeAddress].GetValue<string>();

                    rangeAddress = string.Format("R{0}", x);
                    string mappingRuleId = workSheet.Cells[rangeAddress].GetValue<string>();

                    rangeAddress = string.Format("O{0}", x);
                    string dataType = workSheet.Cells[rangeAddress].GetValue<string>();
                    
                    string dataElementName = workSheet.Cells[x, 8].GetValue<string>();
                    string formSectionName = workSheet.Cells[x, 9].GetValue<string>();
                    if(!string.IsNullOrEmpty(mappingRuleDetail) && !mappingRuleDetail.Equals("Do not set"))
                        Console.WriteLine($"[{formSectionName}] [{canonicalName}] [{taxonomyDataElementName}] [{elementId}] [{mappingRuleId}] [{dataType}]");

                    if (x != 1)
                    {

                        if (!string.IsNullOrWhiteSpace(formSectionName) &&
                            !string.IsNullOrWhiteSpace(canonicalName) &&
                            !string.IsNullOrWhiteSpace(taxonomyDataElementName) &&
                            !string.IsNullOrWhiteSpace(elementId) &&
                            !string.IsNullOrWhiteSpace(mappingRuleId))
                        {
                            var mappingElement = new XElement("Mapping",
                                new XElement("FormSection", formSectionName),
                                new XElement("CanonicalName", canonicalName),
                                new XElement("TaxnonmyDataElementName", taxonomyDataElementName),
                                new XElement("ElementId", elementId),
                                new XElement("RuleId", mappingRuleId),
                                new XElement("ExpectedValue", "TODO-Not Yet Implemented")
                            );

                            root.Add(mappingElement);
                        }

                    }
                }

                StringBuilder builder = new StringBuilder();
                builder.Append(root.ToString());
               File.WriteAllText(@"D:\Temp\Generation.xml", builder.ToString());
            }
        }
    }

    public class MapElement<T>
    {
        public T ExpectedValue { get; set; }
        public string FormName { get; set; }
        public string CanonicalName { get; set; }
        public string DataElementName { get; set; }
        public string RuleId { get; set; }
}
