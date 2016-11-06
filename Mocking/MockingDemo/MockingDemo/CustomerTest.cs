using Castle.Core.Smtp;
using NUnit.Framework;

namespace MockingDemo
{
    public interface IFactoryInputData
    {
  
    }


    [TestFixture]
    public class CustomerTest
    {
        [Test]
        public void When_Customer_Instance_Is_Created_No_Exception_Returned()
        {
            var customer = new Customer();
            Assert.IsNotNull(customer);

        }

        [Test]
        public void When_FirstName_IsAssigned_Should_Return_John()
        {
            var customer = new Customer() {FirstName = "John"};
            Assert.IsTrue(customer.FirstName.Equals("John"));
        }

        [Test]
        public void When_LastName_IsAssigned_Should_Return_Williams()
        {
            var customer = new Customer() { LastName = "Williams" };
            Assert.IsTrue(customer.LastName.Equals("Williams"));
        }

        [Test]
        public void When_EmailName_IsAssigned_Should_Return_Williams()
        {
            var customer = new Customer() { Email = "Williams" };
            Assert.IsTrue(customer.Email.Equals("Williams"));
        }

        [Test]
        public void When_FullName_Is_Called_Return_LastName_Comma_FirstName()
        {
            var customer = new Customer() { FirstName = "Richard", LastName = "Jones"};
            var expected = "Jones,Richard";
            Assert.IsTrue(expected.Equals(customer.FullName()));
        }
    }
}
