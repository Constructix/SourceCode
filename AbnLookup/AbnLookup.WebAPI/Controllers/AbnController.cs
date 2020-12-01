using System.Collections.Generic;
using AbnLookup.DataModels.JsonResponseEntities;
using Microsoft.AspNetCore.Mvc;

namespace AbnLookup.WebAPI.Controllers
{
    [ApiController]
    public class AbnController : ControllerBase
    {
        [HttpGet]
        [Route("api/[controller]/{request}")]
        public ABNEntity GetMatchingNames(string  request)
        {
            return new ABNEntity {Abn = "12342132"};
        }
    }
}