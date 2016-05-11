using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Solution
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                Console.SetIn(System.IO.File.OpenText(args[0]));
            }

            int valueToSearchFor = 0;
            int arraySize = 0;
            int.TryParse(Console.ReadLine(), out valueToSearchFor);
            int.TryParse(Console.ReadLine(), out arraySize);

            int[] array = Array.ConvertAll(Console.ReadLine().Split(new char[] {' '}), Convert.ToInt32);

            int index = -1;
            for (index = 0; index < arraySize; index++)
            {
                if (array[index] == valueToSearchFor)
                    break;
            }
            Console.WriteLine(index);
        }
}