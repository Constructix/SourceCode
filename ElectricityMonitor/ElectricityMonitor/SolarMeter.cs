using System;

namespace ElectricityMonitor
{
    public class SolarMeter : Meter
    {
        public SolarMeter(int value, DateTime recordedOn) : base(value, recordedOn)
        {
        }
    }
}