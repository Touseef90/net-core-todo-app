using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Models;

namespace TodoApp.Data
{
  public class MockTodo : ITodoData
  {
    private List<Todo> todos = new List<Todo>()
    {
      new Todo(){ Id = Guid.NewGuid(), Title = "Clean Dishes", Description = "Clean all" },
      new Todo(){ Id = Guid.NewGuid(), Title = "Make an API", Description = "Use .net core" }
    };
    public Todo AddTodo(Todo todo)
    {
      todo.Id = Guid.NewGuid();
      todos.Add(todo);
      return todo;
    }

    public void DeleteTodo(Todo todo)
    {
      todos.Remove(todo);
    }

    public Todo EditTodo(Todo todo)
    {
      var existingTodo = GetTodo(todo.Id);
      existingTodo.Title = todo.Title;
      existingTodo.Description = todo.Description;
      return existingTodo;
    }

    public Todo GetTodo(Guid id)
    {
      return todos.SingleOrDefault(x => x.Id == id);
    }

    public List<Todo> GetTodos()
    {
      return todos;
    }
  }
}
