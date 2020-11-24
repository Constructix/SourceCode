using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace AbnLookup
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json");

            var config = builder.Build();

            if (string.IsNullOrWhiteSpace(config["ApiKey"]))
            {
                Console.WriteLine("API Key has not been set. Exiting program.");
                Environment.Exit(1);
            }

           

            HttpClient client = new HttpClient();

            var abnLookUp = new AbnLookup(client, config);

            var response = await abnLookUp.NameLookup(new AbnNameLookupRequest
            {
                NameOfEntity = "Constructix",
                MaxResultsToReturn = 10,
                ResponseName = "Response"
            });

            if (string.IsNullOrWhiteSpace(response.Message))
            {
                Console.WriteLine("Retrieved Data from ABN Lookup.");

                foreach (var currentAbnEntity in response.Names)
                {
                    Console.WriteLine(currentAbnEntity.Name);
                }
            }
            else
            {
                Console.WriteLine(response.Message);
            }
            Environment.Exit(0);
        }
    }
}
