using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaDelegateDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, string> convert = s => s.ToUpper();

            string name = "Dakota";

            Console.WriteLine("Using Func<string, string> Lamdbas");
            Console.WriteLine(convert(name));


            Func<string, string> selector = str => str.ToUpper();

            string[] words = {"orange", "apple", "Article", "elephant"};

            IEnumerable<string> aWords = words.Select(selector);

            foreach (string aWord in aWords)
            {
                Console.WriteLine(aWord);
            }

        }
    }
}
