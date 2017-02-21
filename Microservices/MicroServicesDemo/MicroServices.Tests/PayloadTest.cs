using System;
using MicroServices.DTO;
using Xunit;

namespace MicroServices.Tests
{
    public class PayloadTest
    {
        [Fact]
        public void PayloadInstanceWithOrderNotNull()
        {
            DateTime payloadCreated = DateTime.Now;
            var order = new Order();
            var payload = new Payload<Order> { instance = order, Status = PayloadStatus.Waiting, Created = payloadCreated };
            Assert.NotNull(payload);
        }
    }
}