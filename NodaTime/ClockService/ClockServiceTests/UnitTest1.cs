

using System;
using NodaTime;
using Shouldly;
using Xunit;

namespace ClockServiceTests
{
    public class ClockServiceTests
    {
        [Fact]
        public void GetTime()
        {

            int currentYear = 2020;
            
            var currentDatTime = ClockService.LocalDateTime();
            currentDatTime.ShouldNotBeNull();
            currentDatTime.Year.ShouldBe(2020);
            
            
        }
    }

    public class ClockService : IClockService
    {
        
          static  ClockService()
        {
            TimeZone = DateTimeZoneProviders.Tzdb.GetSystemDefault();
        }
        static  DateTimeZone TimeZone {get;}
        public static LocalDateTime LocalDateTime() => SystemClock.Instance.GetCurrentInstant().InZone(DateTimeZoneProviders.Tzdb.GetZoneOrNull(TimeZone.ToString())).LocalDateTime;
        
    }

    public interface IClockService
    {
    }
}