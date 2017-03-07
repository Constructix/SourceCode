using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Common;
using Xunit;

namespace RabbitMq.Tests
{
    public class OrderTests
    {
        [Fact]
        public void OrderInstanceCreatedNoException()
        {
           var order = new Order();
            Assert.True(order != null);
        }
    }
}
