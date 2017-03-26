using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

//https://www.hackerrank.com/challenges/the-grid-search

class Solution
{
        private static readonly int Success = 0;
        private static readonly int Failure = 1;

        static void Main(string[] args)
        {
            if (args.Length == 1)
            {
                Console.SetIn(File.OpenText(args[0]));
            }

            int t = Convert.ToInt32(Console.ReadLine());
            for (int a0 = 0; a0 < t; a0++)
            {
                StringBuilder currentText = new StringBuilder();

                string[] tokens_R = Console.ReadLine().Split(' ');
                int R = Convert.ToInt32(tokens_R[0]);
                int C = Convert.ToInt32(tokens_R[1]);
                string[] G = new string[R];
                for (int G_i = 0; G_i < R; G_i++)
                {
                    currentText.Append(Console.ReadLine());
                }
                string[] tokens_r = Console.ReadLine().Split(' ');
                int r = Convert.ToInt32(tokens_r[0]);
                int c = Convert.ToInt32(tokens_r[1]);
                string[] P = new string[r];
                bool prevMatch = true;
                int startAtPosition = -1;
                bool success = true;

                int currentRow, previousRow;

                int previousPosition = -1;
                currentRow = previousRow = 0;
                string newText = currentText.ToString();
                CheckValues(r, P, newText,  prevMatch, previousPosition, C, success);
            }



            Environment.Exit(Success);
        }

    private static void CheckValues(int r, string[] searchPattern, string newText, bool prevMatch,
        int previousPosition, int columnCount, bool success)
    {

        int startAtPosition = -1;

        for (int patternIndex = 0; patternIndex < r; patternIndex++)
        {
            searchPattern[patternIndex] = Console.ReadLine();

            Regex regex = new Regex(searchPattern[patternIndex]);
            Match testMatch = regex.Match(newText, startAtPosition + 1);
            if (testMatch.Success && prevMatch)
            {
                startAtPosition = testMatch.Index;
                if (previousPosition == -1)
                {
                    previousPosition = startAtPosition;
                }
                if ((startAtPosition - previousPosition) < columnCount * 2)
                    previousPosition = startAtPosition;
                else
                {
                    success = false;
                    break;
                }
            }
            else
            {
                success = prevMatch = false;
            }
        }

        Console.WriteLine(success == true ? "YES" : "NO");
    }
}

