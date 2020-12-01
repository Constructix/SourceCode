using System.Threading.Tasks;
using AbnLookup.DataModels.JsonResponseEntities;


namespace AbnLookup.Services
{
    public interface IAbnLookupService
    {
        Task<MatchingNameLookupResponse> MatchingNameLookup(MatchingNameLookupRequest request);
        Task<ABNEntity> AbnDetails(ABNLookupRequest request);
    }
}