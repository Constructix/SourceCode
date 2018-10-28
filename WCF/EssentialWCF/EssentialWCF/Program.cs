using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Contract;

namespace EssentialWCF
{
   
    class Program
    {
        static void Main(string[] args)
        {

            ServiceHost svcHost = new ServiceHost(typeof(StockService));

            

            svcHost.Open();
            Console.WriteLine(System.Reflection.Assembly.GetExecutingAssembly().GetName());
            Console.WriteLine("Stock Service has successfully started.");
            Console.WriteLine($"Press <ENTER> to end stock service....");
            Console.ReadLine();
            svcHost.Close();
        }
    }
}
