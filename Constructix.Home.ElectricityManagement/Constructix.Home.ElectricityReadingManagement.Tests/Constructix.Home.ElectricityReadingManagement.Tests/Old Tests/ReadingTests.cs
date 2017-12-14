using System;
using Constructix.Home.Electricity.Business.DomainModels.Readings;
using Constructix.Home.Electricity.Business.DomainModels.Services;
using Constructix.Home.Electricity.Business.DomainModels.Tariffs.Implementors;
using Xunit;
using Xunit.Abstractions;

namespace Constructix.Home.ElectricityReadingManagement.Old_Tests
{
    public class ReadingTests
    {
        private ITestOutputHelper _helper;

        private Reading previousReading;
        private Reading currentReading;

        public ReadingTests(ITestOutputHelper helper)
        {
            _helper = helper;
        }

        [Theory]
        [InlineData(37660, 40287)]
        public void CalculateLastQuarter2017(int previousReadingValue, int currentReadingValue)
        {
            previousReading = new Reading(previousReadingValue, DateTime.Parse("14/09/2017"), TariffType.Electricity);
            currentReading = new Reading(currentReadingValue, DateTime.Parse("10/12/2017 5:32 PM"), tariffType: TariffType.Electricity);


            var result = ReadingCalculatorService.CalculateReadings(previousReading, currentReading);

            _helper.WriteLine($"Total Usage: {result.TotalUsage.ToString()}");
            _helper.WriteLine($"Total Days: {result.TotalDays.ToString()}");
        }
    }
}
