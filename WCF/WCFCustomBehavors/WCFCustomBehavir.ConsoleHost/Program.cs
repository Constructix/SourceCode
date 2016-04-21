using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCFCustomBehaviors.Service;


namespace WCFCustomBehaviors.ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost merchantServiceHost = new ServiceHost(typeof(MerchantManager));


            merchantServiceHost.Open();
            Console.WriteLine("WCF Service Behvavior Demo Service Host has started.");
            Console.WriteLine("Press [Enter] to close service");
            Console.ReadLine();
            merchantServiceHost.Close();

        }
    }
}
