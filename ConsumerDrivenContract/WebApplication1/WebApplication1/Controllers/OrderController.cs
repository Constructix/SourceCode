using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase   
    {
        [HttpGet]
        // GET
        public OrderResponse Index()
        {
            return new OrderResponse
            {
                DateTimeStamp = DateTime.Now, Request = new OrderRequest(), ResponseId = Guid.NewGuid()
            };
        }
       // POST api/values
       [HttpPost]
        public ActionResult<OrderResponse> Post([FromBody] OrderRequest orderRequest)
        {
            var response = new OrderResponse
            {
                DateTimeStamp = DateTime.Now,
                ResponseId = Guid.NewGuid(),
                Request = orderRequest
            };
            return response;
        }

    }
}