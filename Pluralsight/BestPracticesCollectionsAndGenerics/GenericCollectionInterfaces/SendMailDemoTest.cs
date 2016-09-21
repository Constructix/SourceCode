using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.Internal;
using PluralsightData;

namespace GenericCollectionInterfaces
{

    [TestFixture]
    public class SendMailDemoTest
    {
        [Test]
        public void Send_Email()
        {
            var result = SendEmail(new List<Vendor>() { new Vendor()}, "this is a test" );
            Assert.IsTrue(result.Contains("Ok"));
            Console.WriteLine(result);
        }

        private List<string> SendEmail(ICollection<Vendor> vendors, string message)
        {
            var confirmations = new List<string>();
            var emailService = new EmailService();
            Console.WriteLine(vendors.Count);

            foreach (Vendor vendor in vendors)
            {
                var subject = string.Format("Important message for: {0}", vendor.CompanyName);
                var confirmation = emailService.SendMessage(subject, message, vendor.Email);

                confirmations.Add(confirmation);
            }

            return confirmations;
        }
    }
}