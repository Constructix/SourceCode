using Moq;
using NUnit.Framework;

namespace MockingDemo
{
    [TestFixture]
    public class CustomerRepositoryTests
    {
        [Test]
        public void CustomerRepository_Instance_Created()
        {
            var customerRepository = new CustomerRepository();

            Assert.IsNotNull(customerRepository);
        }

       
        [Test]
        public void Customer_Repository_Mock()
        {
            var customerRepositoryMock = new Mock<IRepository<Customer>>();

            customerRepositoryMock.Setup(x => x.Add(It.IsAny<Customer>()));
            customerRepositoryMock.Object.Add(new Customer());
            customerRepositoryMock.Verify(x=>x.Add(It.IsAny<Customer>()));
        }
    }
}