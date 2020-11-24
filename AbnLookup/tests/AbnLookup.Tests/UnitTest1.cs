using System;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Moq.Protected;
using Xunit;

namespace AbnLookup.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            var responseMessage = new HttpResponseMessage { StatusCode = HttpStatusCode.OK, Content = new StringContent("test")};
            
        }
    }
}
