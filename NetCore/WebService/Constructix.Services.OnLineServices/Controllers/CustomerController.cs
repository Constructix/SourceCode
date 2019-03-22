using System.Collections.Generic;
using Constructix.Service.OnlineServices;
using Constructix.Services.DomainModel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Constructix.Services.OnLineServices.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private CustomerService _customerService;

        public CustomerController()
        {
            _customerService = new CustomerService();
        }
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return _customerService.GetCustomers();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
