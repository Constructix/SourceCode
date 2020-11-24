using System.Threading.Tasks;
using AbnLookup.ResponseEntities;

namespace AbnLookup
{
    public interface IAbnLookup
    {
        Task<NameLookupResponse> NameLookup(NameLookupRequest request);
    }
}