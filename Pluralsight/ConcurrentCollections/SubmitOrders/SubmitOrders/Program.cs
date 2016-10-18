using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SubmitOrders
{
    class Program
    {
        static void Main(string[] args)
        {
            //SharePriceDetails();
            var orders  = new ConcurrentQueue<string>();
            //PlaceOrders(orders, "Mark");
            //PlaceOrders(orders, "Ramdevi");
            Task task1 = Task.Run(() => PlaceOrders(orders, "Mark"));
            Task task2 = Task.Run(() => PlaceOrders(orders, "Ramdevi"));
            Task.WaitAll(task1, task2);


            Parallel.ForEach(orders, ProcessOrder);
         

            foreach (string order in orders)
            {
                Console.WriteLine($"Order: {order}");
            }
        }

        static void ProcessOrder(string order)
        {
            
        }

        private static void SharePriceDetails()
        {
            var comsecDateTime = "161013";

            var sharePrice = new Share {Code = "GXY", ShareDateTime = comsecDateTime.ToDateTimeFromCsvDateTime()};

            Console.WriteLine(sharePrice.ShareDateTime.ToString());

            DateTime expectedDateTime = DateTime.Parse("13/10/2016");

            Console.WriteLine(Helpers.DatesAreSame(sharePrice.ShareDateTime, expectedDateTime));
        }

        

        static void PlaceOrders(ConcurrentQueue<string> orders, string customerName)
        {
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(1);
                string orderName = $"{customerName} wants t-shirt {i + 1}";
                orders.Enqueue(orderName);
            }
        }
    }
}
