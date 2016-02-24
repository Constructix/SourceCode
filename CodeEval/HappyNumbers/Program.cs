using System;
using System.Collections.Generic;
using System.IO;


class HappyNumbers
    {

    static Dictionary<int, int> _happyNumbers;
    static int Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine(string.Format("Usage: HappyNumbers [FileName]"));
                return 0;
            }

            using (StreamReader reader = File.OpenText(args[0]))
            {
                while (reader.Peek() != -1)
                {
                    _happyNumbers = new Dictionary<int, int>();
                    var currentLine =  reader.ReadLine();
                    if (!string.IsNullOrEmpty(currentLine))
                    {

                        bool isHappy = true;
                        int number;
                        if (int.TryParse(currentLine, out number))
                        {
                            int square = SquareNum(number);
                            if (square != 1)
                            {
                                _happyNumbers.Add(square, square);
                                int sum = 0;
                                string numberAsString = square.ToString();
                                do
                                {
                                    sum = 0;
                                    sum = GetSum(numberAsString, sum);
                                    isHappy = IsNumberValid(sum);
                                    if (!isHappy)
                                        break;
                                    
                                    numberAsString = sum.ToString();
                                } while (sum != 1);
                            }
                        }
                        else
                        {
                            isHappy = false;
                        }
                        Console.WriteLine(isHappy ? "1" : "0");
                    }
                }
            }
            return 0;
        }

    private static int GetSum(string numberAsString, int sum)
    {
        foreach (char t in numberAsString)
        {
            int result;
            int.TryParse(t.ToString(), out result);
            sum += SquareNum(result);
        }
        return sum;
    }

    private static bool IsNumberValid(int sum)
    {

        bool isValid = !_happyNumbers.ContainsKey(sum);
        if(isValid)
            _happyNumbers.Add(sum, sum);
        return isValid;
    }

    static int SquareNum(int number)
        {
            return number*number;
        }
    }
