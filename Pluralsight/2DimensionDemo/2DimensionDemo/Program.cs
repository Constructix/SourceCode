using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = new int[6, 6];


            matrix[0, 0] = 1;
            matrix[0, 1] = 1;
            matrix[0, 2] = 1;
            matrix[1, 1] = 1;

            matrix[2, 0] = 1;
            matrix[2, 1] = 1;
            matrix[2, 2] = 1;

            for (int x = 0; x < 6; x++)
            {
                for (int y = 0; y < 6; y++)
                {
                    Console.Write("{0} ", matrix[x, y]);
                }

                Console.WriteLine();
            }
        }
    }
}
