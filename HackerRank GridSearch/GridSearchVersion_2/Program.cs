using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GridSearchVersion_2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            string [] matrix = new string[] { "7283455864", "6731158619", "8988242643", "3830589324", "2229505813", "5633845374", "6473530293", "7053106601", "0834282956", "4607924137" };
            string [] searchMatrix = new string[] {"9505", "3845", "3530"};

            */


            var fileName = @"D:\Files\matrix_01.txt";
            var dataMatrix = System.IO.File.OpenText(fileName).ReadToEnd();

            Regex regEx  = new Regex("9505", RegexOptions.Multiline);
            MatchCollection collection = regEx.Matches(dataMatrix);



            
            for (int i = 0; i < collection.Count; i++)
            {
                Console.WriteLine(collection[i].Index);

                Console.WriteLine(collection[i].Groups.Count);
            }

        }
    }
}
