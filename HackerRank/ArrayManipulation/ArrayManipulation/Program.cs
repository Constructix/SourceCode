using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        private const int MaxArraySize = 2 * 100000;
        private const int MaxLines = 10000000;
        static void Main(string[] args)
        {
            FindLargetValueInArray(args);
        }
        private static void FindLargetValueInArray(string[] args)
        {
            if (args.Length == 1)
            {
                TextReader reader = File.OpenText(args[0]);
                Console.SetIn(reader);
            }
            long arraySize = 0;
            long numberOfLines = 0;
            long max = 0;
            string[] parameters = Console.ReadLine().Split(' ');
            long.TryParse(parameters[0], out arraySize);
            long.TryParse(parameters[1], out numberOfLines);

            bool validData = false;
            long [] array = new long[arraySize + 1];
            for (int currentLineIndex = 0; currentLineIndex < numberOfLines; currentLineIndex++)
            {
                long a = 0;
                long b = 0;
                long k = 0;

                string[] arrayParameters = Console.ReadLine().Split(' ');
                long.TryParse(arrayParameters[0], out a);
                long.TryParse(arrayParameters[1], out b);
                long.TryParse(arrayParameters[2], out k);
                array[a] += k;
                if ((b + 1) <= arraySize)
                    array[b + 1] -= k;
                    
            }
            long sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum +=  array[i];
                if (max < sum)
                    max = sum;
            }
            Console.WriteLine(max);
        }

        private static void PrintArray(int[] array)
        {

            int maxValueInArray = array.Max();
            Console.WriteLine(maxValueInArray);
        }
    }
}
