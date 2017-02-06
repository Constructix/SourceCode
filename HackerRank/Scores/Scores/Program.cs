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

            string[] A_Tokens = Console.ReadLine().Split(new char[] {' '});
            string[] B_Tokens = Console.ReadLine().Split(new char[] {' '});
            
            int[] inputA = Array.ConvertAll(A_Tokens, Convert.ToInt32);
            int[] inputB = Array.ConvertAll(B_Tokens, Convert.ToInt32);


            int A_score = 0;
            int B_score = 0;

            for (int index = 0; index < inputA.Length; index++)
            {
                if (inputA[index] > inputB[index])
                    ++A_score;
                if (inputA[index] < inputB[index])
                    ++B_score;
            }

            Console.WriteLine($"{A_score} {B_score}");
        }

        
    }
}
