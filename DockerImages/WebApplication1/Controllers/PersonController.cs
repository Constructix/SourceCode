using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private List<Person> _persons;

        public PersonController()
        {
            _persons = new List<Person> {new Person(Guid.NewGuid(), "Richard", "Jones", "r_jones@constructix.com.au")};
        }
        [HttpGet]
        public  IActionResult Get(Guid Id)
        {
            var person =  _persons.Find(x =>x.Id.Equals(x.Id));
            if (person != null)
                return Ok(person);
            else
            {
                return NotFound("Person does does not exist.");
            }
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_persons);
        }
    }



    public class Person
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public Person()
        {
            
        }

        public Person(Guid id, string firstName, string lastName, string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
    }
}