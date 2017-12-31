using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(ReverseWordsInSentence("richard Jones!"));
        }


        static string ReverseWordsInSentence(string inputSentence)
        {

            string[] words = inputSentence.Split(new char[] {' '});
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
    }
}
