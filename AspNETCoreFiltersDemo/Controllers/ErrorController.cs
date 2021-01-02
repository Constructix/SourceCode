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
                throw new HttpResponseException() { Status = 400, Value = "There is no Product Id that matches the id supplied."};
            else
                return new OkObjectResult("testing ok");
        }
    }
}