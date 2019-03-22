using System;
using System.Collections.Generic;
using Constructix.Services.DomainModel;


namespace Constructix.Service.OnlineServices
{
    public class CustomerService
    {
        private List<Customer> Customers = new List<Customer>();


        public CustomerService()
        {
            Customers = new List<Customer> { new Customer(Guid.NewGuid()),
                                            new Customer(Guid.NewGuid()),
                                            new Customer(Guid.NewGuid()),
                                            new Customer(Guid.NewGuid())};
        }

        public List<Customer> GetCustomers()
        {
            return Customers;
        }
        public void Add(Customer newCustomer)
        {
            this.Customers.Add(newCustomer);
        }
    }

    public class CustomerRepository
    {

    }


    public class FirstNameGenerator
    {


        private List<string> names = new List<string> { "Richard", "William", "Tony", "Stuart" };



    }
}