﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using GeoLib.Contracts;
using GeoLib.Services;

namespace GeoLib.ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost hostGeoManager = new ServiceHost(typeof(GeoManager));
           
            //string address = "net.tcp://localhost:8009/GeoService";
            //Binding binding = new NetTcpBinding();
            //Type contract = typeof (IGeoService);
            //hostGeoManager.AddServiceEndpoint(contract, binding, address);

            hostGeoManager.Open();
            Console.WriteLine("Services [GeoManager] started. Press [Enter] to exit.");
            Console.ReadLine();
            hostGeoManager.Close();
        }
    }
}
