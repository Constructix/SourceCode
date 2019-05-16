using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoAPI.Models;

namespace ToDoAPI.Repository
{
    public interface ITodoRepository
    {
        Task<List<TodoItem>> GetAll();

        Task<TodoItem> Get(long id);
        Task<TodoItem> Add(TodoItem item);

        Task Update(TodoItem itemToUpdate);
        Task SaveChanges();
        Task Remove(TodoItem item);
    }

    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> Get(long id);
        Task<T> Add(T item);
        Task Update(T itemToUpdate);
        Task SaveChanges();
        Task Remove(T item);
    }
}