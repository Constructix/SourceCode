using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Security.Authentication.ExtendedProtection;
using Xunit;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
namespace Orders.WebAPI.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var args = new List<string>();
             
             CreateWebHostBuilder(args.ToArray()).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args).UseStartup<Startup>();
        }
    }
    public class Startup
    {

    }
    public class OrderService
    {
    }
}
