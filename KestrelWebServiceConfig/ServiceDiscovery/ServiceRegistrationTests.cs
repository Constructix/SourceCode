using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Shouldly;
using Xunit;

namespace ServiceDiscoveryTests
{


    public class ServiceRegistrationTests
    {
        private Service svc;
        public ServiceRegistrationTests()
        {
            svc = new Service {Address = "https://localhost:8001", Name = "Service1"};
        }


        [Fact]
        public void  RegisterServiceShouldReturnTrueAsExpected()
        {
            var actualResult = ServiceRegistration.Register(svc);
            actualResult.ShouldBe(true);
        }

        [Fact]
        public void ClearRegisterServicesShouldBeClear()
        {
            ServiceRegistration.Clear();
            ServiceRegistration.Services.ShouldBeEmpty();
        }


        [Fact]
        public void UnRegisterServiceShouldReturnTrueAsExpected()
        {
            ServiceRegistration.Clear();
            
            var actualResult = ServiceRegistration.Register(svc);
            actualResult.ShouldBe(true);
            actualResult = ServiceRegistration.UnRegister(svc);
            actualResult.ShouldBe(true);
        }
    }
    public static class ServiceRegistration
    {
        static readonly ConcurrentDictionary<string, Service> ServicesRegistered = new ConcurrentDictionary<string, Service>();
        public static bool Register(Service service) => ServicesRegistered.TryAdd(service.Address, service);
        public static bool UnRegister(Service service) => ServicesRegistered.TryRemove(service.Address, out _);

        public static void Clear()
        {
            ServicesRegistered.Clear();
        }

        public static List<Service> Services => ServicesRegistered.Values.ToList();


    }


    public interface IService
    {
        string Address { get; set; }
        string Name { get; set; }
    }


    public class Service : IService
    {
        public string Address { get; set; }
        public string Name { get; set; }

        public Service()
        {
            
        }
        public Service(string address, string name)
        {
            Address = address;
            Name = name;
        }
    }
}
