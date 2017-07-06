using System;

namespace Constructix.Electricity
{
    public class Tariff
    {
        private decimal _rate;

        public Tariff(decimal rate)
        {
            Rate = rate;
        }

        public decimal Rate
        {
            get { return _rate; }
            set
            {

                if(value < 0.00m)
                    throw new  Exception("Rate cannot be less than zero.");
                if(value == 0.00m)
                    throw new Exception("Rate cannot be zero.");
                _rate = value;
            }
        }
    }
}