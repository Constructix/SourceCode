using System;
using System.Linq;
using Constructix.Extensions.Samples.Demo3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Constructix.Extensions.Tests.Demo3
{
    [TestClass]
    public class ReferenceDataSourceTests
    {
        [TestMethod]
        public void GetItems()
        {
            IReferenceDataSource source;
            source = new SqlReferenceDataSource();
            Assert.AreEqual(2, source.GetItems().Count());

            source = new XmlReferenceDataSource();
            Assert.AreEqual(2, source.GetItems().Count());

            source = new ApiReferenceDataSource();
            Assert.AreEqual(2, source.GetItems().Count());
        }

        [TestMethod]
        public void GetItemsByCode()
        {
            var source = new SqlReferenceDataSource();
            Assert.AreEqual(2, source.GetItemsByCode("xyz").Count());
            Console.WriteLine(source.GetItems().Count());
        }

        [TestMethod]
        public void GetItemsByCodeWithXmlDataSource()
        {
            var source = new XmlReferenceDataSource();
            Assert.AreEqual(2, source.GetItemsByCode("xyz").Count());
            Console.WriteLine(source.GetItems().Count());
        }
    }
}