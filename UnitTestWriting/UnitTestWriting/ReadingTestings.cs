using System;
using Xunit;

namespace UnitTestWriting
{
    public class ReadingTestings
    {
        public ReadingTestings()
        {
        }

        [Fact]
        public void ReadingValueCanNotBeSetToZero()
        {

            Exception ex = Assert.Throws<Exception>(() => new ElectricityReading(0));
            Assert.Equal(ex.Message, "Value cannot be zero.");
        }


        [Fact]
        public void ReadingValueCanNotBeSetToLessThanZero()
        {

            Exception ex = Assert.Throws<Exception>(() => new ElectricityReading(-1));
            Assert.Equal(ex.Message, "Value cannot be less than zero.");
        }

        [Fact]
        public void ReadingInstanceIsNotNull()
        {
            var newReading = new ElectricityReading(1000);
            Assert.NotNull(newReading);
        }


        [Fact]
        public void ReadingValueOneThousand()
        {
            var newReading = new ElectricityReading(1000);
            Assert.True(newReading.Value == 1000);
        }


        [Theory]
        [InlineData(1000, 2342, 1342)]
        [InlineData(2456, 4563, 2107)]
        public void ReadingValueUsage(int firstReading, int secondReading, int total)
        {
            var oldReading = new ElectricityReading(firstReading);
            var newReading = new ElectricityReading(secondReading);
            var usage = ElectricityReading.Usage(oldReading, newReading);
            Assert.True(usage == total);
        }

        [Fact]
        public void ReadingValuesNewReadingValueLessThanOldReadingExceptionExpected()
        {
            var oldReading = new ElectricityReading(200);
            var newReading = new ElectricityReading(100);


            Exception ex = Assert.Throws<Exception>(() => ElectricityReading.Usage(oldReading, newReading));
            Assert.Equal(ex.Message, "OldReading is greater than new reading.");
        }
    }
}