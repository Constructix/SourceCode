using System.Collections.Generic;
using GenericServices.Services.Models;
using Xunit;

namespace GenericServices.Tests
{

    public class CustomerWriteServiceTest
    {
        [Fact]
        public void WriteCustomerServiceTest()
        {

            // TODO convert unit tests to use InMemory database rather than SQL server.
            Customer newCustomer = new Customer( "Richard", "Jones");
            CustomerWriteService custWriteService =new CustomerWriteService();
            custWriteService.Write(newCustomer);
        }
    }

    public class CustomerServiceTestsUsingGenericServices
    {
        [Fact]
        public void CustomerServiceCreatedUsingGenericService()
        {
            int testId = 1;
            GenericService<Customer, int> customerSvc = new GenericService<Customer, int>(CreateCustomers());

            var expectedCustomer=  new Customer(1, "Richard", "Jones");
            Customer customer = customerSvc.Get(testId) as Customer;

            Assert.Equal(expectedCustomer.Id, customer.Id);
            Assert.Equal(expectedCustomer.FirstName, customer.FirstName);
            Assert.Equal(expectedCustomer.LastName, customer.LastName);
        }

        private List<IEntity<int>> CreateCustomers()
        {
            return new List<IEntity<int>> { new Customer(1, "Richard", "Jones")};
        }
    }
}