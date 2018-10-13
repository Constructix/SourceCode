using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public class CustomerFinancialService
    {
        List<Customer> _customers = new List<Customer>();
        List<CustomerFinancial> _customerFinancials = new List<CustomerFinancial>();

        public CustomerFinancialService()
        {
            _customers = new List<Customer> { new Customer("r_jones@constructix.com.au", true, 1000.00m)};
            _customerFinancials = new List<CustomerFinancial>{ new CustomerFinancial( _customers.First(),  1000.00m, true)};
        }
    }
}