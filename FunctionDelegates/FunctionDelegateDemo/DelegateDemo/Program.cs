using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateDemo
{
    delegate string ConvertMethod(string inString);
    class Program
    {
        static void Main(string[] args)
        {

            ConvertMethod convertMethod = UpperCaseString;

            string name = "Dakota";

            Console.WriteLine(convertMethod(name));
        }

        private static string UpperCaseString(string instring)
        {
            return instring.ToUpper();
        }
    }
}
