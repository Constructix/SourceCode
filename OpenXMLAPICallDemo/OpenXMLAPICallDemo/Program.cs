using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace OpenXMLAPICallDemo
{
    class Program
    {
        static void Main(string[] args)
        {


            string fileName = @"D:\OpenXmlExcelFirst.xlsx";

            SpreadsheetDocument document = SpreadsheetDocument.Create(fileName, SpreadsheetDocumentType.Workbook);

            WorkbookPart workBookPart = document.AddWorkbookPart();
            workBookPart.Workbook = new Workbook();

            WorksheetPart worksheetPart = workBookPart.AddNewPart<WorksheetPart>();
            worksheetPart.Worksheet = new Worksheet(new SheetData());

            Sheets sheets = document.WorkbookPart.Workbook.AppendChild<Sheets>(new Sheets());

            Sheet sheet = new Sheet
            {
                Id = document.WorkbookPart.GetIdOfPart(worksheetPart),
                SheetId = 1,
                Name = "mySheet"
            };

            sheets.AppendChild(sheet);

            worksheetPart.Worksheet.Save();
            document.Close();




        }
    }
}
