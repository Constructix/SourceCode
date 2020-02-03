using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Models;
using Newtonsoft.Json;

namespace ConstructixFirstClientConsole
{
    class Program
    {
        static class Constants
        {
            public static class Constructix
            {
                public static string FunctionURL =  "https://constructixfirstfunctionapp.azurewebsites.net/api/CreateOrder?code=QDn08LAasU7c1MWp3TKR7x0ngZ4jar1YHLDh97htqmcEro0b5aBtcg==";
            }
        }

        static async Task Main(string[] args)
        {
            Console.WriteLine("Sending data.");

            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine($"Sending {i+1} to Constructix Function.");

                var request = new Order()
                {
                    Id = Guid.NewGuid(), Created = DateTime.Now, Message = "Creating order from Visual studio console."
                };
                HttpClient client = new HttpClient();
                var response = await client.PostAsJsonAsync(Constants.Constructix.FunctionURL, request);

                if (response != null)
                {
                    var orderResponse =
                        JsonConvert.DeserializeObject<OrderResponse>(await response.Content.ReadAsStringAsync());

                    if (orderResponse != null)
                    {
                        Console.WriteLine(orderResponse.Id);
                        Console.WriteLine(orderResponse.Status);
                        Console.WriteLine(orderResponse.DateTime);
                        Console.WriteLine(orderResponse.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Response is null.....");
                }
                Thread.Sleep(1000);
            }
        }
    }
}
