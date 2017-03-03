using System;
using Xunit;

namespace Test
{
    public class ElectricityCalculatorTests
    {
        [Fact]
        public void ElectricityCalculatorCalc()
        {
            var tariffs = ElectricityTestHelper.LoadTariffCollection();

            var firstReading = new Reading {Value = 1000, RecordedOn = DateTime.Parse("01/03/2017")};
            var secondReading = new Reading {Value = 2000, RecordedOn = DateTime.Now};

            var usage = Reading.CalculateUsage(firstReading, secondReading);

            var totalUsage =   ElectricityCalculator.Calculate(usage, ElectricityTestHelper.GetCurrent().Rate);


            Assert.Equal(totalUsage, 12.50m);

            Console.WriteLine(totalUsage);

        }
    }
}