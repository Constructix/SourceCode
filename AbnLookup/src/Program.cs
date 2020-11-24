﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using AbnLookup.Services;
using Microsoft.Extensions.Configuration;

namespace AbnLookup
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var config = SetupConfiguration();

            var recordsToRetrieve = ValidateInputParameters(args, config);

            HttpClient client = HttpClientFactory.Create();

            var abnLookUp = new AbnLookupService(client, config);

            var response = await abnLookUp.NameLookup(new NameLookupRequest
                                                                        {
                                                                            NameOfEntity = args[0],
                                                                            MaxResultsToReturn = recordsToRetrieve

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

        private static int  ValidateInputParameters(string[] args, IConfigurationRoot config)
        {

            int recordsToRetrieve = -1;
            if (args.Length != 2)
            {
                Console.WriteLine("Usage: AbnLookupService [Name] [NumberOfRecords]");
                Console.WriteLine();
                Console.WriteLine("[name] - Name of company, entity to retrieve.");
                Console.WriteLine("[NumberOfRecords] - Number of records to return, eg: 10 - returns up to 10 records.");
                Console.WriteLine();
                Environment.Exit(1);
            }
            else
            {
                if (!int.TryParse(args[1], out int maxRecords))
                {
                    Console.WriteLine("Usage: AbnLookupService [Name] [NumberOfRecords]");
                    Console.WriteLine();
                    Console.WriteLine("NumberOfRecords has been specified incorrectly.");
                    Console.WriteLine(
                        "[NumberOfRecords] - Number of records to return,  eg: AbnLookupService \"test Company\" \"10\"");
                    Console.WriteLine();
                    Environment.Exit(1);
                }
                else
                    recordsToRetrieve = maxRecords;
            }


            if (string.IsNullOrWhiteSpace(config["ApiKey"]))
            {
                Console.WriteLine("API Key has not been set. Exiting program.");
                Environment.Exit(1);
            }
            return recordsToRetrieve;
        }

        private static IConfigurationRoot SetupConfiguration()
        {
            var builder = new ConfigurationBuilder();
#if DEBUG
            builder.AddUserSecrets<Settings>();
#else
            builder.AddJsonFile("appsettings.json");
#endif
            var config = builder.Build();
            return config;
        }
    }
}
