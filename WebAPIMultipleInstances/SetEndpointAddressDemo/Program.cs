using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace SetEndpointAddressDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
           // CreateWebHostBuilder(args).Build().Run();
           var urls = new List<string> {args[1]};


           var configuration = new ConfigurationBuilder()
               .AddCommandLine(args)
               .Build();

           var host = new WebHostBuilder()
               .UseKestrel()
               .UseContentRoot(Directory.GetCurrentDirectory())
               .UseIISIntegration()
               .UseConfiguration(configuration)
               .UseStartup<Startup>()
               .UseUrls( urls.ToArray())
               .Build();

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
