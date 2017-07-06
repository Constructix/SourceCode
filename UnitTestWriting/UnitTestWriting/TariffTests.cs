using System;
using Constructix.Electricity;
using Xunit;

namespace UnitTestWriting
{
    public class TariffTests
    {
        [Fact]
        public void TariffInstanceCreated()
        {
            Tariff tariff = new Tariff(.235m);
            Assert.NotNull(tariff);
        }

        [Fact]
        public void InvalidRateAmountLessThanZero()
        {
            Exception ex =  Assert.Throws<Exception>(() =>  new Tariff(-2));

            Assert.Equal(ex.Message, "Rate cannot be less than zero.");

        }
        [Fact]
        public void InvalidRateAmountLessEqualsZero()
        {
            Exception ex = Assert.Throws<Exception>(() => new Tariff(0));

            Assert.Equal(ex.Message, "Rate cannot be zero.");

        }
    }
}