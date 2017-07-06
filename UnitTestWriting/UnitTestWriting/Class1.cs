using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace UnitTestWriting
{


    public class Class1
    {
        private TraceListener[] listeners = new TraceListener[] {new TextWriterTraceListener(Console.Out)};

        

        public Class1()
        {
            Debug.Listeners.AddRange(listeners);
            
            
        }

        [Fact]
        public void AddNumbers()
        {
            int number1 = 2;
            int number2 = 2;

            int result = number1 + number2;

            Assert.True(result == 4);
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
        [InlineData(2456,4563,2107 )]
        public void ReadingValueUsage(int firstReading, int secondReading, int total)
        {
            var oldReading = new ElectricityReading(firstReading);
            var newReading = new ElectricityReading(secondReading);
            var usage = ElectricityReading.Usage(oldReading, newReading);
            Assert.True(usage == total);

           
            Debug.WriteLine("This is  a test");
        }

        [Fact]
        public void ReadingValuesNewReadingValueLessThanOldReadingExceptionExpected()
        {
            var oldReading = new ElectricityReading(200);
            var newReading = new ElectricityReading(100);


            Exception ex = Assert.Throws<Exception>(() => ElectricityReading.Usage(oldReading, newReading));
            Assert.Equal(ex.Message, "OldReading is greater than new reading.");
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
    }

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
