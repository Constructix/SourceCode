using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static int Main(string[] args)
    {

        if (args.Length == 0)
        {
            Console.WriteLine(string.Format("Usage: Fibnacci [FileName]"));
            return 1;
        }

        using (StreamReader reader = File.OpenText(args[0]))
        {
            while (reader.Peek() != -1)
            {
                var currentLine = reader.ReadLine();
                int numberOfFibsToGenerate;

                if (int.TryParse(currentLine, out numberOfFibsToGenerate))
                {

                    List<int> numbers = new List<int> {0, 1};

                    int counter = 1;
                    int index = 2;

                    while (counter < numberOfFibsToGenerate)
                    {
                        numbers.Add(numbers[index - 1] + numbers[index - 2]);
                        index++;
                        counter++;
                    }
                    Console.WriteLine(numbers[numberOfFibsToGenerate]);
                }
            }
        }
        return 0;
    }
}

