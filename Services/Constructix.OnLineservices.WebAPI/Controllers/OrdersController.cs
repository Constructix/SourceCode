using System;
using Constructix.OnLineServices.Domain;
using Constructix.OnLineServices.Services;
using Microsoft.AspNetCore.Mvc;

namespace Constructix.OnLineservices.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        private readonly IService<Order> orderService;


        public OrdersController(IService<Order> orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet]
        public IActionResult Get(Guid id)
        {
            var order = orderService.Get(id);
            if (order != null)
                return new OkObjectResult(order);
            else
            {
                return NotFound(id);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Order newOrder)
        {
            orderService.Add(newOrder);
            return Ok();
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            return new OkObjectResult(orderService.GetAll());
        }


    }
}