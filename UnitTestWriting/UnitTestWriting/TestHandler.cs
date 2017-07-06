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


    public class TestHandler
    {
        private TraceListener[] listeners = new TraceListener[] {new TextWriterTraceListener(Console.Out)};
        private readonly ReadingTestings _readingTestings;


        public TestHandler()
        {
            Debug.Listeners.AddRange(listeners);
            _readingTestings = new ReadingTestings();
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
        public void YetAnotherTestToAddNumbers()
        {
            int number1 = 2;
            int number2 = 2;

            int result = number1 + number2;

            Assert.True(result == 4);
        }


       

     

        [Fact]
        public void AddingAnotherTest()
        {
            int value1 = 1;
            int value2 = 2;

            int result = value1 + value2;

            Assert.True(result == 3);
        }
    }
}
