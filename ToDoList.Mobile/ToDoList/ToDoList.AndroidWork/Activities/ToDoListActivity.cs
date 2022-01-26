using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.Widget;
using Android.Views;
using System;
using System.ComponentModel;
using System.Linq;
using ToDoList.AndroidWork.Adapters;
using ToDoList.Core.Models.ToDoItem;
using ToDoList.Core.ViewModels;

namespace ToDoList.AndroidWork.Activities
{
    [Activity(Label = "ToDoListActivity")]
    public class ToDoListActivity : BaseActivity
    {
        private RecyclerView _toDoList;
        private ToDoItemsAdapter _toDoItemsAdapter;

        private ToDoListViewModel ViewModel => BaseViewModel as ToDoListViewModel;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_todolist);

            _toDoList = FindViewById<RecyclerView>(Resource.Id.toDoListView);

            var fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;
        }

        protected override void OnResume()
        {
            base.OnResume();

            var layoutManager = new LinearLayoutManager(BaseContext);
            _toDoList.SetLayoutManager(layoutManager);

            _toDoItemsAdapter = new ToDoItemsAdapter(ViewModel.ToDoItems);
            _toDoItemsAdapter.ItemClicked += ItemClicked;

            _toDoList.SetAdapter(_toDoItemsAdapter);
        }

        private void ItemClicked(object sender, ToDoItemModel e)
        {
            ViewModel.OpenItem(e);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            ViewModel.AddItem();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            switch (id)
            {
                case Resource.Id.showAll:
                    ViewModel.LoadData();
                    return true;
                case Resource.Id.showOpen:
                    ViewModel.FilterItems(ToDoItemStatus.Open);
                    return true;
                case Resource.Id.showClosed:
                    ViewModel.FilterItems(ToDoItemStatus.Closed);
                    return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        protected override void ViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(ToDoListViewModel.ToDoItems):
                    if (_toDoItemsAdapter != null)
                    {
                        _toDoItemsAdapter.Items = ViewModel.ToDoItems.ToList();
                    }
                    break;
                default:
                    break;
            }
        }
    }
}