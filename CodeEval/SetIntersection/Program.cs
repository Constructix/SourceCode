using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static int Main(string[] args)
    {

        if (args.Length == 0)
        {
            Console.WriteLine(string.Format("Usage: SetIntersection [FileName]"));
            return 1;
        }
        using (StreamReader reader = File.OpenText(args[0]))
        {
            while (reader.Peek() != -1)
            {
                string []  array = reader.ReadLine().Split(new char[] {';'});
                List<int> firstNumbers = new List<int>();
                List<int> secondNumbers = new List<int>();
                
                
                    var test = array[0].Split(new char[] {','});
                    foreach (var s in test)
                    {
                        int num;
                        int.TryParse(s, out num);
                        firstNumbers.Add(num);
                    }
                test = array[1].Split(new char[] { ',' });
                foreach (var s in test)
                {
                    int num;
                    int.TryParse(s, out num);
                    secondNumbers.Add(num);
                }

                IEnumerable<int> union = firstNumbers.Intersect(secondNumbers);

                foreach (var i in union)
                {
                    Console.Write("{0} ", i);
                }
                Console.WriteLine();
            }
            return 0;
        }
    }
}