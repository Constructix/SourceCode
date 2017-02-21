using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MicroServices.DTO;
using MicroServicesDemo;
using Xunit;

namespace MicroServices.Tests
{
    // used to identify during the history if the payload encountered any issue.


    public class OrderServiceTest
    {
        [Fact]
        public void OrderServiceCreated()
        {
            var orderService = new OrderService();

            Assert.NotNull(orderService);
        }
        [Fact]
        public void StartOrderServiceStatusShouldBeStarted()
        {
            var orderSvc = new OrderService();
            orderSvc.Start();
            Assert.True(ServiceStatus.Started == orderSvc.Status);
        }
        [Fact]
        public void stoppedOrderServiceStatusShouldBeStopped()
        {
            var orderSvc = new OrderService();
            orderSvc.Stop();
            Assert.True(ServiceStatus.Stopped == orderSvc.Status);
        }

        [Fact]
        public void StartServiceProcessThenStopStatusShouldBeStopped()
        {
            var orderSvc = new OrderService();
            orderSvc.Start();
            var order  = new Order();
            orderSvc.Process(order);
            orderSvc.Stop();
            Assert.True(ServiceStatus.Stopped == orderSvc.Status);
        }
    }
}
