using System;
using Shouldly;
using Xunit;

namespace Order.Tests
{
    public class OrderTests
    {
        [Fact]
        public void InstanceCreated_NoExceptionExpected()
        {
            var order = new FTGO.Domain.Order();

            order.ShouldNotBeNull();
        }
        [Fact]
        public void DateTimeIsNotNull()
        {
            var order = new FTGO.Domain.Order {Created = DateTime.Now};


            order.ShouldNotBeNull();
        }
    }


    
}
