using System;
using Xunit;
using System.Collections.Generic;
using System.Linq;
using Xunit.Abstractions;

public class ChargeTests
{
    private ITestOutputHelper _helper;
    private int expectedValue;

    public ChargeTests(ITestOutputHelper helper)
    {
        _helper = helper;
    }

    [Fact]
    public void Meter_Instance_Created()
    {
        List<IReading> readings = new List<IReading>();

        readings.Add(new ElectricityReading { RecordedOn = DateTime.Now.AddDays(-1), Value = 1000 });
        readings.Add(new ElectricityReading { RecordedOn = DateTime.Now, Value = 1020 });

        readings.Add(new HotWaterReading { RecordedOn = DateTime.Now.AddDays(-2), Value = 2000 });
        readings.Add(new HotWaterReading { RecordedOn = DateTime.Now, Value = 2010 });

        readings.Add(new SolarReading { RecordedOn = DateTime.Now, Value = 3000 });

        foreach (var currentReading in readings)
        {
            _helper.WriteLine($"{currentReading.GetType().Name} RecordedOn: {currentReading.RecordedOn.ToString()} Usage: {currentReading.Value}");
        }

        IReading []  lastTwoElectricityReadings = readings.Where(x => x.GetType().Name.Equals("ElectricityReading")).Reverse().Take(2).ToArray();
        var totalUsage =  ReadingUtilityHelper.CalculateUsage(lastTwoElectricityReadings[1], lastTwoElectricityReadings[0]);
        _helper.WriteLine($"Total Usage: {totalUsage}");
        expectedValue = 20;
        Assert.True(totalUsage == expectedValue);

        var expectedHotWaterUsage = 10;

        Assert.True(expectedHotWaterUsage == ReadingUtilityHelper.CalculateHotWaterUsage(readings));
        _helper.WriteLine($"{expectedHotWaterUsage}");

    }

    public class ReadingUtilityHelper
    {


        public static int CalculateHotWaterUsage(List<IReading> readings)
        {
            IReading[] lastTwoReadings = readings.Where(x => x.GetType().Name.Equals("HotWaterReading")).Reverse().Take(2).ToArray();

            if (lastTwoReadings.Length == 2)
                return CalculateUsage(lastTwoReadings[1], lastTwoReadings[0]);
            return 0;
        }
    public static int CalculateUsage(IReading startReading, IReading endReading)
        {
            return endReading.Value - startReading.Value;
        }
    }

    public interface IReading
    {
        DateTime RecordedOn { get; set; }
        int Value { get; set; }
        
    }

    public abstract class BaseReading : IReading
    {
        public DateTime RecordedOn { get; set; }
        public int Value { get; set; }
      
    }
    public class ElectricityReading : BaseReading
    {
       
    }

    public class HotWaterReading : BaseReading
    {
      
    }

    public class SolarReading : BaseReading
    {
      
    }
}