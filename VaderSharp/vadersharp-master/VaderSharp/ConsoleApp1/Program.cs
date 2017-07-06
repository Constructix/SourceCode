using System;
using VaderSharp;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            SentimentIntensityAnalyzer analyser = new SentimentIntensityAnalyzer();

            var results = analyser.PolarityScores("Wow, this package is amazingly easy to use");

            Console.WriteLine($"+ve scores : { results.Positive}");
            Console.WriteLine($"-ve scores : { results.Negative}");
            Console.WriteLine($"neutral scores : { results.Neutral}");
            Console.WriteLine($"Compound scores : { results.Compound}");

        }
    }
}