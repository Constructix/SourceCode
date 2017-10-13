using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace LuhnAlogrithmDemo
{
    
  
    public class DoubleNumberTests
    {

        private Xunit.Abstractions.ITestOutputHelper _helper;
        private readonly LuhnTests _luhnTests;

        public DoubleNumberTests(ITestOutputHelper helper)
        {
            _helper = helper;
            _luhnTests = new LuhnTests();
        }

        [Fact]
        public void DoubleEveryNumberCheck()
        {
            string [] testInput = new string[] {"7992739871"};
            int[] doubleInputs = new int[] {18, 4, 6, 16, 2};
            int [] testArray = new int[5];
            int counter = 0;
            for (int index = testInput[0].Length; index > 0; index = index - 2)
            {
                int currentValue = 0;
                int.TryParse(testInput[0].Substring(index-1,1), out currentValue);
                testArray[counter] = currentValue * 2;
                WriteLine(testArray[counter].ToString());
                counter++;
            }
            
            var reversedArray = testArray.Reverse();
            Assert.Equal(reversedArray, doubleInputs);

        }

        [Fact]
        public void SumEveryNumber()
        {
            int [] doubleDigits = new int[] { 7, 18, 9, 4, 7, 6, 9, 16, 7, 2};
            int[] expectedResult = new int[] {9, 4, 6, 7, 2};

            int [] testArray = new int[5];
            int counter = 0;
            for (int index = doubleDigits.Length; index > 0; index = index - 2)
            {
                if(doubleDigits[index - 1] > 9)
                    testArray[counter] = doubleDigits[index - 1] - 9;
                else
                {
                    testArray[counter] = doubleDigits[index - 1];
                }
                WriteLine(testArray[counter].ToString());
                counter++;
            }
            Assert.Equal(testArray.Reverse(), expectedResult);
        }


        public void WriteLine(string message)
        {
            _helper.WriteLine(message);
        }
    }
}
