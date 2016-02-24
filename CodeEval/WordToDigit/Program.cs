using System;
using System.IO;
using System.Text;


class Program
{
    static int Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Usage: CreditCardRealFake [FileName]");
            return 1;
        }
        using (StreamReader reader = File.OpenText(args[0]))
        {
            while (reader.Peek() != -1)
            {
                string currentLine = string.Empty;
                if (!string.IsNullOrEmpty(currentLine = reader.ReadLine().ToLower()))
                {
                    string[] words = currentLine.Split(new char[] {';'});
                    if (words.Length > 0)
                    {
                        Console.WriteLine(GetDigits(words));
                    }
                }
            }

        }
        return 0;
    }

    private static string GetDigits(string[] words)
    {
        StringBuilder resultBuilder = new StringBuilder();
        foreach (string word in words)
        {
            switch (word)
            {
                case "zero" :
                    resultBuilder.Append("0");
                    break;
                case "one":
                    resultBuilder.Append("1");
                    break;
                case "two":
                    resultBuilder.Append("2");
                    break;
                case "three":
                    resultBuilder.Append("3");
                    break;
                case "four":
                    resultBuilder.Append("4");
                    break;
                case "five":
                    resultBuilder.Append("5");
                    break;
                case "six":
                    resultBuilder.Append("6");
                    break;
                case "seven":
                    resultBuilder.Append("7");
                    break;
                case "eight":
                    resultBuilder.Append("8");
                    break;
                case "nine":
                    resultBuilder.Append("9");
                    break;
            }
        }
        return resultBuilder.ToString();
    }
}

