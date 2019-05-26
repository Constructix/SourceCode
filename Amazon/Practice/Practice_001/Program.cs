using System;
using System.Collections.Generic;

namespace Practice_001
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> leaders = new List<int>();
            int[] array = new int[] {16, 17, 4, 3, 5, 2};
            bool isOk = true;
            for (int x = 0; x < array.Length; x++)
            {
                for (int y = x + 1; y < array.Length - 1; y++)
                {
                    if (array[x] < array[y])
                    {
                        isOk = false;
                    }
                }
                if(isOk)
                    leaders.Add(array[x]);

                isOk = true;
            }
            leaders.ForEach(x=> Console.Write($"{x} "));

        }
    }
}
