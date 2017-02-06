using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ClassLibrary1
{
    
    public class ReadingTest
    {
        [Fact]
        public void ReadingInstanceIsNotNull()
        {
            IReading reading = new Reading();
            Assert.NotNull(reading);
        }

        [Fact]
        public void Reading_ValueIsNotNull()
        {
            IReading reading = new Reading() {Value = 1000};
            Assert.Equal(reading.Value, 1000);
        }

        [Fact]
        public void Reading_ReadOnIsNotGreaterThanCurrentSystemDate()
        {
            IReading reading = new Reading() {ReadOn =DateTime.Today};

            int compareResult = DateTime.Today.CompareTo(reading.ReadOn);
            Assert.NotEqual(compareResult, 1);
        }
    }

    public class Reading : IReading
    {
        public int Value { get; set; }
        public DateTime ReadOn { get; set; }
    }

    public interface IReading
    {
        int Value { get; set; }
        DateTime ReadOn { get; set; }
    }
}
