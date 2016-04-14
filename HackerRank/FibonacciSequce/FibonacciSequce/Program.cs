using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            Stopwatch watch = new Stopwatch();

            watch.Start();
            Console.WriteLine(Fibonacci(5));
            watch.Stop();

            Console.WriteLine($"Time Taken: {watch.Elapsed.TotalSeconds}");
        }

        static int Fibonacci(int num)
        {
            if (num <= 0)
                return 0;
            if (num == 1)
                return 1;
           
            int number =  Fibonacci(num - 1) + Fibonacci(num - 2);
            Console.Write($"{number} ");
            return number;
        }
    }
}

