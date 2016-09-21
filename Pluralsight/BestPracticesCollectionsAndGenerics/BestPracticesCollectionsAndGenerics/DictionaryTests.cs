using System;
using System.Collections.Generic;
using NUnit.Framework;
using PluralsightData;

namespace GenericDictionaries
{
    [TestFixture]
    public class DictionaryTests
    {
        [Test]
        public void SortedDictionary_Initialise()
        {
            var expectedVendors = new SortedDictionary<string,Vendor>()
            {
                {"XYZ Inc", new Vendor {VendorId = 8,  
                                        CompanyName = "XYZ Inc",
                                        Email = "xyz@xyz.com"}},
                { "ABC Corp", new Vendor {VendorId = 5,
                                            CompanyName = "ABC Corp", Email = "abc@abc.com"}}
                
            };
            Console.WriteLine("Using Sorted Dictionary");
            Console.WriteLine("Items are sorted....");
            foreach (var key in expectedVendors.Keys)
            {
                Console.WriteLine(key);
            }
        }

        [Test]
        public void VendorRepository()
        {

            //Arrange
            var repository = new VendorRepository();

            var expectedVendors = new Dictionary<string, Vendor>()
            {
                { "ABC Corp", new Vendor {VendorId = 5, CompanyName = "ABC Corp", Email = "abc@abc.com"}},
                {"XYZ Inc", new Vendor {VendorId = 8, CompanyName = "XYZ Inc", Email = "xyz@xyz.com"}}
            };

            //Act

            var actual = repository.RetrieveWithKeys();

            //Assert

            CollectionAssert.AreEqual(expectedVendors, actual,new VendorComparer());

        }

        [Test]
        public void GetVendor()
        {

            var repo = new VendorRepository();

            var vendors = repo.RetrieveWithKeys();
            Vendor vendor;

            if (vendors.TryGetValue("XYZ Inc", out vendor)) // more efficient
            {
                Console.WriteLine(vendor.Email);
                Assert.IsTrue(vendor.CompanyName.Equals("XYZ Inc"));
            }
        }

        [Test]
        public void IterateThrough_Dictionary()
        {
            var repository = new VendorRepository();
            var vendors = repository.RetrieveWithKeys();
            foreach (var companyName in vendors.Keys)
            {
                Console.WriteLine(companyName);
            }

            Console.WriteLine();

            foreach (Vendor vendor in vendors.Values)
            {
                Console.WriteLine(vendor.VendorId);
            }
        }


        [Test]
        public void Initialise_Dictionary()
        {
            var states = new Dictionary<string, string>()
            {
                {"CA", "California"},
                {"WA", "Washington"},
                {"NY", "New York"}
            };

            foreach (KeyValuePair<string, string> keyValuePair in states)
            {
                Console.WriteLine(keyValuePair.Key);
            }
        }
    }
}
