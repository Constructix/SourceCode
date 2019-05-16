using Microsoft.EntityFrameworkCore;
using ToDoAPI.Models;

namespace ToDoAPI.Contexts
{



    public class TodoContext : DbContext
    {
        public DbSet<TodoItem> TodoItems { get; set; }



        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {
            
        }
    }
}