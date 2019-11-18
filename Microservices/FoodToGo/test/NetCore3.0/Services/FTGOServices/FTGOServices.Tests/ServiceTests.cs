
namespace FTGOServices.Tests
{
    using FTGO.Services.Delivery;
    using FTGO.Services.Order;
    using FTGO.Services.Kitchen;
    using FTGO.Services.Restaurant;

    using Shouldly;
    using Xunit;

    /* Purpose is to make sure all services can be instantied and is of the correct type.

    */
    public class ServiceTests
    {
        [Fact]
        public void OrderServiceInstanceCreated_NoExceptionExpected()
        {
            var _orderService = new OrderService();
            _orderService.ShouldNotBeNull();
            _orderService.ShouldBeOfType<OrderService>();

        }

         [Fact]
        public void RestaurantServiceInstanceCreated_NoExceptionExpected()
        {
            var _restaurantService = new RestaurantService();
            _restaurantService.ShouldNotBeNull();
            _restaurantService.ShouldBeOfType<RestaurantService>();
        }
           [Fact]
        public void KitchenServiceInstanceCreated_NoExceptionExpected()
        {
            var _kitchenService = new KitchenService();
            _kitchenService.ShouldNotBeNull();
            _kitchenService.ShouldBeOfType<KitchenService>();
        }

             [Fact]
        public void DeliveryInstanceCreated_NoExceptionExpected()
        {
            var _deliveryService = new DeliveryService();
            _deliveryService.ShouldNotBeNull();
            _deliveryService.ShouldBeOfType<DeliveryService>();
        }

    }
}
