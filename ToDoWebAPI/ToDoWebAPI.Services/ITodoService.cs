using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoAPI.Models;

namespace ToDoAPI.Service
{
    public interface ITodoService
    {
        Task<List<TodoItem>> GetAllItems();
        Task<TodoItem> Get(long id);

        Task<TodoItem> Add(TodoItem item);
        Task Update(TodoItem itemToUpdate);
        Task Remove(TodoItem item);

    }
}