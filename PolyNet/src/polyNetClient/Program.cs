using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Sockets;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using Polly;
using PolyNetDomain;

namespace polyNetClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Demostrating Poly, NET resilience and transisent fault-handling library.");

            ConsoleColor currentColor = Console.ForegroundColor;

            var polyNetService = @"https://localhost:44308/WeatherForecast";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Connecting to: {polyNetService}");
            Console.WriteLine();
            Console.ForegroundColor = currentColor;
            Console.WriteLine("Retrieving all weather forecasts...");
            var retryLimit = 3;
            var retryCount = 0;
            var pauseBetweenFailures = TimeSpan.FromSeconds(2);
            
            var httpClient = new HttpClient();
            var weatherForcasts = await httpClient.GetFromJsonAsync<WeatherForecast>(polyNetService);




        }

        private static void DividByZeroPolicyDemo()
        {
            //using divide by Zero policy..
            try
            {
                var policy = Policy
                    .Handle<DivideByZeroException>()
                    .Retry(3, onRetry: (exception, retryCount) => { Console.WriteLine("In Retry Section....."); })
                    .Execute(() => TestAddingNumbers());

                Console.WriteLine(policy);
            }
            catch (DivideByZeroException divideByZeroEx)
            {
                Console.WriteLine(divideByZeroEx.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


        private static bool TestAddingNumbers()
        {
            int value = 0;
            return (10 / value) == 4;

        }





        private static void DisplayDetails(string response)
        {
            var content = Newtonsoft.Json.JsonConvert.DeserializeObject<List<WeatherForecast>>(response);

            if (content != null)
            {
                Console.WriteLine($"Number of Records :{content.Count}");

                foreach (var weatherForecast in content)
                {
                    Console.WriteLine($"Date:    {weatherForecast.Date}");
                    Console.WriteLine($"Temp:    {weatherForecast.TemperatureC}");
                    Console.WriteLine($"Summary: {weatherForecast.Summary}");
                    Console.WriteLine();
                }

                Console.WriteLine();
            }
        }
    }
}
