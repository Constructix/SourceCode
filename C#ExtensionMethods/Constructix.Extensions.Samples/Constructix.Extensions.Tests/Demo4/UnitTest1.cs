using System;
using System.Linq;
using Constructix.Extensions.Samples.Demo3;
using Constructix.Extensions.Samples.Demo4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Constructix.Extensions.Tests.Demo4
{
    [TestClass]
    public class IReferenceDataSourceCollectionExtensionTests

    {
        [TestMethod]
        public void GetAllItemsByCode_Array()
        {
            var sources = new IReferenceDataSource[]
                {new SqlReferenceDataSource(), new XmlReferenceDataSource(), new ApiReferenceDataSource()};

            var items = sources.GetAllItemsByCode("xyz");
            Assert.AreEqual(6, items.Count());

        }
    }
}
