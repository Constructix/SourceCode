using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

public class UniqueElements
{
    public static  int Main(string[] args)
    {

        if (args.Length == 0)
        {
            Console.WriteLine("Invalid Usage");
            return 1;

        }


        using (StreamReader reader = File.OpenText(args[0]))
        {

            while (reader.Peek() != -1)
            {

                List<int> numbers = new List<int>();
                var currentLine = reader.ReadLine().Split(new char[] {','});


                foreach (var s in currentLine)
                {
                    int currentValue;
                    if(int.TryParse(s, out currentValue))
                        numbers.Add(currentValue);
                }
                StringBuilder result = new StringBuilder();


                foreach (int currentNum in numbers.Distinct().ToList())
                {
                    result.AppendFormat("{0},", currentNum);
                }
                result = result.Remove(result.Length - 1, 1);

                Console.WriteLine(result);
            }
        }
        return 0;
    }
}