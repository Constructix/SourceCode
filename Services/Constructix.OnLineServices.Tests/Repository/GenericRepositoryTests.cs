using Constructix.OnlineServices.Data;
using Constructix.OnLineServices.Domain;
using Xunit;

namespace Constructix.OnLineServices.Tests.Repository
{
    public class GenericRepositoryTests
    {
        [Fact]
        public void CreateGenericRepository()
        {
            var repo = new GenericRepository<Order>();
        }
    }
}