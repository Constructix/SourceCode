using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionDelegateDemo
{


    
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, string> convertMethod = UpperCaseString;
            string name = "Dakota";

            Console.WriteLine(convertMethod(name));
        }

        private static string UpperCaseString(string instring)
        {
            return instring.ToUpper();
        }
    }
}
