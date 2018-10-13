using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Vbe.Interop;
using Excel  = Microsoft.Office.Interop.Excel;
using VBIDE = Microsoft.Office.Interop;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            const string fileName = @"D:\Temp\EPPlus\first.xlsx";

            var app = new Excel.Application();
            app.Workbooks.Add();
            var newWorkBook = app.Workbooks[1].Worksheets.Add();
            
            VBComponent module =   newWorkBook.VBProject.VBComponents.Add(vbext_ComponentType.vbext_ct_StdModule);

            module.Name = "TestModule";

            module.CodeModule.AddFromFile("Sub HelloMessage_Version2()\r\n End Sub\r\n");

            app.Save(fileName);



        }
    }
}
