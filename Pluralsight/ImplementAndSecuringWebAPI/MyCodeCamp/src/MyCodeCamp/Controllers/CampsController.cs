using System;
using Microsoft.AspNetCore.Mvc;

namespace MyCodeCamp.Controllers
{


    //public class Order
    //{
    //    public Guid Id { get; set; }
    //    public DateTime Created { get; set; }

    //    public Order()
    //    {
    //        Id = Guid.NewGuid();
    //        Created = DateTime.Now;

    //    }
    //}

    [Route("api/[controller]")]
    public class CampsController : Controller
    {
        // action
        [HttpGet("")]
        public IActionResult Get()
        {
            return Ok( new {Name = "Shawn", FavouriteColor = "Blue"});
        }
    }
}