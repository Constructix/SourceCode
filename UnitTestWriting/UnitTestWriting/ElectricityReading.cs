using System;

namespace UnitTestWriting
{
    public class ElectricityReading
    {
        private int _value;

        public ElectricityReading(int  value)
        {
            this.Value = value;
        }

        public int Value
        {
            get => _value;
            set
            {
                if (value == 0)
                    throw new Exception("Value cannot be zero.");
                if(value < 0)
                    throw new Exception("Value cannot be less than zero.");

                _value = value;
            }
        }

        public static int Usage(ElectricityReading oldReading, ElectricityReading newReading)
        {

            if(oldReading.Value > newReading.Value)
                throw new Exception("OldReading is greater than new reading.");

            return newReading.Value  - oldReading.Value;
        }
    }
}