using System.Threading.Tasks;
using AbnLookup.ResponseEntities;

namespace AbnLookup
{
    public interface IAbnLookup
    {
        Task<MatchingNamesResponse> NameLookup(AbnNameLookupRequest request);
    }
}