using System.Collections.Generic;
using OrderServices.Domain;

namespace OrderServices
{
    public interface IOrderService
    {
        bool CancelOrder(Order newOrder);
        List<Order> GetAll();
        Order CreateOrder();
    }
}