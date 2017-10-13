using Xunit;

namespace LuhnAlogrithmDemo
{
    public class LuhnTests
    {
        public LuhnTests()
        {
        }

        [Theory, 
         InlineData("79927398713",  true),
         InlineData("79927398710",  false),
         InlineData("79927398711",  false)
        ]
        public void LuhnAlgorithm(string inputNumber, bool expectedResult)
        {
            Assert.True(expectedResult == Luhn.Check(inputNumber));
        }
    }
}