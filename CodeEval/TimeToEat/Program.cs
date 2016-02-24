using System;
using System.Collections.Generic;
using System.IO;


public class Program
{
    static int Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine(string.Format("Usage: TimeToEat [FileName]"));
            return 1;
        }

        using (StreamReader reader = File.OpenText(@"D:\Files\TimeToEat.txt"))
        {
            while (reader.Peek() != -1)
            {
                string[] currentData = reader.ReadLine().Split(new char[] {' '});

                if (currentData.Length >= 2 && currentData.Length <= 20)
                {

                    List<TimeSpan> timeSpans = new List<TimeSpan>();
                    foreach (string currentItem in currentData)
                    {
                        TimeSpan ts;
                        if (TimeSpan.TryParse(currentItem, out ts))
                        {
                            timeSpans.Add(ts);
                        }
                    }
                }
            }
        }
        return 0;
    }
}
