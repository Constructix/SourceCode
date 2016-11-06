using System.Data.Entity;
using System.Linq;
using Moq;
using NUnit.Framework;

namespace MockingDemo
{
    [TestFixture]
    public class CustomerServiceTests
    {

        [Test]
        public void WriteToDatabase()
        {
            CustomerInputData custInputData = new CustomerInputData
            {
                Email = "r_jones@constructix.com.au",
                LastName = "Jones",
                FirstName = "Richard"
            };

            var mockCustomers = new Mock<DbSet<Customer>>();

            var constructixServiceContextMock = new Mock<ConstructixServicesContext>();
            constructixServiceContextMock.Setup(x => x.Customers).Returns(mockCustomers.Object);

            var customerFactory = new CustomerFactory();
            var customerRepository = new CustomerRepository(constructixServiceContextMock.Object);

            var custSvc = new CustomerService(customerFactory, customerRepository);


            custSvc.Create(custInputData);

            mockCustomers.Verify(x=>x.Add(It.IsAny<Customer>()));
        }
       
        


        [Test]
        public void Add_Customer_Via_CustomerService_Add()
        {
            var custInput = CreateCustomerInputData();
            var custFactory = new Mock<IFactory<Customer, ICustomerFactoryInputData>>();
            var custRepository = new Mock<IRepository<Customer>>();

            custFactory.Setup(x => x.Create(It.IsAny<CustomerInputData>()))
                .Returns(CreateCustomer());

            Customer newCustomer = CreateCustomer();

            custRepository.Setup(x => x.Add(newCustomer));
            var custSvc = new CustomerService(custFactory.Object, custRepository.Object);

            custSvc.Create(custInput);

            custRepository.Verify(x=>x.Add(It.IsAny<Customer>()), Times.Once);
        }

        private static Customer CreateCustomer()
        {
            return new Customer()
            {
                FirstName = "Richard",
                LastName = "Jones",
                Email = "r_jones@constructix.com.au"
            };
        }

        private static CustomerInputData CreateCustomerInputData()
        {
            CustomerInputData custInput = new CustomerInputData
            {
                FirstName = "Richard",
                LastName = "Jones",
                Email = "r_jones@constructix.com.au"
            };
            return custInput;
        }
    }
}