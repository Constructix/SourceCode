using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public static class QueueConsole
    {

        public static void Main()
        {
            var shirts = new Queue<string>();
            shirts.Enqueue("Pluralsight");
            shirts.Enqueue("WordPress");
            shirts.Enqueue("Code School");


            Console.WriteLine("After Enqueuing:, count= " + shirts.Count);

            string item1 = shirts.Dequeue();
            Console.WriteLine($"Removing { item1}");

            string item2 = shirts.Peek();
            Console.WriteLine($"\n\nPeeking: {item2}");

            Console.WriteLine("Enumerating:");
            foreach (string shirt in shirts)
            {
                Console.WriteLine(shirt);
            }

            Console.WriteLine($"\n\n After Enumerating, count = {shirts.Count}");
        }
    }

}
