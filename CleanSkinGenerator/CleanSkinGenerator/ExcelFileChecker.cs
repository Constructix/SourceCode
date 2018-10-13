using OfficeOpenXml;

namespace CleanSkinGenerator
{
    public class ExcelFileChecker
    {
        public static bool WorkSheetExists(ExcelPackage excelPackage, string workSheetName)
        {
            return excelPackage.Workbook.Worksheets[workSheetName] != null;
        }
    }
}