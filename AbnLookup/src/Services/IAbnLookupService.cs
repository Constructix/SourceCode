using System.Threading.Tasks;
using AbnLookup.ResponseEntities;

namespace AbnLookup.Services
{
    public interface IAbnLookupService
    {
        Task<NameLookupResponse> NameLookup(NameLookupRequest request);
    }
}