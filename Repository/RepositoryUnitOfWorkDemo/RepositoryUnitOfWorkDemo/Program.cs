using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryUnitOfWorkDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            EfUnitOfWork eof = new EfUnitOfWork();
            const int maxCustomers = 30;
            for (int i = 0; i < maxCustomers; i++)
            {
                Customer c = eof.Customers.Add(new Customer {FirstName = NameGenerator.NextName, LastName = NameGenerator.LastName});
                eof.SaveChanges();

                eof.Orders.Add(new Order() {Created = DateTime.Now, CustomerId =  c.Id});
                eof.SaveChanges();
            }

            CustomerHelper.PrintCustomersThatHaveOrdered(eof);

            eof.Dispose();
        }
    }
}
