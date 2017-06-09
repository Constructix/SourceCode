using System;

class Solution
{
    static void Main(string[] args)
    {

        if (args.Length > 0)
        {
            var reader = System.IO.File.OpenText(args[0]);
            Console.SetIn(reader);
        }

        string[] tokens_n = Console.ReadLine().Split(' ');
        int arraySize = Convert.ToInt32(tokens_n[0]);
        int rotations = Convert.ToInt32(tokens_n[1]);
        int queries = Convert.ToInt32(tokens_n[2]);
        string[] a_temp = Console.ReadLine().Split(' ');
        int[] a = Array.ConvertAll(a_temp, Int32.Parse);

        int[] queryIndex = new int[queries];
        GetQueries(queries, queryIndex);
        int[] rotatedNumbers = new int[arraySize];
        int currentIndex = 0;

        RotateArray(currentIndex, a, rotations, rotatedNumbers);
        WriteRotatedArrayToConsole(queryIndex, rotatedNumbers);
    }
    
    private static void WriteRotatedArrayToConsole(int [] queryIndex, int[] rotatedNumbers)
    {
        foreach (int index in queryIndex)
        {
            Console.WriteLine(rotatedNumbers[index]);
        }
    }

    private static void RotateArray(int currentIndex, int[] a, int rotations, int[] rotatedNumbers)
    {
        for (int index = currentIndex; index < a.Length; index++)
        {
            int newIndex = NewPosition(index, rotations, a);
            rotatedNumbers[newIndex] = a[index];
        }
    }

    private static void GetQueries(int queries, int[] queryIndex)
    {
        for (int a0 = 0; a0 < queries; a0++)
        {
            int m = Convert.ToInt32(Console.ReadLine());
            queryIndex[a0] = m;
        }
    }

    private static int NewPosition(int currentIndex, int rotations, int[] numbers)
    {
        return (currentIndex + rotations) % numbers.Length;
    }
}

