using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDoAPI.Contexts;
using ToDoAPI.Models;

namespace ToDoAPI.Repository
{
   public class TodoRespository :  IGenericRepository<TodoItem>, ITodoRepository
   {
        private readonly TodoContext _context;

        public TodoRespository(TodoContext context)
        {
            _context = context;

            if (!_context.TodoItems.Any())
            {
                _context.TodoItems.Add(new TodoItem { Name = "Item1" });
                _context.SaveChanges();
            }
        }

        public async Task<List<TodoItem>> GetAll()
        {
            return await _context.TodoItems.ToListAsync();
        }

        public async Task<TodoItem> Get(long id)
        {
            var todoItem =  await _context.TodoItems.FindAsync(id);
            return todoItem;
        }

        public async Task<TodoItem> Add(TodoItem item)
        {
            var newITemAdded = await _context.TodoItems.AddAsync(item);
            await _context.SaveChangesAsync();
            
            return newITemAdded.Entity;
        }

        public async Task Update(TodoItem item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await SaveChanges();
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Remove(TodoItem item)
        {
             _context.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}