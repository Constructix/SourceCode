using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;

namespace SerialogDemo
{
    class Program
    {
        static void Main(string[] args)
        {


            var log = new LoggerConfiguration()
                .WriteTo.LiterateConsole()
                .WriteTo.RollingFile(@"D:\Files\SerialLogDemo.txt")
                .CreateLogger();


            log.Information("This is Program.Main Method getting called.");

            log.Error(new FileNotFoundException("File can not be found"), string.Empty);
        }
    }
}
