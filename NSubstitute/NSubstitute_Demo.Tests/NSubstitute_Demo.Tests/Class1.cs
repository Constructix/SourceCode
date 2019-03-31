using System;
using Xunit;

namespace NSubstitute_Demo.Tests
{
    public class CalculatorServiceTests
    {
        [Fact]
        public void AddTests()
        {

            // 
            var calculator = new Moq.Mock<ICalculator>();
           var result = calculator.Setup(x => x.Add(1, 1)).Returns(2);

           var v = result.GetType().Name;

        }
    }

    public interface ICalculator
    {
        int Add(int first, int second);
    }
}
