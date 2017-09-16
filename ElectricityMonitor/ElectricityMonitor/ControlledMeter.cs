using System;

namespace ElectricityMonitor
{
    public class ControlledMeter :  Meter
    {
        public ControlledMeter(int value, DateTime recordedOn) : base(value, recordedOn)
        {
        }
    }
}