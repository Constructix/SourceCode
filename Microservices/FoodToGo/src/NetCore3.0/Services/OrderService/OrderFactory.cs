using System;

namespace FTGO.Services.Order
{
    /// <summary>
    /// Creates an Order.
    /// </summary>
    public class OrderFactory
    {
        public static Domain.Order Create()
        {

            return new Domain.Order {Created = DateTime.Now};
        }
    }
}