using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleType
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(TriangleType(10,10,10));
            Console.WriteLine(TriangleType(3, 12, 12));
            Console.WriteLine(TriangleType(12, 3, 12));
            Console.WriteLine(TriangleType(12, 12,3));
            Console.WriteLine(TriangleType(3, 4, 5));
            Console.WriteLine(TriangleType(5, 4, 3));
            Console.WriteLine(TriangleType(4, 5, 3));
        }
        static string TriangleType(int a, int b, int c)
        {
            if (a == b && a == c && b ==c)
                return "Equilateral";
            else if (a == b || a == c || b == c)
                return "Isosceles";
            else if (a != b || a != c || b != c)
                return "Scalene";
            return "Error";
        }
    }
}


