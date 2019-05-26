using Moq;
using Shouldly;
using Xunit;

namespace MoqDemo_001
{
    public class OrderServiceUnitTests
    {
        [Fact]
        public void CreateOrderServiceMock()
        {
            var orderServiceMock = new Mock<IOrderService>();
            orderServiceMock.Setup(s => s.Submit(It.IsAny<SubmitOrderRequest>())).Returns(new SubmitOrderResponse() { Status = OrderStatus.OK });
            var result = orderServiceMock.Object.Submit(new SubmitOrderRequest());
            string expectedValue = "OK";
            result.Status.Value.ShouldBe(expectedValue);
            orderServiceMock.Verify(v => v.Submit(It.IsAny<SubmitOrderRequest>()));
        }
    }
}