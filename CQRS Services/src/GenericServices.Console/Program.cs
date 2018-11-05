using System;
using GenericServices.Data;
using GenericServices.Services.Models;

namespace GenericServices.Console
{
    class Program
    {
        static void Main(string[] args)
        {
           System.Console.WriteLine("Testing writing to services......");


            CustomerReadService customerReadService = new CustomerReadService(null);

            var customer = customerReadService.Get(1);
            System.Console.WriteLine(customer.ToString());


            CustomerWriteService customerWriteService = new CustomerWriteService();
            customerWriteService.Write(new Customer("Teresa","Jones"));

            System.Console.WriteLine("reading back.");

            foreach (CustomerDTO currentCustomer in customerReadService.GetAll())
            {
                System.Console.WriteLine($"{currentCustomer.FirstName} {currentCustomer.LastName}");
            }


        }
    }
}
