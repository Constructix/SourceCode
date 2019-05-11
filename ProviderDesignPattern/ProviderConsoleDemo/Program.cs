using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace ProviderConsoleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new string('-', 80));
            Console.WriteLine("Using configuration Builder to retrieve from appsettings.json");
            Console.WriteLine(new string('-', 80));

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            var settings = builder.Build();
            Console.WriteLine( $"Foo: {settings["Foo"]}");
            Console.WriteLine();
            Console.WriteLine(new string('-', 80));

        }
    }
}
