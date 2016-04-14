using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Emit;
using System.Text;

class Solution
{
    static void Main(String[] args)
    {
        bool useFile = args.Length > 0;
        if (useFile)
        {
            var reader = new StreamReader(args[0]);
            Console.SetIn(reader);
        }
        if (GetElements() > 0)
        {
            PrintArray(CountArrayElements(LoadArray()));
        }
    }

    private static void PrintArray(int[] resultArray)
    {
        StringBuilder builder = new StringBuilder();

        for (int index = 0; index < resultArray.Length; index++)
        {
            builder.Append($"{resultArray[index]} ");
        }
        builder = builder.Remove(builder.Length - 1, 1);
        Console.Write(builder.ToString());
    }

    private static int[] CountArrayElements(int[] array)
    {
        const int MaxIntCounterArraySize = 100;
        int[] resultArray = new int[MaxIntCounterArraySize];
        int i = 0;

        while (i < array.Length)
        {
            resultArray[array[i]]++;
            i++;
        }
        return resultArray;
    }

    private static int[] LoadArray()
    {
        var readLine = Console.ReadLine();
        if (readLine != null)
        {
            string[] inputArray = readLine.Split(new char[] {' '});
            return Array.ConvertAll(inputArray, Convert.ToInt32);
        }
        return new int[0];
    }

    private static int GetElements()
    {
        int elementTotal;
        int.TryParse(Console.ReadLine(), out elementTotal);
        return elementTotal;
    }
}