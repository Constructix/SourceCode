using System;
using System.Text;
namespace ConsoleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Order is a data structure
            
            Order newOrder = new Order();
            OrderWriter writer = new OrderWriter(newOrder);
            Console.Clear();
            System.Console.WriteLine(writer.ToString());
        }
    }

    public class Order
    {
        public DateTime Created {get;private set;}
        public Order()
        {
            Created = DateTime.Now;
        }

        public Order(DateTime created)
        {
            this.Created = created;
        }
    }


    public class OrderWriter
    {
        private Order order;

        public OrderWriter(Order order)
        {
            this.order = order;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append($"{order.Created}");
            return builder.ToString();

        }
    }
}
