using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassTransit;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            FirstDemo.Run();
        }
    }
    public class YourMessage { public string Text { get; set; } }
    public static  class FirstDemo
    {
        public static void Run()
        {
            var bus = Bus.Factory.CreateUsingRabbitMq(sbc =>
            {
                var host = sbc.Host(new Uri("rabbitmq://localhost"), h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                sbc.ReceiveEndpoint(host, "test_queue_MassTransit", ep =>
                {
                    ep.Handler<YourMessage>(context =>
                    {
                        return Console.Out.WriteLineAsync($"Received: {context.Message.Text}");
                    });
                });
            });

            bus.Start();

            bus.Publish(new YourMessage { Text = "Hi, welcome to Mass Transit." });

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

            bus.Stop();
        }

    }



}
