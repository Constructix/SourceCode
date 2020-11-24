using System;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Moq.Protected;
using Shouldly;
using Xunit;
using Xunit.Abstractions;
using System.Net.Http.Json;
using AbnLookup.ResponseEntities;
using AbnLookup.Services;
using Microsoft.Extensions.Configuration;

namespace AbnLookup.Tests
{
    public class AbnnLookupTest
    {
        private const string PayloadFileName = @"DataFile\ABNResult.payload";

        private ITestOutputHelper _outputHelper;

        public AbnnLookupTest(ITestOutputHelper outputHelper) => _outputHelper = outputHelper;

        public string AbnTestDataFileAsString() =>File.ReadAllText(PayloadFileName);

        [Fact]
        public async Task RetrieveDataAsExpected()
        {
            var builder = new ConfigurationBuilder()
                                .AddJsonFile("appsettings.json");

            var config = builder.Build();

            var handlerMock = SetupHttpMessageHandlerMock();


            var httpClient = new HttpClient(handlerMock.Object);
            IAbnLookupService abnLookupService = new AbnLookupService(httpClient, config);

            var response = await abnLookupService.NameLookup(new NameLookupRequest("Constructix", 10));
                
            response.Message.ShouldBe(string.Empty);
            response.Names.Any().ShouldBe(true);
            response.Names.FirstOrDefault()?.Abn.ShouldBe("16118971476");

            var firstAbn = response.Names.FirstOrDefault();

            firstAbn.ShouldNotBeNull();
            firstAbn?.Abn.ShouldBe("16118971476");
            firstAbn.AbnStatus.ShouldBe("0000000001");
            firstAbn.IsCurrent.ShouldBe(true);
            firstAbn.Name.ShouldBe("CONSTRUCTIX PTY LTD");
            firstAbn.NameType.ShouldBe("Entity Name");
            firstAbn.Postcode.ShouldBe("4306");
            firstAbn.Score.ShouldBe(100);
            firstAbn.State.ShouldBe("QLD");
            _outputHelper.WriteLine($"Names count :{response.Names.Count}");
            _outputHelper.WriteLine($"Message Content :{response.Message}");

            _outputHelper.WriteLine($"Name: {firstAbn.Name}");
            _outputHelper.WriteLine($"Abn: {firstAbn.Abn}");
            _outputHelper.WriteLine($"Status: {firstAbn.AbnStatus}");
            _outputHelper.WriteLine($"NameType: {firstAbn.NameType}");
            _outputHelper.WriteLine($"Postcode: {firstAbn.Postcode}");
            _outputHelper.WriteLine($"Score: {firstAbn.Score}");
            _outputHelper.WriteLine($"State: {firstAbn.State}");


        }

        private Mock<HttpMessageHandler> SetupHttpMessageHandlerMock()
        {

            const string MethodName = "SendAsync";
            var handlerMock = new Mock<HttpMessageHandler>();
            handlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>(MethodName,
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(AbnTestDataFileAsString())
                }).Verifiable();
            return handlerMock;
        }
    }
}
