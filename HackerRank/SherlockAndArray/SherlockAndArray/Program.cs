using System;
using System.Diagnostics;
using System.IO;

namespace Solution
{
    class Solution
    {
        static int Main(string[] args)
        {
            StreamReader reader = null;
            bool useFile = args.Length > 0;
            if (useFile)
            {
                reader = new StreamReader(args[0]);
                Console.SetIn(reader);
            }

            int testCases;
            if (int.TryParse(Console.ReadLine(), out testCases))
            {

                
                for (int i = 0; i < testCases; i++)
                {
                    Stopwatch watch = new Stopwatch();

                    watch.Start();
                    if (testCases >= 1 || testCases <= 10)
                    {
                        int arraySize;
                        if (int.TryParse(Console.ReadLine(), out arraySize))
                        {
                            if (arraySize <= 100000)
                            {
                                var array = InputValuesIntoArray(arraySize);
                                if (array.Length == arraySize)
                                {

                                    if (arraySize != 1)
                                    {
                                        bool matchFound = MatchFound(arraySize, array);
                                        Console.WriteLine(matchFound ? "YES" : "NO");
                                    }
                                    else
                                    {
                                        Console.WriteLine("YES");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("NO");
                                }
                            }
                            else 
                                Console.WriteLine("NO");
                        }
                        else
                        {
                            Console.WriteLine("NO");
                        }
                       
                    }
                    watch.Stop();
                    Console.WriteLine(watch.Elapsed.TotalSeconds);
                }
            }
            if (useFile)
                reader.Close();
            return 0;
        }

        private static bool MatchFound(int arraySize, int[] array)
        {


            int i = 0;
            int j = array.Length - 1;
            int sum = 0;
            while (i != j)
            {
                if (sum >= 0)
                {
                    sum -= array[j];
                    j--;
                }
                else
                {
                    sum += array[i];
                    i++;
                }

            }
            return sum == 0 ? true : false;
            
        }

        private static int[] InputValuesIntoArray(int arraySize)
        {
            string[] input = Console.ReadLine().Split(new char[] { ' ' });

            if(input.Length <= 100000)
                return Array.ConvertAll(input, Convert.ToInt32);
            else
            {
                return new int[1];
            }
        }
    }
}
