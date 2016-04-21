using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServiceBus.Proxies;

namespace WCFServiceBus.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ConstructixManagerClient client  = new ConstructixManagerClient();

            int sum = client.Add(12, 34);

            Console.WriteLine(string.Format("Sum: {0}", sum));

            client.Close();


            Console.ReadLine();

        }
    }
}
