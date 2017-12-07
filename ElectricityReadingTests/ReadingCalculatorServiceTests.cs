using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Constructix.Home.Electricity;
using Constructix.Home.Electricity.Services;
using Constructix.Home.Electricity.Tariffs.Interface;
using Xunit;

namespace ElectricityReadingTests
{
    public class ReadingCalculatorServiceTests
    {
        private List<ITariff> _tariffs = new List<ITariff>();

        public ReadingCalculatorServiceTests()
        {
            InitialiseTariffs();
        }

        private void InitialiseTariffs()
        {
            throw new NotImplementedException();
        }


        [Fact]
        public void ReadingCalculatorService_NotNull_Created()
        {

            var expectedResult = 40;
            var firstReading = new Reading(1000, DateTime.Parse("01/03/2017"));
            var lastReading = new Reading(1040, firstReading.Recorded.AddDays(90));

            var actualResult = ReadingCalculatorService.CalculateReadings(firstReading, lastReading);

            Assert.True(expectedResult.Equals(actualResult.TotalUsage));
        }
    }
}
