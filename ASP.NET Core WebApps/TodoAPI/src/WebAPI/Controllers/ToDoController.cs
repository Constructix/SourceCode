﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TodoAPI.Models;

namespace TodoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {

        private readonly TodoContext _context;

        public ToDoController(TodoContext context)
        {
            _context = context;

            //////////////////////////////////////////////////////////////////////////////
            // Create dummy first Item.
            if (_context.TodoItems.Count() == 0)
            {
                _context.TodoItems.Add(new TodoItem {Name = "Item1"});
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public ActionResult<List<TodoItem>> GetAll()
        {
            return _context.TodoItems.ToList();
        }

        [HttpGet("{id}", Name = "GetTodo")]
        public ActionResult<TodoItem> GetById(int id)
        {
            var item = _context.TodoItems.Find(id);
            if(item == null)
            {
                return NotFound();
            }

            return item;
        }

        [HttpPost]
        public IActionResult Create(TodoItem newItem)
        {
            _context.TodoItems.Add(newItem);
            _context.SaveChanges();

            return CreatedAtRoute("GetTodo", new {id = newItem.Id}, newItem);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, TodoItem itemToUpdate)
        {
            var todo = _context.TodoItems.Find(id);
            if (todo == null)
                return NotFound();

            todo.IsComplete = itemToUpdate.IsComplete;
            todo.Name = itemToUpdate.Name;
            
            _context.TodoItems.Update(todo);
            _context.SaveChanges();

            return NoContent();
        }

    }
}