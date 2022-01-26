using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using Java.Interop;
using System;
using ToDoList.Core.Models.ToDoItem;
using ToDoList.Core.ViewModels;

namespace ToDoList.AndroidWork.Activities
{
    [Activity(Label = "AddToDoItemActivity")]
    public class AddToDoItemActivity : BaseActivity
    {
        private ToDoItemViewModel ViewModel => BaseViewModel as ToDoItemViewModel;

        private EditText _description;
        private Button _btnAdd;
        private Button _btnBack;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_addToDoItem);

            _description = FindViewById<EditText>(Resource.Id.itemDescription);
            _btnAdd = FindViewById<Button>(Resource.Id.buttonAddItem);
            _btnBack = FindViewById<Button>(Resource.Id.buttonBack);
        }

        [Export("OnAddClick")]
        public void OnAddClick(View view)
        {
            var item = new ToDoItemModel()
            {
                UID = Guid.NewGuid(),
                Description = _description.Text,
                Status = ToDoItemStatus.Open
            };
            ViewModel.ToDoItem = item;
            ViewModel.AddItem();
        }

        [Export("OnBackClick")]
        public void OnBackClick(View view)
        {
            ViewModel.GoBack();
        }
    }
}