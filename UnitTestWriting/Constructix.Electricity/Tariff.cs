using System;

namespace Constructix.Electricity
{
    public class Tariff
    {
        const string ErrorMessageRateLessThanZero = "Rate cannot be less than zero.";
        const string ErrorMessageRateIsZero = "Rate cannot be zero.";

        private decimal _rate;

        public Tariff(decimal rate)
        {
            Rate = rate;
        }

        public decimal Rate
        {
            get => _rate;
            set
            {
                if(value < decimal.Zero)
                {
                    
                    throw new  Exception(ErrorMessageRateLessThanZero);
                }
                if(value == decimal.Zero)
                {
                    
                    throw new Exception(ErrorMessageRateIsZero);
                }
                _rate = value;
            }
        }
    }
}