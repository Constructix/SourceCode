using System;
using System.Linq;

namespace RepositoryUnitOfWorkDemo
{
    public class CustomerHelper
    {
        public static void PrintCustomersThatHaveOrdered(EfUnitOfWork eof)
        {
            Console.WriteLine("Orders are as follows:");
            Console.WriteLine("{0,30}{1,30}", "First Name", "Last Name");
            foreach (Order order in eof.Orders.ToList())
            {
                Console.WriteLine($"{order.Customer.FirstName,30} {order.Customer.LastName,30}");
            }
        }
    }
}