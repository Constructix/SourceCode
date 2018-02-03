using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;   

namespace DNSName
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("DNS Lookup");

            string hostName = Dns.GetHostName();
            Console.WriteLine($"Host Name: { hostName}");
            IPHostEntry hostEntry = Dns.GetHostEntry(hostName);

            foreach (IPAddress currentIpAddress in hostEntry.AddressList)
            {
                Console.WriteLine($"\t IP Address: { currentIpAddress.ToString()}");
            }
        }
    }
}
