using System;
using System.
namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            DateTime currentDate = DateTime.Now;

            Console.WriteLine($"Current Date: {currentDate.ToString("dd/MM/yyyy")}");
        }
    }

    public class Order
    {
        public Guid Id {get;set;}

        public Order(Parameters)
        {
            Id = Guid.NewGuid();
        }
    }

    public class OrderService
    {
        public void Submit(Order newOrder)
        {

        }
    }
}
