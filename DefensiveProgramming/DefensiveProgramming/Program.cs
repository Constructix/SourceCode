using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DefensiveProgramming
{
    class Program
    {
        static void Main(string[] args)
        {

            Student stud = new RegularStudent("Richard");
            //stud.CanEnroll();
            Console.WriteLine(stud.Name);
        }
    }
}
