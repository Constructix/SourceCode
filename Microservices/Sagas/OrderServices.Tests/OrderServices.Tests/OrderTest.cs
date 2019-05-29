using System;
using OrderServices.Domain;
using Xunit;
using Shouldly;

namespace OrderServices.Tests
{
    public class OrderTest
    {
        [Fact]
        public void IdFieldIsGuid()
        {
            var order = new Order();
            order.Id.ShouldBeOfType<Guid>();
        }
    }
}
