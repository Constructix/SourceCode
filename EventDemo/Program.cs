namespace EventDemo
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            List<Order> orders = new List<Order>();
            //////////////////////////////////////////////////////////
            // setup order Manager;
            OrderManager orderManager = new OrderManager(orders);
            orderManager.OrderEvent += OrderManager_OrderEvent;
            orderManager.OrderDeletedEvent += OrderManager_OrderDeletedEvent;

            orderManager.CreateOrder();
            orderManager.CreateOrder();
            orderManager.CreateOrder();
            orderManager.CreateOrder();
            orderManager.CreateOrder();

            orderManager.DeleteOrder(orders.First());
            Console.WriteLine($"Number of Orders Created: {orderManager.TotalOrders}");
        }
        private static void OrderManager_OrderDeletedEvent(object sender, OrderEventArgs e)
        {
            Console.WriteLine();
            Console.WriteLine($"{e.Message} OrderId: { e.Order.Id} Status: {e.Order.Status} DeletedOn: { e.Order.Deleted?.ToString("o")}");
        }
        private static void OrderManager_OrderEvent(object sender, OrderEventArgs e)
        {
           Console.WriteLine($"{e.Message} OrderId: { e.Order.Id} Status: {e.Order.Status}");
        }
    }
}
