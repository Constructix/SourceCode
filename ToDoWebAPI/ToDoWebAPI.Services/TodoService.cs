using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoAPI.Models;
using ToDoAPI.Repository;

namespace ToDoAPI.Service
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _repository;

        public TodoService() { }

        public TodoService(ITodoRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<TodoItem>> GetAllItems()
        {
            return await _repository.GetAll(); 
        }

        public async Task<TodoItem> Add(TodoItem item)
        {
          var  newITemAdded =  await _repository.Add(item);
          return newITemAdded;
        }

        public async Task Update(TodoItem itemToUpdate)
        {
            await _repository.Update(itemToUpdate);
        }

        public async Task<TodoItem> Get(long id)
        {
            return await _repository.Get(id);
        }

        public async Task Remove(TodoItem item)
        {
            await _repository.Remove(item);
        }
    }
}