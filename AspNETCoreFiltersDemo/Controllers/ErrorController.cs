using AspNETCoreFiltersDemo.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace AspNETCoreFiltersDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ErrorController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(int id)
        {
            if (id == -1)
                throw HttpResponseException.InvalidID;
            else
                return new OkObjectResult("testing ok");
        }
    }
}