using System;
using System.Linq;

namespace XUnit
{
    public interface IOrderRepository
    {
        IQueryable<Order> GetOrders(Func<bool> , Order order);
    }
}