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
    }

}