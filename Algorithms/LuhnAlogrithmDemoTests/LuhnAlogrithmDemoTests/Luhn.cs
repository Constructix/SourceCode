using System;
using System.Linq;

namespace LuhnAlogrithmDemo
{
    public class Luhn
    {
        public static bool Check(string inputNumber)
        {
            bool checkDigitValid = int.TryParse(inputNumber.Substring(inputNumber.Length - 1), out int checkDigit);
            const string InputNumberInvalidMessage = "Input number is invalid.";
            if(!checkDigitValid)
                throw new Exception(InputNumberInvalidMessage);
           
            int[] tempValues = new int [inputNumber.Length-1];
            int counter = 2;

            for (int index = inputNumber.Length - 2; index >= 0; index--)
            {
                var currentValueValid = int.TryParse(inputNumber.Substring(index, 1), out int currentValue);
                if(!currentValueValid)
                    throw new Exception(InputNumberInvalidMessage);
                tempValues[index] = currentValue;
                if (counter % 2 == 0)
                {
                    const int MultiplyFactory = 2;

                    tempValues[index] *= MultiplyFactory;
                    const int Numerator = 9;
                    if (tempValues[index] > Numerator)
                        tempValues[index] -= Numerator;
                }
                counter++;
            }
            const int Modulus = 10;
            const int MultiplyConstant = 9;

            int resultCheckDigit = (tempValues.Sum() * MultiplyConstant) % Modulus;
            bool result = resultCheckDigit == checkDigit;
            return result;
        }
    }
}