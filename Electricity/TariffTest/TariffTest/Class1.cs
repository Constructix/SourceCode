using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TariffTest
{
    public class TarrifTests
    {
        [Fact]
        public void Tariff_CreateInstance_Instance()
        {
            Tariff newTariff = new Tariff(.23m);
            Assert.NotNull(newTariff);
        }

        [Fact]
        public void Tariff_RateGreaterThanZero_ValueIsValid()
        {
            Tariff newtTariff = new Tariff(.23m);
            Assert.Equal(newtTariff.Rate, .23m);
        }

        [Fact]
        public void Tariff_RateLessThanZero_ExceptionThrow()
        {

            Exception ex = Assert.Throws<Exception>(() => new Tariff(-.09m));
            Assert.Equal("Rate must be greater than zero.", ex.Message);

        }

        [Fact]
        public void Tariff_EffectiveFromNotNull_DateIsReturned()

        {
            var effectiveFrom = DateTime.Now.AddDays(-60);
            Tariff newTariff = new Tariff(0.23m, effectiveFrom );

            Assert.NotNull(newTariff.EffectiveFrom);
        }
        
        [Fact]
        public void Tariff_EffectiveFrom60DaysLessThanCurrentDate_DateIsReturned()

        {
            DateTime effectiveFrom = DateTime.Now.AddDays(-60);
            Tariff newTariff = new Tariff(0.23m, effectiveFrom);

            Assert.Equal(newTariff.EffectiveFrom.Date, DateTime.Now.AddDays(-60).Date);
        }
    }

    public class Tariff

    {
        private decimal _rate;

        private DateTime _effectiveFrom;

        public Tariff(decimal newRate)
        {
            this.Rate = newRate;
        }

        public Tariff(decimal newRate, DateTime effectiveFrom)
        {
            this.Rate = newRate;
            this.EffectiveFrom = effectiveFrom;
        }


        public DateTime EffectiveFrom
        {
            get { return _effectiveFrom; }
            set { _effectiveFrom = value; }
        }

        public decimal Rate
        {
            get { return _rate; }
            set
            {
                if(value <0.00m)
                    throw new Exception("Rate must be greater than zero.");
                _rate = value;
            }
        }

        
    }
}
