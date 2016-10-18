using System;
using Constructix.Extensions.Samples.Demo2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Constructix.Extensions.Tests.Demo2
{
    [TestClass]
    public class DateTimeExtensionTest
    {
        [TestMethod]
        public void ToXmlDateTime()
        {
            var dateTime =  new DateTime(2013, 10, 24, 13, 10, 15,951);
            Assert.AreEqual("2013-10-24T13:10:15.951Z", dateTime.ToXmlDateTime());
        }
    }
}
