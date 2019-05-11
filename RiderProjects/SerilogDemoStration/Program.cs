using System;
using Serilog;

namespace SerilogDemoStration
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new string('-',80));
            Console.WriteLine("Serilog Demostration");
            Console.WriteLine(DateTime.Now.ToString());
            Console.WriteLine(new string('-', 80));

            
            // creating a console logger.
            var log = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(@"D:\Files\serilog.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();


            var methodName = System.Reflection.MethodInfo.GetCurrentMethod().Name; 
            log.Information($"Currently executing method: {methodName}");
            
            
            Console.WriteLine("Demonstrating writing an exception");

            try
            {
                int total = 203;
                int val1 = 0;
                int sum = total / val1;
            }
            catch (Exception e)
            {
                
                log.Error($"Exception has been encountered: {e}");
                //Console.WriteLine(e);
                //throw;
            }
        }
        
        
        
    }
}