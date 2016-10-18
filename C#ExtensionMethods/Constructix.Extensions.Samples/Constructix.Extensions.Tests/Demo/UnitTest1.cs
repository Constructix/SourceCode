using System;
using Constructix.Extensions.Samples.Demo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Constructix.Extensions.Tests.Demo
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ToLegacyFormat_20()
        {
            var dateTime = new DateTime(1920, 12,31);
            Assert.AreEqual("0201231", dateTime.ToLegacyFormat() );

        }
        [TestMethod]
        public void ToLegacyFormat_21()
        {
            var dateTime = new DateTime(2013, 10, 31);
            Assert.AreEqual("1131031", dateTime.ToLegacyFormat());
            Console.WriteLine(dateTime.ToString());

        }

        [TestMethod]
        public void ToLegacyName()
        {
            var name = "Richard Jones";
            var expected = "JONES, RICHARD";

            var result = name.ToLegacyFromat();
            Assert.AreEqual(result, expected);
            Console.WriteLine(result);
        }

    }
}
