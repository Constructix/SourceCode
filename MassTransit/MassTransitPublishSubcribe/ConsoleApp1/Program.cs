using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassTransit.Data;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (MassTransit.Data.MassTransitContext db = new MassTransitContext())
            {
                AddressDetails ad = new AddressDetails {Id = Guid.NewGuid(), CustomerId = "12345"};

                db.AddressDetails.Add(ad);
                db.SaveChanges();

                foreach (AddressDetails addressDetailse in db.AddressDetails)
                {
                    Console.WriteLine(addressDetailse.Id);
                }
            }
        }
    }
}
