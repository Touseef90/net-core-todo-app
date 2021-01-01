using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Models;

namespace TodoApp.Data
{
  public class SqlTodoData : ITodoData
  {
    private readonly TodoContext _todoContext;

    public SqlTodoData(TodoContext todoContext)
    {
        _todoContext = todoContext;
    }
    public Todo AddTodo(Todo todo)
    {
      todo.Id = Guid.NewGuid();
      _todoContext.Todos.Add(todo);
      _todoContext.SaveChanges();
      return todo;
    }

    public void DeleteTodo(Todo todo)
    {
      _todoContext.Todos.Remove(todo);
      _todoContext.SaveChanges();
    }

    public Todo EditTodo(Todo todo)
    {
      var existingTodo = GetTodo(todo.Id);
      existingTodo.Title = todo.Title;
      existingTodo.Description = todo.Description;
      _todoContext.Todos.Update(existingTodo);
      _todoContext.SaveChanges();
      return existingTodo;
    }

    public Todo GetTodo(Guid id)
    {
      return _todoContext.Todos.Find(id);
    }

    public List<Todo> GetTodos()
    {
      return _todoContext.Todos.ToList();
    }
  }
}
