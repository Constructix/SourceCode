using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MyCodeCamp.Data;
using MyCodeCamp.Data.Entities;

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
        private ICampRepository _repo;

       
        public CampsController(ICampRepository repo)
        {
            _repo = repo;

        }
        // action
        [HttpGet("")]
        public IActionResult Get()
        {

            var camps = _repo.GetAllCamps();

            
            return Ok( camps);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id, bool includeSpeakers = false)
        {
            try
            {
                var camp = includeSpeakers ? _repo.GetCampWithSpeakers(id) : _repo.GetCamp(id);
                if (camp == null)
                    return NotFound($"Camp {id} was not found.");
                return Ok(camp);
            }
            catch 
            {
             
            }
            return BadRequest();
        }
    }
}