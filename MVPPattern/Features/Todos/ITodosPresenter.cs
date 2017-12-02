using System.Collections.Generic;

namespace MVPPattern.Features.Todos
{
    //Actions – this defines the methods that the concrete Presenter class will implement. 
    //Also known as user actions, this is where the business logic for the app is defined.
    public interface ITodosPresenter
    {
        List<Todo> Items { get; set; }
        int? FirstVisibleItemPosition { get; set; }
        void OnShowTodosButtonClicked();
        void AddRandomTodo();
        void OnTodoClicked(Todo e);
    }
}