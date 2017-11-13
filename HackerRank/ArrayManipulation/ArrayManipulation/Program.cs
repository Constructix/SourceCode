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

            StringBuilder builder = new StringBuilder();

            Random r = new Random((int) DateTime.Now.Ticks);
            
            int arraySize = CreateArraySize();
            int numberOfLines = CreateLines();
            builder.AppendLine($"{arraySize} {numberOfLines}");
            Console.WriteLine(builder.ToString());
        }

        private static int CreateLines()
        {
            Random r = new Random((int)DateTime.Now.Ticks);
            return r.Next(3, MaxLines);
        }

        private static int CreateArraySize()
        {
            Random r = new Random((int)DateTime.Now.Ticks);
            return r.Next(1, MaxArraySize);
        }

        private static void FindLargetValueInArray(string[] args)
        {
            if (args.Length == 1)
            {
                TextReader reader = File.OpenText(args[0]);
                Console.SetIn(reader);
            }
            int arraySize = 0;
            int numberOfLines = 0;
            int largestValue = -1;
            string[] parameters = Console.ReadLine().Split(' ');
            bool validData = false;


            if (validData = (int.TryParse(parameters[0], out arraySize) && int.TryParse(parameters[1], out numberOfLines)))
            {
                if (numberOfLines >= 3)
                {
                    int[] array = new int[arraySize];
                    for (int currentLineIndex = 0; currentLineIndex < numberOfLines; currentLineIndex++)
                    {
                        int a = 0;
                        int b = 0;
                        int k = 0;

                        string[] arrayParameters = Console.ReadLine().Split(' ');
                        if (validData = (int.TryParse(arrayParameters[0], out a) &&
                                         int.TryParse(arrayParameters[1], out b) &&
                                         int.TryParse(arrayParameters[2], out k)))
                        {
                            for (int index = a - 1; index <= (b - 1); index++)
                            {
                                array[index] += k;
                                if (array[index] >= largestValue)
                                    largestValue = array[index];
                            }
                        }
                    }
                    if (validData)
                        Console.WriteLine(largestValue);
                    else
                    {
                        throw new Exception("Invalid Data encountered in input supplied.");
                    }
                }
            }
        }

       
    }
}
