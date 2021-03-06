﻿using System.Linq;
using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Widget;
using Refractored.Fab;
using MVPPattern.Infrastructure;

namespace MVPPattern.Features.Todos
{
    [Activity(MainLauncher = true)]
    public class TodosActivity : Activity, ITodosView
    {
        private RecyclerView _recyclerView;
        private TodosAdapter _adapter;

        private ITodosPresenter _presenter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Todos);
            Log(nameof(OnCreate));

            SetupRecyclerView();
            SetupButtons();
        }

        public void Busy(bool value = false)
        {
            System.Diagnostics.Debug.WriteLine($"Loading indicator {value}");
        }

        public void OnShowTodosButtonClicked()
        {
            _presenter.OnShowTodosButtonClicked();
        }

        public void NotifyDataSetChanged()
        {
            _adapter.NotifyDataSetChanged();
            _recyclerView.ScrollToPosition(_presenter.Items.Count() - 1);
        }

        public void ShowTodoDetail(string value)
        {
            Toast.MakeText(this, value, ToastLength.Short).Show();
        }

        private void SetupButtons()
        {
            var showTodosButton = FindViewById<Button>(Resource.Id.showTodosButton);
            showTodosButton.Click += (sender, e) =>
            {
                _presenter.OnShowTodosButtonClicked();
            };

            var fabButton = FindViewById<FloatingActionButton>(Resource.Id.fab);
            //fabButton.AttachToRecyclerView(_recyclerView);
            fabButton.Click += (sender, e) =>
            {
                _presenter.AddRandomTodo();
            };
        }

        private void SetupRecyclerView()
        {
            _recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);

            var _todosService = new TodosService();
            _presenter = new TodosPresenter(this, _todosService, null);

            ((PresenterBase)_presenter).RestoreState(StateManager.Instance);

            _adapter = new TodosAdapter(this, _presenter);
            _adapter.TodoClicked += (sender, e) =>
            {
                _presenter.OnTodoClicked(e);
            };
            _adapter.TodoLongClicked += (sender, e) =>
            {
                Toast.MakeText(this, $"Long click. {e.Name}", ToastLength.Short).Show();
                //_presenter.TodoLongClicked(e);
            };

            _recyclerView.SetLayoutManager(new LinearLayoutManager(this));
            _recyclerView.SetAdapter(_adapter);

            if (_presenter.FirstVisibleItemPosition.HasValue)
            {
                _recyclerView.ScrollToPosition(_presenter.FirstVisibleItemPosition.Value);
            }
        }

        #region Lifecycle events
        protected override void OnStart()
        {
            base.OnStart();
            Log(nameof(OnStart));
        }

        protected override void OnResume()
        {
            base.OnResume();
            Log(nameof(OnResume));
        }

        protected override void OnPause()
        {
            base.OnPause();
            Log(nameof(OnPause));
        }

        protected override void OnStop()
        {
            base.OnStop();
            Log(nameof(OnStop));
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            Log(nameof(OnDestroy));
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
            Log(nameof(OnSaveInstanceState));

            SaveState();
        }

        private void SaveState()
        {
            if (_recyclerView.GetLayoutManager() != null)
            {
                int position = ((LinearLayoutManager)_recyclerView.GetLayoutManager()).FindFirstVisibleItemPosition();
                _presenter.FirstVisibleItemPosition = position;
            }
            ((PresenterBase)_presenter).SaveState(StateManager.Instance);
        }

        private void Log(string text)
        {
            System.Diagnostics.Debug.WriteLine(text);
        }

        #endregion
    }
}