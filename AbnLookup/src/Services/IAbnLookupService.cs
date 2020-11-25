using System.Threading.Tasks;
using AbnLookup.JsonResponseEntities;
using AbnLookup.ResponseEntities;

namespace AbnLookup.Services
{
    public interface IAbnLookupService
    {
        Task<MatchingNameLookupResponse> MatchingNameLookup(MatchingNameLookupRequest request);
        Task<ABNEntity> AbnDetails(ABNLookupRequest request);
    }
}