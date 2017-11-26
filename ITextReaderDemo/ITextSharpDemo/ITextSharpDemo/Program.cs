using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  iTextSharp.text;
using iTextSharp.text.pdf;


namespace ITextSharpDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            var doc1 = new Document();
            PdfWriter.GetInstance(doc1, new FileStream(@"D:\temp\test.pdf", FileMode.Create));
            doc1.Open();
            doc1.Add(new Paragraph("First PDF Demo"));
            doc1.Close();


        }
    }
}
