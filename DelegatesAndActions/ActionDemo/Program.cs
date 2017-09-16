using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("In ActionDemo console application");
            Console.WriteLine(new string('-', 80));

            Action<string> messageTarget;
            messageTarget = WriteMessage;
            messageTarget("Hello World");



        }

        static void WriteMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
