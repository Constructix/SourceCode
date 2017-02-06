using System.Runtime.Remoting;
using Xunit;

namespace PowerReading
{
    public class ReadingTest
    {
        [Fact]
        public void ReadingInstanceCreatedNoExceptionExpected()
        {
            var reading = new Reading();
            Assert.IsType<Reading>(reading);
        }

        [Fact]
        public void ReadingValueIsNotNegativeNoExceptionExpected()
        {
            var reading = new Reading();
            reading.Value = 1000;

            Assert.True(reading.Value > 0);
        }
    }

    public class TariffTest
    {
        [Fact]
        public void TariffInstanceCreatedNoExceptionExpecte()
        {
            var tariff = new Tariff();
            Assert.IsType<Tariff>(tariff);
        }
    }

    public class Tariff
    {
    }

    public class Reading    
    {

        


        public int Value { get; set; }
    }
}