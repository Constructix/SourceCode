using System;
using Serilog;
namespace Serilog
{
    
    class Program
    {
        static void Main(string[] args)
        {
            var log = LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
            
            Console.WriteLine("Hello World!");
        }
    }
}
