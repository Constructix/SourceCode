using System;

namespace Constructix.Electricity
{
    public class ElectricityReading
    {
        const string ErrorMessageValueCanNotBeZero = "Value cannot be zero.";
        const string ErrorMessageValueCantBeLessThanZero = "Value cannot be less than zero.";
        const string ErrorMessageOldReadingGraterThanNewReading = "OldReading is greater than new reading.";

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
                {
                    
                    throw new Exception(ErrorMessageValueCanNotBeZero);
                }
                if(value < 0)
                {
                    
                    throw new Exception(ErrorMessageValueCantBeLessThanZero);
                }

                _value = value;
            }
        }

        public static int Usage(ElectricityReading oldReading, ElectricityReading newReading)
        {
            if(oldReading.Value > newReading.Value)
            {
                throw new Exception(ErrorMessageOldReadingGraterThanNewReading);
            }
            return newReading.Value  - oldReading.Value;
        }
    }
}