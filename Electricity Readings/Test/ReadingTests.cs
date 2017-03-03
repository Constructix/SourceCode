using System;
using System.Diagnostics.Eventing.Reader;
using System.IO.Pipes;
using Xunit;

namespace Test
{
    public class ReadingTests
    {
        [Fact]
        public void ReadingNotNull()
        {
            var expectedValue = 1000;
            var reading = new Reading();
            reading.Value = expectedValue;
            Assert.True(reading.Value == expectedValue);
        }

        [Fact]
        public void ReadingCalculation()
        {
            var expectedReadingValue = 200;
            var firstReading = new Reading() {Value = 1000};
            var secondReading = new Reading() {Value = 1200};
            var totalUsage = Reading.CalculateUsage(firstReading, secondReading);

            Assert.True(totalUsage == expectedReadingValue);
        }

        [Fact]
        public void SecondReadingLessThanFirstReadingExpectsExceptionToBeThrown()
        {
            var firstReading = new Reading() {Value = 1200};
            var secondReading = new Reading() {Value = 1000};
            Exception ex = Assert.Throws<Exception>(() => Reading.CalculateUsage(firstReading, secondReading));

            Assert.Equal("Second Reading cannot be < than first reading.", ex.Message);
        }


        [Fact]
        public void ValueInDate()
        {
            var reading = new Reading() {RecordedOn = DateTime.Parse("01/01/2017")};
        }

    }
}