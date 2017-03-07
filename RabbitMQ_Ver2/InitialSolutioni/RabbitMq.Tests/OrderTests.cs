using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQ.Common;
using Xunit;
using Xunit.Abstractions;

namespace RabbitMq.Tests
{
    public class OrderTests
    {
        private ITestOutputHelper console;
        public OrderTests(ITestOutputHelper consoleHelper)
        {
            console = consoleHelper;
        }
        [Fact]
        public void OrderInstanceCreatedNoException()
        {
           var order = new Order();
            Assert.True(order != null);
        }

        [Fact]
        public void SerialiseOrder()
        {

            var createdOn = DateTime.Now;
            var order = new Order() { Customer = new  Customer { Email = "r_jones@constructix.com.au",
                                                                FirstName ="Richard",
                                                                LastName = "Jones"}, 
                                                                Created =  createdOn, LastModified = createdOn
                                    };


            var orderAsJsonString = JsonConvert.SerializeObject(order);

            console.WriteLine(orderAsJsonString);
        }

        [Fact]
        public void CreateOrderFactory()
        {
            var orderFactory = new OrderFactory();
            Assert.NotNull(orderFactory);
        }

        [Fact]
        public void ReturnOrderWithCustomerPassedIntoCreateMethod()
        {
            var orderFactory = new OrderFactory();

            var order =
                orderFactory.Create(new Customer()
                {
                    Email = "r_jones@constructx.com.au",
                    FirstName = "Richard",
                    LastName = "Jones"
                });
            Assert.NotNull(order.Customer);
            Assert.True(order.Customer.FirstName.Equals("Richard", StringComparison.CurrentCultureIgnoreCase));
            Assert.True(order.Customer.LastName.Equals("Jones", StringComparison.CurrentCultureIgnoreCase));
            Assert.True(order.Customer.Email.Equals("r_jones@constructix.com.au", StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
