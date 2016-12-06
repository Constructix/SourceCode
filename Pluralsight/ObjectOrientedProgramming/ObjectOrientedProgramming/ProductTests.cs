using System.Collections.Generic;
using NUnit.Framework;

namespace ObjectOrientedProgramming
{
    [TestFixture]
    public class ProductTests
    {
        [Test]
        public void GetProductNameSeparatedBySpaces()
        {
            string expectedProductName = "Sonic Screwdriver";
            string productName = "SonicScrewdriver";
            var product = new Product { ProductName = "SonicScrewdriver"};

            Assert.IsTrue(expectedProductName.Equals(product.ProductName));
        }

        [Test]
        public void LogTest()
        {
            Product newProduct = new Product { CurrentPrice = 10.22m, ProductDescription = "Product Description", ProductId =  1, ProductName = "This is a test"};
            Customer customer = 
            new Customer
            {
                CustomerType = 1,
                Email = "r_jones@constructix.com.au",
                FirstName = "Richard",
                LastName = "Jones"
            };

            List<ILoggable> logs = new List<ILoggable>();
            logs.Add(newProduct);
            logs.Add(customer);

            var loggingSvc = new LoggingService {FileName = @"D:\Files\LoggingService.log"};

            loggingSvc.WriteToLog(logs);

        }
    }
}