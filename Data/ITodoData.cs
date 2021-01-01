using System;
using System.Collections.Generic;
using TodoApp.Models;

namespace TodoApp.Data
{
    public interface ITodoData
    {
        List<Todo> GetTodos();

        Todo GetTodo(Guid id);

        Todo AddTodo(Todo todo);

        void DeleteTodo(Todo todo);

        Todo EditTodo(Todo todo);
    }
}