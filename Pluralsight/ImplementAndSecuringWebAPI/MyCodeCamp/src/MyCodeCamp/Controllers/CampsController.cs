using System;
using System.Linq;
using System.Threading.Tasks;
using Castle.Core.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private Microsoft.Extensions.Logging.ILogger _logger;
       
        public CampsController(ICampRepository repo, ILogger<CampsController> logger)
        {
            _repo = repo;
            _logger = logger;

        }
        // action
        [HttpGet("")]
        public IActionResult Get()
        {

            var camps = _repo.GetAllCamps();

            
            return Ok( camps);
        }

        [HttpGet("{id}", Name="CampGet")]
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

        //
        // sending data via the body, need to add the [FromBody] attribute
        //

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Camp model)
        {
            try
            {

                _logger.LogInformation("Creating a new Code Camp");
                _repo.Add(model);
                if ( await _repo.SaveAllAsync())
                {
                    var newUri = Url.Link("CampGet", new {id = model.Id});
                    return Created(newUri, model);
                }
                else
                    _logger.LogWarning("Coulde not save Camp to  the database.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Threw exception while saving camp : {ex}");

                throw;
            }

            return BadRequest();
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Camp model)
        {
            try
            {
                var oldCamp =_repo.GetCamp(id);
                if (oldCamp == null) return NotFound($"Could not find a camp with Id of {id}");
                // map model to old camp
                oldCamp.Name = model.Name ?? oldCamp.Name;
                oldCamp.Description = model.Description ?? oldCamp.Description;
                oldCamp.Location = model.Location ?? oldCamp.Location;
                oldCamp.Length = model.Length > 0 ? model.Length : oldCamp.Length;
                oldCamp.EventDate = model.EventDate !=  DateTime.MinValue ? model.EventDate: oldCamp.EventDate;
                if (await _repo.SaveAllAsync())
                    return Ok(oldCamp);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                
            }
            return BadRequest("Couldn't update Camp");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var oldCamp = _repo.GetCamp(id);
                if (oldCamp == null) return NotFound($"Could not find Camp with Id {id}");

                _repo.Delete(oldCamp);
                if (await _repo.SaveAllAsync())
                    return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return BadRequest("Could not delete camp");
        }
    }
}