using System;
using NUnit.Framework;

namespace Constructix.OnLineServices.Data.Contracts.Tests
{
    [TestFixture]
    public class ProductCategoryTests
    {
        [Test]
        public void ProductCategoryInstance()
        {
            IProductCategory productCategory = new ProductCategory();
            Assert.That(productCategory != null);
            Assert.That(productCategory.GetType() == typeof(ProductCategory));

        }

        [Test]
        public void ProductCategoryIdIsSet()
        {
            int expectedValue = 1;
            IProductCategory productCategory = new ProductCategory() {Id = 1};
            Assert.That(productCategory.Id == expectedValue);
        }

        [Test]
        public void ProductCategoryInUseDeletedShouldbeNull()
        {
            IProductCategory prodCategory = new ProductCategory();
            Assert.IsNull(prodCategory.RemovedOn);
        }

        [Test]
        public void ProductCategoryIsNoLongerInUseRemovedDateShouldBeSetNoExceptionExpected()
        {
            DateTime expectedRemovalDate = DateTime.Parse("01/01/2016");
            IProductCategory prodCategory = new ProductCategory() {RemovedOn = DateTime.Parse("01/01/2016")};
            Assert.IsNotNull(prodCategory.RemovedOn);
            Assert.That(prodCategory.RemovedOn.Value.Date.Equals(expectedRemovalDate.Date));
        }

        [Test]
        public void ProductCategoryNameIsSetNoExceptionExpected()
        {
            string expectedName = "Timber Decking";
            IProductCategory prodCategory = new ProductCategory {Name = "Timber Decking"};
            Assert.That(prodCategory.Name.Equals(expectedName));
        }

        [Test]
        public void ProductCategoryCreatedIsNotNull()
        {
            DateTime expectedCreatedDate = DateTime.Today;
            IProductCategory prodCategory = new ProductCategory();
            Assert.That(prodCategory.Created.Date.Equals(expectedCreatedDate.Date));
        }




    }
}