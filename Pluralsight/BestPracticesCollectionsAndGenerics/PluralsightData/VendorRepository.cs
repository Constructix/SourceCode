using System.Collections.Generic;

namespace PluralsightData
{
    public class VendorRepository
    {

        private List<Vendor> vendors;
        public List<Vendor> Retrieve()
        {
            if(vendors == null)
                vendors = new List<Vendor>();

            vendors.Add(new Vendor {VendorId = 5, CompanyName = "ABC Corp", Email = "abc@abc.com"});
            vendors.Add(new Vendor {VendorId = 8, CompanyName = "XYZ Inc", Email = "xyz@xyz.com"});
            return vendors;
        }

        public Dictionary<string, Vendor> RetrieveWithKeys()
        {
            var vendors = new Dictionary<string, Vendor>()
            {
                { "ABC Corp", new Vendor {VendorId = 5, CompanyName = "ABC Corp", Email = "abc@abc.com"}},
                {"XYZ Inc", new Vendor {VendorId = 8, CompanyName = "XYZ Inc", Email = "xyz@xyz.com"}}
            };
            

            

            return vendors;
        }
    }
}