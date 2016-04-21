using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCFServiceBus.ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost constructixManagerHost = new ServiceHost(typeof(ConstructixManager));

            
            constructixManagerHost.Open();

            Console.WriteLine("Service Host is running. Press [Enter] to end service.");
            Console.ReadLine();
            constructixManagerHost.Close();
            
        }
    }
}
