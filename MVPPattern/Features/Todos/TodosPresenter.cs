using System.Collections.Generic;
using System.Linq;
using System;

namespace MVPPattern.Features.Todos
{
    public class TodosPresenter : ITodosPresenter
    {
        private readonly ITodosView _view;
        private readonly ITodosService _todosService;

        public List<Todo> Items { get; set; }

        public TodosPresenter(ITodosView view, ITodosService todosService)
        {
            _view = view;
            _todosService = todosService;
            Items = Enumerable.Empty<Todo>().ToList();
        }

        public void OnShowTodosButtonClicked()
        {
            _view.Busy(true);

            Items.AddRange(_todosService.GetTodos());
            _view.NotifyDataSetChanged();

            _view.Busy();
        }

        public void AddRandomTodo()
        {
            _view.Busy(true);

            Items.Add(new Todo(Guid.NewGuid().ToString()));
            _view.NotifyDataSetChanged();

            _view.Busy();
        }

        public void OnTodoClicked(Todo e)
        {
            _view.ShowTodoDetail($"Clicked on {e.Name}");
        }
    }
}
