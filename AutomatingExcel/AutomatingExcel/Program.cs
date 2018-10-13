using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;

namespace CreateExcel
{
    class Program
    {
        static void Main(string[] args)
        {

            using (ExcelPackage xlPackage = new ExcelPackage(new FileInfo(@"D:\Temp\test.xlsm")))
            {
                xlPackage.Workbook.Worksheets.Add("Test");
                var ws = xlPackage.Workbook.Worksheets.Add("NewWorksheet");
                ws.CodeModule.Code = "Private Sub Worksheet_SelectionChange(ByVal Target As Range)\r\n\r\nEnd Sub";
                xlPackage.SaveAs(new FileInfo(@"D:\temp\vbafailSaved.xlsm"));
                
            }



            //var package = new ExcelPackage();
            //package.Workbook.Worksheets.Add("Sheet1");
            //package.Workbook.CreateVBAProject();
            //package.Workbook.VbaProject.Modules["Sheet1"].Code += "\r\nPrivate Sub Worksheet_SelectionChange(ByVal Target As Range)\r\nMsgBox(\"Test of the VBA Feature!\")\r\nEnd Sub\r\n";
            //package.Workbook.VbaProject.Modules["Sheet1"].Name = "Blad1";
            //package.Workbook.CodeModule.Name = "DenHärArbetsboken";
            //package.Workbook.Worksheets[1].Name = "FirstSheet";
            //package.Workbook.CodeModule.Code += "\r\nPrivate Sub Workbook_Open()\r\nBlad1.Cells(1,1).Value = \"VBA test\"\r\nMsgBox \"VBA is running!\"\r\nEnd Sub";
            ////X509Store store = new X509Store(StoreLocation.CurrentUser);
            ////store.Open(OpenFlags.ReadOnly);
            ////package.Workbook.VbaProject.Signature.Certificate = store.Certificates[11];

            //var m = package.Workbook.VbaProject.Modules.AddModule("Module1");
            //m.Code += "Public Sub Test(param1 as string)\r\n\r\nEnd sub\r\nPublic Function functest() As String\r\n\r\nEnd Function\r\n";
            //var c = package.Workbook.VbaProject.Modules.AddClass("Class1", false);
            //c.Code += "Private Sub Class_Initialize()\r\n\r\nEnd Sub\r\nPrivate Sub Class_Terminate()\r\n\r\nEnd Sub";
            //var c2 = package.Workbook.VbaProject.Modules.AddClass("Class2", true);
            //c2.Code += "Private Sub Class_Initialize()\r\n\r\nEnd Sub\r\nPrivate Sub Class_Terminate()\r\n\r\nEnd Sub";

            //package.Workbook.VbaProject.Protection.SetPassword("EPPlus");
            //package.SaveAs(new FileInfo(@"D:\temp\vbaWrite.xlsx"));

        }
    }
}
