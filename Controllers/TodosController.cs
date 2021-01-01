using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TodoApp.Data;
using TodoApp.Models;

namespace TodoApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodosController : ControllerBase
    {
        private readonly ITodoData _todoData;

        public TodosController(ITodoData todoData)
        {
            _todoData = todoData;
        }

        // GET api/todos
        [HttpGet]
        public IActionResult GetTodos()
        {
            return Ok(_todoData.GetTodos());
        }

        // GET api/todos/{id}
        [HttpGet("{id}")]
        public IActionResult GetTodo(Guid id)
        {
            var todo = _todoData.GetTodo(id);

            if (todo != null)
            {
                return Ok(todo);
            }

            return NotFound("Todo not found");
        }

        // Post api/todos
        [HttpPost]
        public IActionResult AddTodo(Todo todo)
        {
            _todoData.AddTodo(todo);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host 
            + HttpContext.Request.Path + "/" + todo.Id, todo);
        }

        // Delete api/todos
        [HttpDelete("{id}")]
        public IActionResult DeleteTodo(Guid id)
        {
            var todo = _todoData.GetTodo(id);

            if (todo != null)
            {
                _todoData.DeleteTodo(todo);
                return Ok();
            }

            return NotFound("Todo not found");
        }

        // Patch api/todos
        [HttpPatch("{id}")]
        public IActionResult EditTodo(Guid id, Todo todo)
        {
            var existingTodo = _todoData.GetTodo(id);

            if (existingTodo != null)
            {
                todo.Id = existingTodo.Id;
                _todoData.EditTodo(todo);
                return Ok();
            }

            return NotFound("Todo not found");
        }
    }
}
