using System;

namespace ElectricityMonitor
{
    public class PeakMeter : Meter
    {
        public PeakMeter(int value, DateTime recordedOn) : base(value, recordedOn)
        {
        }
    }
}