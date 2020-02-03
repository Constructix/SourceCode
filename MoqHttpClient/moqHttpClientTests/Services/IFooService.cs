using System.Collections.Generic;
using System.Threading.Tasks;
using moqHttpClientTests.Models;

namespace moqHttpClientTests.Services
{
    public interface IFooService
    {
        Task<List<Order>> GetOrders();

    }
}