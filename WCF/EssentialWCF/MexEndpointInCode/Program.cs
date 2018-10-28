using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using Contract;

namespace MexEndpointInCode
{
    class Program
    {
        static void Main(string[] args)
        {

            ServiceHost serviceHost = new ServiceHost(typeof(StockService), new Uri("http://localhost:8000/EssentialWCF"));

            serviceHost.AddServiceEndpoint(typeof(IStockService), new BasicHttpBinding(), "");

            ServiceMetadataBehavior behavior = new ServiceMetadataBehavior();
            behavior.HttpGetEnabled = true;
            serviceHost.Description.Behaviors.Add(behavior);

            serviceHost.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexHttpBinding(),
                "mex");

            serviceHost.Open();


            Console.WriteLine(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
            Console.WriteLine("Service has started.");
            Console.ReadLine();
            serviceHost.Close();


        }
    }
}
