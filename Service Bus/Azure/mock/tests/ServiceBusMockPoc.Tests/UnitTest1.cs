using System;
using System.ServiceModel.Security;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Moq;
using Shouldly;
using IConfiguration = Castle.Core.Configuration.IConfiguration;


namespace ServiceBusMockPoc.Tests
{



     internal class DependencyInjector
    {

        public static IServiceProvider GetProvider()
        {
            var  _configuration = new ConfigurationBuilder()
                .AddJsonFile("appSettings.json")
                .Build();


            var svcCollection = new ServiceCollection();
            var mockServiceBusClient = new Mock<ServiceBusClient>();

            svcCollection.AddScoped<INotificationService, NotificationService>();
            svcCollection.AddAzureClients(x =>
            {
                x.AddServiceBusClient("Endpoint=sb://constructix-sb-breakfix-eip-ae.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=wgU5Xd9eY4oLrcmW8CSrW7QKpUB63dAcQ5E7mVFj0d8=");
            });
            var provider = svcCollection.BuildServiceProvider();
            return provider;
        }
    }
    public class UnitTest1
    {
        [Fact]
        public async Task Test1()
        {
            // create a mock for Service
            var ServiceBusClientMock = new Mock<ServiceBusClient>();
            var mockSender = new Mock<ServiceBusSender>();
            ServiceBusClientMock.Setup(x => x.CreateSender("Notifications")).Returns(mockSender.Object).Verifiable();
            ServiceBusMessage msg = new ServiceBusMessage("Hello");
            var sender = ServiceBusClientMock.Object.CreateSender("Notifications");
             await sender.SendMessageAsync(msg);
             ServiceBusClientMock.Verify();


        }


        [Fact]
        public async Task TestNotificationService()
        {
            var ServiceBusClientMock = new Mock<ServiceBusClient>();
            var mockSender = new Mock<ServiceBusSender>();
            ServiceBusClientMock.Setup(x => x.CreateSender("Notifications")).Returns(mockSender.Object).Verifiable();
            var svc = new NotificationService(ServiceBusClientMock.Object);
            await svc.SendMessage("test");
            ServiceBusClientMock.Verify();

           
        }
    }
    
    public interface INotificationService
    {
        public Task SendMessage(string messageBody);
    }

  

    public class NotificationService : INotificationService
    {
        public ServiceBusClient _client;
        
        public NotificationService(ServiceBusClient client)
        {
            _client = client;
            
        }

        public async Task SendMessage(string messageBody)
        {
            var sender = _client.CreateSender("Notifications");
            await sender.SendMessageAsync(new ServiceBusMessage(messageBody));



        }
    }
}
