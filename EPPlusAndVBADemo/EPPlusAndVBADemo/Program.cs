using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;

namespace EPPlusAndVBADemo
{
    class Program
    {

        const string FolderName = @"D:\Epplus";

        const string FileName = @"EpplusDemo.xlsx";

        public static string ExcelFile => string.Concat(FolderName, @"\", FileName);
        static void Main(string[] args)
        {

            // creating excel file

            

            if (!Directory.Exists(FolderName))
                Directory.CreateDirectory(FolderName);

            if(File.Exists(ExcelFile))
                File.Delete(ExcelFile);


            using (ExcelPackage package = new ExcelPackage(new FileInfo(ExcelFile)))
            {
                package.Workbook.Worksheets.Add("Sheeet1");
                package.Workbook.CreateVBAProject();

                X509Store store = new X509Store(StoreLocation.CurrentUser);
                store.Open(OpenFlags.ReadOnly);
                package.Workbook.VbaProject.Signature.Certificate = store.Certificates[11];




            }
        }
    }
}
