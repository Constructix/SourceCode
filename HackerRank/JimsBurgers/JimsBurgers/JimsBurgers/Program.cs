using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


class Program
    {
        static void Main(string[] args)
        {

            if (args.Length > 0)
            {
                TextReader reader = new StringReader(File.ReadAllText(args[0]));
                Console.SetIn(reader);
            }


            int totalOrders;

            if (int.TryParse(Console.ReadLine(), out totalOrders))
            {
                List<Order> orders = new List<Order>(totalOrders);

                for (int index = 0; index < totalOrders; index++)
                {
                    int ordersPlaced;
                    int processTime;


                    string[] currentInput = Console.ReadLine().Split(' ');

                    bool validOrder = int.TryParse(currentInput[0], out ordersPlaced);
                    bool validProcessTime = int.TryParse(currentInput[1], out processTime);

                    if (validOrder && validProcessTime)
                    {
                        orders.Add(new Order
                        {
                            OrderId = index + 1,
                            OrderPlaced = ordersPlaced,
                            ProcessTime = processTime
                        });
                    }
                }
                var sortedOrders = orders.Select(x => new {totalTIme = x.OrderPlaced + x.ProcessTime, Id = x.OrderId}).OrderBy(y => y.totalTIme);
                StringBuilder result = new StringBuilder();
                foreach (var currentOrder in sortedOrders)
                {
                    result.Append($"{currentOrder.Id} ");
                }
                result = result.Remove(result.Length - 1, 1);
                Console.WriteLine(result.ToString());
            }
        }
    }
    public class Order
    {

        public int OrderId { get; set; }
        public int OrderPlaced { get; set; }
        public int ProcessTime { get; set; }
        
    }