using System;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new[] {13, 19, 9, 5, 12, 8, 7, 4, 21, 2, 6, 11};
            
            QuickSort(array, 0, array.Length-1);


        }

        static void QuickSort(int[] array, int p, int r)
        {
            if (p < r)
            {
                int q = Partition(array, p, r);
                QuickSort(array, p, q - 1);
                QuickSort(array, q + 1, r);
            }
        }

        private static int Partition(int[] array, int p, int r)
        {
            int x = array[r];
            int i = p - 1;

            for (int j = p; j <= r - 1; j++)
            {
                if (array[j] <= x)
                {
                    i++;
                    Swap(array, j, i);
                }
            }
            Swap(array, i + 1, r);
            return i + 1;
        }

        private static void Swap(int[] array, int x, int y)
        {
            int temp = array[y];
            array[y] = array[x];
            array[x] = temp;
        }
    }
}
