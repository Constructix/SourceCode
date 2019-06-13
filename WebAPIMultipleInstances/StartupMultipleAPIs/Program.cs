using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StartupMultipleAPIs
{
    class Program
    {
        static void Main(string[] args)
        {
            //dotnet publish -c Release -r win-x64 --self-contained false

            List<string> urls = new List<string> {"https://localhost:3333/", "https://localhost:3334/"};
            ;
            Console.WriteLine("About to start up Multiple Endpoints....");


            Task.Run(() =>
            {
                foreach (var url in urls)
                {
                    ProcessStartInfo psi = new ProcessStartInfo(
                        @"D:\Development\GitHub\WebAPIDemo\SetEndpointAddressDemo\bin\Release\netcoreapp2.2\win-x64\SetEndpointAddressDemo.exe",
                        $"--n {url}");
                    System.Diagnostics.Process.Start(psi);

                }
            });

            //ProcessStartInfo psi = new ProcessStartInfo(@"D:\Development\GitHub\WebAPIDemo\SetEndpointAddressDemo\bin\Release\netcoreapp2.2\win-x64\SetEndpointAddressDemo.exe", "--n https://localhost:3333/");

            //System.Diagnostics.Process.Start(psi);

            Console.WriteLine("Hit Enter to end....");
            Console.ReadLine();
        }
    }
}
