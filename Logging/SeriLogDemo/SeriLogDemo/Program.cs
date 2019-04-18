using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using Serilog.Core;

namespace SeriLogDemo
{
    public class Program
    {
        static void Main(string[] args)
        {

            var log = new LoggerConfiguration()
                .WriteTo.ColoredConsole()
                .CreateLogger();

            log.Information("Hello, Serilog!");


            Log.Logger = log;
            Log.Information("The global logger has been configured.");


            Dictionary<string, Category> categories = new Dictionary<String,Category>();

            categories.Add("Barks & Mulches", new Category("Bark & Mulches"));
            categories.Add("Organic Soil Mixes", new Category("Organic Soil Mixes"));
            

        }
    }

    public class Category
    {
        public Category(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }
}
