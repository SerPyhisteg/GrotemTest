using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using System.ComponentModel;
using System.Linq;
using ToDoList.Adapters;
using ToDoList.Core.Models.ToDoItem;
using ToDoList.Core.ViewModels;

namespace ToDoList.Activities
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

            _toDoItemsAdapter = new ToDoItemsAdapter(ViewModel.ToDoItems);
            _toDoItemsAdapter.ItemClicked += ItemClicked;

            _toDoList.SetAdapter(_toDoItemsAdapter);
        }

        private void ItemClicked(object sender, ToDoItemModel e)
        {
            ViewModel.OpenItem(e);
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