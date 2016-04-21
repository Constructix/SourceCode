using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCFFaultHandling.ConsoleServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {

            ServiceHost merchantServiceHost = new ServiceHost(typeof(WCFFaultHandling.Services.MerchantManager));

           
                merchantServiceHost.Open();
                Console.WriteLine("WCF FAultHandling Demo Service Host has started.");
                Console.WriteLine("Press [Enter] to close service");
                Console.ReadLine();
                merchantServiceHost.Close();
            
        }
    }
}
