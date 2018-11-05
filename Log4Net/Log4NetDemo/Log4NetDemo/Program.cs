using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Appender;
using log4net.Config;

namespace Log4NetDemo
{
    class Program
    {
        private static ILog logger   = LogManager.GetLogger(typeof(Program));
        static void Main(string[] args)
        {
           
            BasicConfigurator.Configure();
           
            logger.Info("Hello world");

        }
    }
}
