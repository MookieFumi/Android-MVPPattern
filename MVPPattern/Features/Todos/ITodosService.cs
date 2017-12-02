using System.Collections.Generic;

namespace MVPPattern.Features.Todos
{
    //Repository – this defines the methods that the concrete persistence class will implement. 
    //This way the Presenter does not need to be concerned about how data is persisted.
    public interface ITodosService
    {
        IEnumerable<Todo> GetTodos();
        Todo GetTodo(string name);
        void Add(Todo todo);
    }
}