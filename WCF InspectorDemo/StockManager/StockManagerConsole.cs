using System.ServiceModel;
using System;
using System.Linq;
using System.ServiceModel.Description;
using StockManagerInspector;

namespace StockManager
{

    public static class StockManagerConsole
    {
        public static void Main()
        {
            var address = "http://localhost:8734/StockManager/StockService";

            ServiceHost  svchost = new ServiceHost(typeof(StockService));
            svchost.Opened += Svchost_Opened;
            svchost.Open();
            System.Console.WriteLine("Service has Started.....");
            Console.WriteLine(svchost.BaseAddresses.First().ToString());
            while (true)
            {
                
            }
        }

        private static void Svchost_Opened(object sender, EventArgs e)
        {
            Console.WriteLine("Service has been opened.");
        }
    }
}