using System;
using Constructix.Home.Electricity.Business.DomainModels.Readings;
using Constructix.Home.Electricity.Business.DomainModels.Services;
using Constructix.Home.Electricity.Business.DomainModels.Tariffs.Implementors;
using Xunit;

namespace Constructix.Home.ElectricityReadingManagement
{
    public class ReadingCalculatorServiceTests
    {
        [Fact]
        public void CalculateReadingsTotalUsageReturns100()
        {
            Reading previousReading = new Reading(1000, DateTime.Parse("01/10/2018"), TariffType.Electricity);
            Reading latestReading = new Reading(1100, DateTime.Parse("01/10/2018"), TariffType.Electricity);

            ReadingResult result = ReadingCalculatorService.CalculateReadings(previousReading, latestReading);

            int expectedUsage = 100;

            Assert.True(expectedUsage.Equals(result.TotalUsage));

        }
        [Fact]
        public void CalculateReadingsTotalDaysReturns10()
        {
            Reading previousReading = new Reading(1000, DateTime.Parse("01/10/2018"), TariffType.Electricity);
            Reading latestReading = new Reading(1100, DateTime.Parse("10/10/2018"), TariffType.Electricity);

            ReadingResult result = ReadingCalculatorService.CalculateReadings(previousReading, latestReading);
            int expectedDays = 10;
            Assert.True(expectedDays.Equals(result.TotalDays));
        }
    }
}