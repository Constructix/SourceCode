using System;
using System.Collections.Generic;
using System.IO;


class Program
    {
        static int Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Usage: CreditCardRealFake [FileName]");
                return 1;
            }
            using (StreamReader reader = File.OpenText(args[0]))
            {
                while (reader.Peek() != -1)
                {
                    string creditCard = string.Empty;
                    if (!string.IsNullOrEmpty(creditCard = reader.ReadLine()))
                    {
                        
                        List<int> creditCardDigits = new List<int>();
                        for (int index = 0; index < creditCard.Length; index++)
                        {
                            if (Char.IsDigit(creditCard, index))
                            {
                                int digit;
                                if (int.TryParse(creditCard[index].ToString(), out digit))
                                    creditCardDigits.Add(digit);
                            }
                        }

                        if (creditCardDigits.Count == 16)
                        {
                            int total = 0;
                            for (int index = 0; index < creditCardDigits.Count; index++)
                            {
                                if (index%2 == 0)
                                {
                                    total += creditCardDigits[index]*2;
                                }
                                else
                                {
                                    total += creditCardDigits[index];
                                }
                            }
                            Console.WriteLine(total%10 == 0 ? "Real" : "Fake");
                        }
                        else
                            Console.WriteLine();
                    }
                }
            }
            return 0;
        }
    }
