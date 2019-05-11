using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RiderWebAPIDemo.Services;
using RiderWebAPIDemo.Services.Services;

namespace RiderWebAPIDemo.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController
    {

        private readonly IService<Product> _productService;

        public ProductsController(IService<Product> productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IEnumerable<Product> GetAll()
        {
            return _productService.GetAll();
        }

        [HttpGet("/{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Product> Get(Guid id)
        {
            return  _productService.Get(id);
            
        }
    }
}