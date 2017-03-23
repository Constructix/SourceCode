using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridChallenge
{
    class Program
    {
        static void Main(string[] args)
        {

            if (args.Length == 1)
            {
                Console.SetIn(File.OpenText(args[0]));
            }

            int gridSize;

            if (int.TryParse(Console.ReadLine(), out gridSize))
            {
                Console.WriteLine(gridSize);
            }
        }
    }
}
