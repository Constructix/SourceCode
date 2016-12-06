using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrentQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            var shirts = new ConcurrentQueue<string>();
            shirts.Enqueue("Pluralsight");
            shirts.Enqueue("WordPress");
            shirts.Enqueue("Code School");


            Console.WriteLine("After Enqueuing:, count= " + shirts.Count);

            string item1;
            Boolean success = shirts.TryDequeue(out item1);
            if(success)
                Console.WriteLine($"Removing { item1}");
            else
            {
                Console.WriteLine("Queue is empty");
            }

            string item2 = string.Empty;
            success = shirts.TryPeek(out item2);
            if(success)
                Console.WriteLine($"\n\nPeeking: {item2}");
            else
                Console.WriteLine("queue was empty");

            Console.WriteLine("Enumerating:");
            foreach (string shirt in shirts)
            {
                Console.WriteLine(shirt);
            }

            Console.WriteLine($"\n\n After Enumerating, count = {shirts.Count}");
        }
    }
}
