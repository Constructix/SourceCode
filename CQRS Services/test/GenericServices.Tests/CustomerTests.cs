using GenericServices.Services.Models;
using Xunit;

namespace GenericServices.Tests
{
    public class CustomerTests
    {
        [Fact]
        public void CustomerInstanceCreated()
        {
            var customer = new Customer(1, "Richard", "Jones");
            Assert.NotNull(customer);
        }

    }
}
