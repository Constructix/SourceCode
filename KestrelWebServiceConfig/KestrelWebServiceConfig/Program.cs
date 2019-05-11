using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace KestrelWebServiceConfig
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            //
            // before that, should register the address so we know where this is located.
            //
            
            WebHost.CreateDefaultBuilder(args)
                .UseUrls("https://localhost:5111")
                .UseStartup<Startup>();
    }
}
