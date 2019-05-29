using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OrderServices.Domain;

namespace OrderServices.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private IOrderService orderService;


        public OrdersController()
        {
            
        }

        [HttpGet]
        public ActionResult<IEnumerable<Order>> Get()
        {

            return new List<Order> {new Order()};

        }
    }
}