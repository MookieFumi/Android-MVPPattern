using System.Collections.Generic;
using System.Linq;
using System;
using MVPPattern.Infrastructure;

namespace MVPPattern.Features.Todos
{
    public class TodosPresenter : PresenterBase, ITodosPresenter
    {
        private readonly ITodosView _view;
        private readonly ITodosService _todosService;

        public List<Todo> Items { get; set; }
        public int? FirstVisibleItemPosition { get; set; }

        public class Data
        {
            public Data(List<Todo> items, int? firstVisibleItemPosition)
            {
                Items = items;
                FirstVisibleItemPosition = firstVisibleItemPosition;
            }

            public List<Todo> Items { get; private set; }
            public int? FirstVisibleItemPosition { get; private set; }
        }

        public TodosPresenter(ITodosView view, ITodosService todosService, List<Todo> items = null)
        {
            _view = view;
            _todosService = todosService;
            Items = items ?? Enumerable.Empty<Todo>().ToList();
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

        public override void SaveState(StateManager stateManager)
        {
            stateManager.SetState(typeof(TodosPresenter), new Data(Items, FirstVisibleItemPosition));
        }

        public override void RestoreState(StateManager stateManager)
        {
            var restoredValue = (Data)stateManager.GetState(typeof(TodosPresenter));
            if (restoredValue != null)
            {
                Items = restoredValue.Items;
                FirstVisibleItemPosition = restoredValue.FirstVisibleItemPosition;
            }
        }
    }
}
