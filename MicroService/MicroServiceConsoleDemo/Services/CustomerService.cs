using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class CustomerService
    {
        List<Customer> _customers = new List<Customer>();

        public CustomerService()
        {
            _customers = new List<Customer> { new Customer("r_jones@constructix.com.au")};
        }

        public Customer GetCustomer(string email)
        {
            return _customers.Find(x => x.Email.Equals(email, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}