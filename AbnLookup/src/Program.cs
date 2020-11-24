using System;
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


            if (args.Length != 2)
            {
                Console.WriteLine("Usage: AbnLookup [Name] [NumberOfRecords]");
                Console.WriteLine();
                Console.WriteLine("[name] - Name of company, entity to retrieve.");
                Console.WriteLine("[NumberOfRecords] - Number of records to return, eg: 10 - returns up to 10 records.");
                Console.WriteLine();
                Environment.Exit(1);
            }
            else
            {

                int maxRecords;
                if (!int.TryParse(args[1], out maxRecords))
                {
                    Console.WriteLine("[NumberOfRecords] - Number of records to return, eg: 10 - returns up to 10 records.");
                    Console.WriteLine();
                    Environment.Exit(1);
                }


            }

            if (string.IsNullOrWhiteSpace(config["ApiKey"]))
            {
                Console.WriteLine("API Key has not been set. Exiting program.");
                Environment.Exit(1);
            }

           

            HttpClient client = new HttpClient();

            var abnLookUp = new AbnLookup(client, config);

            var response = await abnLookUp.NameLookup(new AbnNameLookupRequest
            {
                NameOfEntity = args[0],
                MaxResultsToReturn = int.Parse(args[1])
                
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
