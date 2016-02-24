using System;
using System.IO;


class Program
{
    static int Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine(string.Format("Usage: SumOfDigits [FileName]"));
            return 1;
        }
        using (StreamReader reader = File.OpenText(args[0]))
        {
            while (reader.Peek() != -1)
            {
                var currentLine = reader.ReadLine();
                char[] charArray = currentLine.ToCharArray(0, currentLine.Length);
                int sum = 0;
                foreach (char currentChar in charArray)
                {
                    int number = 0;

                    if (int.TryParse(currentChar.ToString(), out number))
                    {
                        sum += number;
                    }

                }
                Console.WriteLine(sum);
            }
        }
        return 0;
    }
}
