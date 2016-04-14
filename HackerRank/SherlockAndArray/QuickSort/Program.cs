using System;

public class Program
{
    public static void Main()
    {
        int[] numberArray = new int[] {13, 19, 9, 5, 12, 8, 7, 4, 21, 2, 6, 11};
        
        QuickSort(numberArray,0, numberArray.Length-1);
        for(int i=0; i< numberArray.Length; i++)
            Console.WriteLine(numberArray[i]);

    }

    static void QuickSort(int[] numberArray, int p, int r)
    {
        if (p < r)
        {
            int index = Partition(numberArray, p, r);
            QuickSort(numberArray, p, index - 1);
            QuickSort(numberArray, index + 1, r);
        }
    }


    static int Partition(int[] array, int p, int r)
    {
        int x = array[r];
        int i = p - 1;
        for (int j = p; j <= r - 1; j++)
        {
            if (array[j] <= x)
            {
                i = i + 1;
                Exchange(array, i, j);
            }
            else
                Exchange(array, i + 1, r);
        }
        return i + 1;
    }

    private static void Exchange(int [] array, int index1, int index2)
    {
        if (array[index2] <= array[index1])
        {
            int temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }

    }


    //static void Merge(int[] array, int start, int last)
    //{
    //    if (start < last)
    //    {
    //        int mid = (last - start) / 2;
    //        Merge(array, start, mid);
    //        Merge(array, mid+1, last);
    //        MergeSort(array, start, mid, last);
    //    }
    //}

    //static void MergeSort(int[] array, int start, int mid, int last)
    //{


    //    int leftSize = (mid - start) + 1;
    //    int rightSize = (last - mid) + 1;

    //    Console.WriteLine("\tLeftSize = {0} RightSize = {1} Last = {2}", leftSize, rightSize, last);

    //    int[] left = new int[leftSize];
    //    int[] right = new int[rightSize];
    //    //

    //    for (int i = 0; i < leftSize; i++)
    //    {
    //        left[i] = array[i];

    //        Console.WriteLine("\t\tLeft[{0}] = {1}", i, left[i]);
    //    }

    //    Console.WriteLine("Before J");
    //    for (int j = 0; j < (last - mid); j++)
    //    {
    //        right[j] = array[j + mid];
    //        Console.WriteLine("\t\tRight[{0}] = {1}", j, right[j]);
    //    }

    //    int x = 0;
    //    int y = 0;

    //    for (int k = 0; k < last; k++)
    //    {
    //        if(left[x] <= right[y])
    //        {
    //            array[k] = left[x];
    //            x++;
    //        }
    //    else
    //        {
    //            array[k] = right[y];
    //            y++;
    //        }
    //    }
    //}
    static void ChangeArray(int[] array)
    {

        array[0] = 10;
    }
}