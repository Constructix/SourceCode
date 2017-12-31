using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class KnockKnockService
    {

        public long Fibonacci(long num1)
        {
            long sum = 0;
            if (num1 <= 2)
                return 1;
            sum += Fibonacci(num1 - 1) + Fibonacci(num1 - 2);
            return sum;

        }
        public string ReverseStringsInSentence(string sentence)
        {
            string[] words = sentence.Split(new char[] { ' ' });
            StringBuilder sentenceBuilder = new StringBuilder();

            foreach (var word in words)
            {
                for (int i = word.Length - 1; i >= 0; i--)
                {
                    sentenceBuilder.Append(word[i]);
                }
                sentenceBuilder.Append(" ");
            }
            sentenceBuilder.Remove(sentenceBuilder.Length - 1, 1);

            return sentenceBuilder.ToString();
        }

        public string TriangleType(Triangle inputTriangle)
        {

            return Triangle.TriangleType(inputTriangle);
        }

        public string Token => "e789d4e2-fd2d-4ff7-b668-19f419186650";


    }
}
