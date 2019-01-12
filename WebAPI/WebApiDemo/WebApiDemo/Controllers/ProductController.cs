using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Models;

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            List<Product> products = new List<Product> {  new Product {  Id = 1, Name = "First", UnitPrice = 100.00m},
                new Product {  Id = 2, Name = "Second", UnitPrice = 120.00m},
                new Product {  Id = 3, Name = "Third", UnitPrice = 130.00m},
                new Product {  Id = 4, Name = "Fourth", UnitPrice = 140.00m}
                };

            return products;
        }
    }
}
