using System;

namespace ToDoAPI.Models
{
    public class TodoItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }

        public DateTime Created { get; }

        public TodoItem()
        {
            Created  = DateTime.Now.ToUniversalTime();
        }
    }
}
