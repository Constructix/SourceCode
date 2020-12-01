using System.Collections.Generic;
using System.Threading.Tasks;
using AbnLookup.DataModels.JsonResponseEntities;
using Microsoft.AspNetCore.Mvc;

namespace AbnLookup.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NameLookupController : ControllerBase
    {
        [HttpPost]
        public MatchingNameLookupResponse GetMatchingNames([FromBody] MatchingNameLookupRequest matchingNameRequest)
        {
            return BuildResponse(matchingNameRequest);
        }


        private MatchingNameLookupResponse BuildResponse(MatchingNameLookupRequest request)
        {
            var response = new MatchingNameLookupResponse
                {Message = "", Names = new List<MachingNameEntity> {new MachingNameEntity {Abn = "1234"}}};

            return response;
        }
    }
}