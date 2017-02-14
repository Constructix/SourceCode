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
            string[] tokens_n = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(tokens_n[0]);
            int k = Convert.ToInt32(tokens_n[1]);
            int q = Convert.ToInt32(tokens_n[2]);
            string[] a_temp = Console.ReadLine().Split(' ');
            int[] a = Array.ConvertAll(a_temp, Int32.Parse);

            for (int a0 = 0; a0 < q; a0++)
            {
                int m = Convert.ToInt32(Console.ReadLine());
            }
        }

        private static void OldCode()
        {
            int rotations = 0;
            int numberOfIndex;
            int queries;

            string[] parmeters = Console.ReadLine().Split(' ');
            int[] numbers = Array.ConvertAll(Console.ReadLine().Split(' '), Convert.ToInt32);
            string[] inputNumber = Console.ReadLine().Split(' ');

            int[] numberParameters = Array.ConvertAll(parmeters, Convert.ToInt32);

            int arraySize = numberParameters[0];
            int k = numberParameters[1];
            int q = numberParameters[2];


            for (rotations = 0; rotations <= 10; rotations++)
            {
                int[] tempArray = new int[numbers.Length];
                for (int index = 0; index < numbers.Length; index++)
                {
                    int newIndex = (index + rotations) % numbers.Length;
                    if (newIndex == numbers.Length)
                        newIndex = 0;
                    tempArray[newIndex] = numbers[index];
                }
            }
        }
    }
}
