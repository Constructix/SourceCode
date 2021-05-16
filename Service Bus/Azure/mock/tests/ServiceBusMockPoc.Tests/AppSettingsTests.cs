using Microsoft.Extensions.Configuration;
using Shouldly;
using Xunit;

namespace ServiceBusMockPoc.Tests
{
    public class AppSettingsTests
    {

        private IConfiguration _configuration;

        public AppSettingsTests()
        {

            _configuration = new ConfigurationBuilder()
                .AddJsonFile("appSettings.json")
                .Build();
        }

        [Theory]
        [InlineData("NoticeToPay:Namespace", "Endpoint=sb://constructix-sb-breakfix-eip-ae.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=wgU5Xd9eY4oLrcmW8CSrW7QKpUB63dAcQ5E7mVFj0d8=")]
        [InlineData("NoticeToPay:Queues:Notifications", "Notifications")]
        public void GetValuesFromAppSettingsJsonFile(string settingName, string  expectedValue)
        {
            _configuration[settingName].ShouldBe(expectedValue);
        }


    }
}