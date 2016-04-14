using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = 1012;
            int length = number.ToString().Length;
            
            int tens = 10;
            int counter = 0;
            
            for (int i = 0; i <= length; i++)
            {
                int result = 0;
                if (i == 0)
                {
                    result = number%tens;
                    if (number%result == 0)
                        counter++;
                }
                if (i > 0)
                {
                    result = Traverse(number, tens);
                    if (result != 0)
                    {
                        if (number%result == 0)
                            counter++;
                        
                    }
                    tens *= tens;
                }
              
            }

            Console.WriteLine(counter);
        }
        static int Traverse(int number, int tens)
        {
            return (number/tens) % 10;
        }
    }
}

;