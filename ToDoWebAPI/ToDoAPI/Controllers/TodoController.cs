using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoAPI.Models;
using ToDoAPI.Service;

namespace ToDoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _service;
        public TodoController( ITodoService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetToDoItems()
        {
            return await _service.GetAllItems(); 
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetToDoItem(long id)
        {
            var todoItem = await _service.Get(id); 
            if (todoItem == null)
                return NotFound();
            return todoItem;
        }

        [HttpPost]
        public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem item)
        {
            var newItem = await _service.Add(item);
            return CreatedAtAction(nameof(GetToDoItem), new { id = newItem.Id }, newItem);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(long id, TodoItem item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }
            await _service.Update(item);
            return NoContent();
        }

        // DELETE: api/Todo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(long id)
        {
            var todoItem = await _service.Get(id); 

            if (todoItem == null)
            {
                return NotFound();
            }
            await _service.Remove(todoItem);
            return NoContent();
        }
    }
}