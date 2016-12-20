using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class Solution
{
        static void Main(string[] args)
        {


            string[] h_temp = Console.ReadLine().Split(' ');
            int[] unitsOfMeasure = Array.ConvertAll(h_temp, Int32.Parse);
            string word = Console.ReadLine();
        
            int startingIndex = 97;
            string input = "abc";

            int maxHeight = 0;
            for (int index = 0; index < word.Length; index++)
            {
                int letter = word[index];
                int resultIndex = letter - startingIndex ;

                if (unitsOfMeasure[resultIndex] > maxHeight)
                {
                    maxHeight = unitsOfMeasure[resultIndex];
                }
            }

            int area = input.Length * 1 * maxHeight;

            Console.WriteLine(area);
        }
    }

