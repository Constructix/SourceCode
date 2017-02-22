using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kangaroo
{
    class Program
    {
        static void Main(string[] args)
        {



            if (args.Length > 0)
            {
                var reader = System.IO.File.OpenText(args[0]);
                Console.SetIn(reader);
            }

            string[] tokens_x1 = Console.ReadLine().Split(' ');
            int x1 = Convert.ToInt32(tokens_x1[0]);
            int v1 = Convert.ToInt32(tokens_x1[1]);
            int x2 = Convert.ToInt32(tokens_x1[2]);
            int v2 = Convert.ToInt32(tokens_x1[3]);


            if((v1 % 2 == 0) == (v2 % 2 ==0))
            {

                if ((x2 > x1) && (v2 > v1))
                    Console.WriteLine("NO");
             
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
