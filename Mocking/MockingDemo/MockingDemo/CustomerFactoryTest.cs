using NUnit.Framework;

namespace MockingDemo
{
    [TestFixture]
    public class CustomerFactoryTest
    {
        [Test]
        public void CustomerInstance_Created_From_Factory_Create()
        {
            var customerFactory = new CustomerFactory();
            var customer = customerFactory.Create(new CustomerInputData() { FirstName= "Richard",
                LastName = "Jones",
                Email = "r_jones@constructix.com.au"});

            var expectedFullName = "Jones,Richard";
            Assert.IsTrue(expectedFullName.Equals(customer.FullName()));
        }

        [Test]
        public void Customer_Factory_Validate_Customer_Input()
        {
            var customerFactory = new CustomerFactory();

            var customer =
                customerFactory.Create(new CustomerInputData()
                {
                    FirstName = "richard",
                    LastName = "Jones",
                    Email = "r_jones@constructix.com.au"
                });
            Assert.IsNotNull(customer);

        }

        [Test]
        public void Customer_Factory_Validate_Customer_Input_Ruturns_Null()
        {
            var customerFactory = new CustomerFactory();

            var customer =
                customerFactory.Create(new CustomerInputData()
                {
                    FirstName = "richard",
                    LastName = "Jones",
                    Email = "r_jones$constructix.com.au"
                });
            Assert.IsNull(customer);

        }
    }
}