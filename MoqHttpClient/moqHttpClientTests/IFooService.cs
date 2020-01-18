using System.Collections.Generic;
using System.Threading.Tasks;

namespace moqHttpClientTests
{
    public interface IFooService
    {
        Task<List<Order>> GetOrders();

    }
}