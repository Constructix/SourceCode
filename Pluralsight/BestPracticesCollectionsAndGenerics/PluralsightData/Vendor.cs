using System;
using System.Collections.Generic;

namespace PluralsightData
{
    public class Vendor
    {
        public int VendorId { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }


        public static string SendEmail(ICollection<Vendor> vendors, string message)
        {
            var confirmation = "";
            var emailService = new EmailService();
            Console.WriteLine(vendors.Count);

            foreach (Vendor vendor in vendors)
            {
                var subject = string.Format("Important message for: {0}", vendor.CompanyName);
                confirmation += emailService.SendMessage(subject, message, vendor.Email);
            }

            return confirmation;
        }
    }
}