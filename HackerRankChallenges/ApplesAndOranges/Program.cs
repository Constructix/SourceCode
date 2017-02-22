using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplesAndOranges
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


            string[] tokens_s = Console.ReadLine().Split(' ');
            int s = Convert.ToInt32(tokens_s[0]);
            int t = Convert.ToInt32(tokens_s[1]);
            string[] tokens_a = Console.ReadLine().Split(' ');
            int a = Convert.ToInt32(tokens_a[0]);
            int b = Convert.ToInt32(tokens_a[1]);
            string[] tokens_m = Console.ReadLine().Split(' ');
            int m = Convert.ToInt32(tokens_m[0]);
            int n = Convert.ToInt32(tokens_m[1]);
            string[] apple_temp = Console.ReadLine().Split(' ');
            int[] apple = Array.ConvertAll(apple_temp, Int32.Parse);
            string[] orange_temp = Console.ReadLine().Split(' ');
            int[] orange = Array.ConvertAll(orange_temp, Int32.Parse);

            int appleTotal = 0;
            int orangeTotal = 0;

            // first Process apples
            for (int index = 0; index < m; index++)
            {
                if (apple[index] > 0)
                {
                    if ((apple[index] + a >= s) && (a +apple[index] <= t))
                    {
                        appleTotal++;
                    }
                }
            }

            for (int index = 0; index <n; index++)
            {
                if (orange[index] < 0)
                {
                    if ((b + orange[index] <= t) && (b  + orange[index]>= s))
                    {
                        orangeTotal++;
                    }
                }
            }
            Console.WriteLine(appleTotal);
            Console.WriteLine(orangeTotal);
        }
    }
}
