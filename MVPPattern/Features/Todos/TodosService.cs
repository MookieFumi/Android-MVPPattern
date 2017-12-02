using System;
using System.Collections.Generic;
using System.Linq;

namespace MVPPattern.Features.Todos
{
    public class TodosService : ITodosService
    {
        private static readonly List<Todo> _items = new List<Todo>() {
            new Todo(Guid.NewGuid().ToString()),
            new Todo(Guid.NewGuid().ToString()),
            new Todo(Guid.NewGuid().ToString()),
            new Todo(Guid.NewGuid().ToString()),
            new Todo(Guid.NewGuid().ToString())
        };

        public void Add(Todo todo)
        {
            _items.Add(todo);
        }

        public Todo GetTodo(string name)
        {
            return _items.SingleOrDefault(p => p.Name == name);
        }

        public IEnumerable<Todo> GetTodos()
        {
            return _items;
        }
    }
}