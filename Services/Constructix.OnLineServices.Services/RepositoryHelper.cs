using System;
using Constructix.OnlineServices.Data;
using Constructix.OnLineServices.Domain;

namespace Constructix.OnLineServices.Services
{
    internal class RepositoryHelper
    {
        public static void CreateTestOrder(IRepository<Order> ordersRepository)
        {
            Guid testGuid;
            const string testGuidAsString = "D26F5E9B-46DD-4F0A-A3C7-35895A3B5A8A";
            Guid.TryParse(testGuidAsString, out testGuid);
            ordersRepository.Add(new Order {Id = testGuid, CreateDateTime = DateTime.Now, LastUpdated = DateTime.Now});
        }
    }
}