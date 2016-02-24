using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;


    class Program
    {
        static int Main(string[] args)
        {


            if (args[0].Length == 0)
            {
                Console.WriteLine("Invalid Usage: SwapElements [FileName]");
                return 1;
            }


            using(StreamReader reader = File.OpenText(args[0]))
            {
                while (reader.Peek() != -1)
                {
                    string inputString = reader.ReadLine();
                    if (!string.IsNullOrEmpty(inputString))
                    {

                        string[] numberArray = inputString.Split(new char[] {':'});
                        string[] indexesToChange = numberArray[1].Split(new char[] {','});

                        List<IndexPosition> positions = new List<IndexPosition>();

                        foreach (var s in indexesToChange)
                        {
                            if (!string.IsNullOrEmpty(s))
                                positions.Add(new IndexPosition(s));
                        }

                        List<int> numbers = new List<int>();


                        string[] numbersAsString = numberArray[0].Trim().Split(new char[] {' '});



                        // Need to check to make sure that index is not greater than the number in the array

                        foreach (IndexPosition indexPosition in positions)
                        {
                            if (indexPosition.First > numbersAsString.Length ||
                                indexPosition.Last > numbersAsString.Length)
                                continue;
                        }
                        


                        for (int index = 0; index < numbersAsString.GetLength(0); index++)
                        {
                            if (!string.IsNullOrEmpty(numbersAsString[index]))
                            {
                                int v;
                                int.TryParse(numbersAsString[index], out v);
                                numbers.Add(v);
                            }
                        }


                        foreach (IndexPosition indexPosition in positions)
                        {
                            SwapElements(numbers, indexPosition.First, indexPosition.Last);
                        }
                        StringBuilder builder = new StringBuilder();
                        foreach (int number in numbers)
                        {

                            builder.AppendFormat("{0} ", number);
                        }
                        builder = builder.Remove(builder.Length - 1, 1);
                        Console.WriteLine(builder.ToString());
                    }
                }
                
            }
            return 0;

        }

        static void SwapElements(List<int> numbers, int first, int second)
        {
            int temp = numbers[first];
            numbers[first] = numbers[second];
            numbers[second] = temp;
        }
    }

    public class IndexPosition
    {
        public int First { get; set; }
        public int Last { get; set; }


       

        public IndexPosition(string inputAsString)
        {
            var result = inputAsString.Split(new char[] {'-'});


            int first;
            int last;

            int.TryParse(result[0], out first);
            int.TryParse(result[1], out last);

            First = first;
            Last = last;


        }
    }