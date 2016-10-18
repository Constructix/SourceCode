using System;
using System.Text;


namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(System.Globalization.CultureInfo.CurrentCulture.EnglishName);
            var persons   = ConsoleApplication.Helpers.InitialisePersonList();
            persons.ForEach((x) =>Console.WriteLine(x));               


            // write to file

            StringBuilder personStringBuilder = new StringBuilder();
            persons.ForEach((x) =>personStringBuilder.AppendLine(x.ToString()));


            System.IO.File.WriteAllText(@"D:\Files\persons.dat", personStringBuilder.ToString());
            Console.WriteLine("File has been written to disk.");

        }

      
    }
  
}
