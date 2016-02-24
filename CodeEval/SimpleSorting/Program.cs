using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


    class SimpleSorting
    {
        static int Main(string[] args)
        {

            if (args.Length == 0)
            {
                Console.WriteLine(string.Format("Usage: SumOfDigits [FileName]"));
                return 1;
            }

            using (StreamReader reader = File.OpenText(args[0]))
            {
                while (reader.Peek() != -1)
                {
                    
                    var readLine = reader.ReadLine();
                    if (!string.IsNullOrEmpty(readLine))
                    {
                        string[] currentValues = readLine.Split(new char[] {' '});

                        List<decimal> values = new List<decimal>();
                        foreach (string currentValue in currentValues)
                        {
                            decimal value;
                            if(decimal.TryParse(currentValue, out value))
                                values.Add(value);
                        }
                        var ascendingValues = values.OrderBy(x => x);

                        StringBuilder builder = new StringBuilder();
                        foreach (decimal currentNumber in ascendingValues)
                        {
                            builder.AppendFormat("{0:#0.000} ", currentNumber);
                        }
                        
                        Console.WriteLine(builder.ToString());

                    }
                }
            }
            return 0;
        }
    }


