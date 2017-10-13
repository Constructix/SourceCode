using Xunit;

namespace LuhnAlogrithmDemo
{
    public class LuhnTests
    {
        public LuhnTests()
        {
        }

        [Theory, 
         InlineData("79927398713", 3, true),
         InlineData("79927398710", 0, false),
         InlineData("79927398711", 1, false)
        ]
        public void LuhnAlgorithm(string inputNumber, int expectedCheckDigit, bool expectedIsValid)
        {
            var result = Luhn.Check(inputNumber);
            Assert.True(expectedIsValid == result);
        }
    }
}