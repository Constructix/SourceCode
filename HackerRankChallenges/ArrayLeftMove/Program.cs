using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] numbers = new int[GenerateArraySize()];
            PopulateArray(numbers);
            WriteArrayToFile(@"D:\Files\ArrayRotationData.txt", numbers);

            int[] rotatedNumbers = new int[numbers.Length];
            int currentIndex = 0;
            int rotations = 2;

            

            Stopwatch watch = new Stopwatch();
            watch.Start();


            StringBuilder testBuilder = new StringBuilder();


            for (int index = currentIndex; index < numbers.Length; index++)
            {

                int newIndex = NewPosition(index, rotations, numbers);
                rotatedNumbers[newIndex] = numbers[index];
            }
            watch.Stop();
            
            Console.WriteLine("Sample Output");
            for(int index = 0; index < numbers.Length; index++)

            {
                testBuilder.AppendLine($"{numbers[index]} {rotatedNumbers[index]}");
            }

            System.IO.File.WriteAllText(@"D:\Files\Testing.dat", testBuilder.ToString());
            System.Diagnostics.Process.Start(@"D:\Files\Testing.dat");

            Console.WriteLine($"Number in Array: {numbers.Length}");
            Console.WriteLine($"Total Time: { watch.Elapsed.ToString()}");
        }

        private static void WriteArrayToFile(string FileName, int[] numbers)
        {
            StringBuilder builder = new StringBuilder();

            for(int i=0; i < numbers.Length; i++)
            {
                builder.Append($"{numbers[i]} ");
            }

            builder = builder.Remove(builder.Length - 1, 1);

            System.IO.File.WriteAllText(FileName, builder.ToString());
        }

        private static void PopulateArray(int[] numbers)
        {
            Random r = new Random();

            for (int index = 0; index < numbers.Length; index++)
            {
                numbers[index] = r.Next(100000);
            }
        }

        private static int NewPosition(int currentIndex, int rotations, int[] numbers)
        {
            return (currentIndex + rotations) % numbers.Length;
        }

        static int GenerateArraySize()
        {
            Random r = new Random();
            return r.Next(100000);
        }
    }
}
