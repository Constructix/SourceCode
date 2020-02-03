namespace FTGO.Services.Order
{
    using FTGO.Services;
    using Domain;
    public class OrderService : IFTOService
    {
        public OrderService()
        {
        }


        public Order NewOrder()
        {
            return new Order();
        }

        /// <summary>
        /// Creates Order and returns to client.
        /// </summary>
        /// <returns></returns>
        public Order CreateOrder()
        {
            return OrderFactory.Create();
        }
    }
}