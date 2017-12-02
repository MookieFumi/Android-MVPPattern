using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using System;
using System.Linq;

namespace MVPPattern.Features.Todos
{
    public class TodosAdapter : RecyclerView.Adapter
    {
        private readonly ITodosView _view;
        private readonly ITodosPresenter _presenter;

        public event EventHandler<Todo> TodoClicked;

        protected virtual void OnTodoClicked(Todo player)
        {
            TodoClicked?.Invoke(this, player);
        }

        public event EventHandler<Todo> TodoLongClicked;

        protected virtual void OnTodoLongClicked(Todo player)
        {
            TodoLongClicked?.Invoke(this, player);
        }

        public TodosAdapter(ITodosView view, ITodosPresenter presenter)
        {
            _presenter = presenter;
            _view = view;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            var todo = _presenter.Items.ElementAt(position);
            var holder = viewHolder as TodoHolder;

            holder.Name.Text = todo.Name;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            //Setup and inflate your layout here
            var itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.TodosListRow, parent, false);
            return new TodoHolder(itemView, OnClick(), OnLongClick());
        }

        private Action<int> OnClick()
        {
            return position =>
            {
                var todo = _presenter.Items.ElementAt(position);
                OnTodoClicked(todo);
            };
        }

        private Action<int> OnLongClick()
        {
            return (position) =>
            {
                var todo = _presenter.Items.ElementAt(position);
                OnTodoLongClicked(todo);
            };
        }

        public override int ItemCount => _presenter.Items.Count;

        public class TodoHolder : RecyclerView.ViewHolder
        {
            public TodoHolder(View view, Action<int> onClick, Action<int> onLongClick) : base(view)
            {
                view.Click += (sender, e) => onClick(base.AdapterPosition);
                view.LongClick += (sender, e) => onLongClick(base.AdapterPosition);

                Name = view.FindViewById<TextView>(Resource.Id.name);
            }

            public TextView Name { get; }
        }
    }
}