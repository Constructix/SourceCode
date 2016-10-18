using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDictionaryOps
{
    class Program
    {
        static void Main(string[] args)
        {
            var stock = new Dictionary<string, int>()
            {
                {"jDAys", 4},
                {"technoloyhour", 3}
            };
            Console.WriteLine("No of Shirts in Stock {0}", stock.Count);

            stock.Add("pluralsight",6);
            stock["buddhistgeeks"] = 5;

            stock["pluralsight"] = 7;
            Console.WriteLine(string.Format("\r\nstock[pluralsight] = {0}", stock["pluralsight"]));

            stock.Remove("jDays");

            Console.WriteLine("\r\nEnumerating");
            foreach (var keyValPair in stock)
            {
                Console.WriteLine("{0} {1}", keyValPair.Key, keyValPair.Value);
            }


        }
    }
}
