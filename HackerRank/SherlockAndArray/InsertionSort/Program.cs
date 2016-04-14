using System;
using System.IO;

namespace Solution
{
    

    class Program
    {
        static void Main(string[] args)
        {
            bool useFile = args.Length > 0;
            if (useFile)
            {
                var reader = new StreamReader(args[0]);
                Console.SetIn(reader);
            }
            int numberOfElements = GetElements();
            int[] numberArray = LoadArray();
            if (numberArray.Length == numberOfElements)
            {
                var insertionSort = new InsertionSort();
                numberArray = insertionSort.Sort(numberArray);
                Console.Write($"{insertionSort.Counter}");
            }
        }

        private static int GetElements()
        {
            int totalElements;
            int.TryParse(Console.ReadLine(), out totalElements);
            return totalElements;
        }


        private static int[] LoadArray()
        {
            var readLine = Console.ReadLine();
            if (readLine != null)
            {
                string[] input = readLine.Split(new char[] {' '});
                return Array.ConvertAll(input, Convert.ToInt32);
            }
            else
            {
                return new int[0];
            }
        }

        private static void PrintArray(int[] numberArray)
        {
            for (int i = 0; i < numberArray.Length; i++)
            {
                Console.Write($"{numberArray[i]} ");
            }
        }
    }
    public class InsertionSort
    {

        public InsertionSort()
        {
            Counter = 0;
        }
        public int Counter { get; set; }
        public int[] Sort(int[] arrayToBeSorted)
        {
            for (int j = 1; j < arrayToBeSorted.Length; j++)
            {
                int key = arrayToBeSorted[j];
                var i = j - 1;
                while (i >= 0 && arrayToBeSorted[i] > key)
                {
                    arrayToBeSorted[i + 1] = arrayToBeSorted[i];
                    i--;
               
                    Counter++;
                }
                arrayToBeSorted[i + 1] = key;
               
            }
            return arrayToBeSorted;
        }

    }
}
