using System;
using System.IO;


public class Solution
    {


        public static int Main(string [] args)
        {

            if (args.Length == 0)
            {
                return 0;
            }
            var streamReader = new StreamReader(args[0]);
            Console.SetIn(Console.In);
            var input = GetInputData();
            var numbers = Array.ConvertAll(input, Convert.ToInt64);
            Int64 min = Int64.MaxValue;
            Int64 max = Int64.MinValue;

            Initial(numbers,ref min,ref max);

            Console.WriteLine("{0} {1}", min, max);
            return 1;
        }

        private static string[] GetInputData()
        {
            string[] input = Console.ReadLine().Split(new char[] {' '});
            return input;
        }

        private static void SetInputParameters(string inputArgument)
        {
          
           
            Console.SetOut(Console.Out);
        }

        public static  void Initial(Int64[] numbers, ref Int64 min, ref Int64 max)
        {

        Int64 sum = 0;

            for (Int64 index = 0; index < numbers.Length; index++)
            {
                for (Int64 x = 0; x < numbers.Length; x++)
                {
                    if (x != index)
                    {
                        sum += numbers[x];
                    }
                }

                if (sum > max)
                    max = sum;
                if (sum < min)
                    min = sum;

                sum = 0;
            }
        }
    }

