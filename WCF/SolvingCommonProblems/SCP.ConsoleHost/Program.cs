using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SCP.ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {

            ServiceHost host = new ServiceHost(typeof(SCP.Contracts.ILongRunningService));

            host.Open();

            Console.WriteLine("Service has Started. Press [Enter] to end.");
            Console.ReadLine();

            host.Close();
        }
    }
}
