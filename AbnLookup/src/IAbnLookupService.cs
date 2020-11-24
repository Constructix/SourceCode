using System.Threading.Tasks;
using AbnLookup.ResponseEntities;

namespace AbnLookup
{
    public interface IAbnLookupService
    {
        Task<NameLookupResponse> NameLookup(NameLookupRequest request);
    }
}