using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Contract;

namespace WCFCodeAndConfig
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost svcHost = new ServiceHost(typeof(StockService));

            svcHost.Open();
            Console.WriteLine("Stock Service has successfully started.");
            Console.WriteLine($"Press <ENTER> to end stock service....");
            Console.ReadLine();
            svcHost.Close();

        }
    }
}
