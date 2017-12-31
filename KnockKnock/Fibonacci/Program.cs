using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int expectedResult = 610;

            if(expectedResult == Fibonacci(15))
                Console.WriteLine("Success");
            else
            {
                Console.WriteLine("Failure");
            }
        }

        static int Fibonacci(int num1)
        {
            int sum = 0;
            if (num1 <= 2 )
                return 1;
             sum +=  Fibonacci(num1 - 1) + Fibonacci(num1 - 2);
            return sum;

        }
    }
}
