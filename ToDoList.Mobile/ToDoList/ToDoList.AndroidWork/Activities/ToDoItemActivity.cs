using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using Java.Interop;
using System;
using System.ComponentModel;
using ToDoList.AndroidWork.Services;
using ToDoList.Core.Models.ToDoItem;
using ToDoList.Core.ViewModels;

namespace ToDoList.AndroidWork.Activities
{
    [Activity(Label = "ToDoItemActivity")]
    public class ToDoItemActivity : BaseActivity
    {
        private ToDoItemViewModel ViewModel => BaseViewModel as ToDoItemViewModel;

        private TextView _desciption;
        private TextView _status;
        private Button _btnBack;
        private Button _btnClose;
        private Button _btnReopen;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_toDoItem);

            _desciption = FindViewById<TextView>(Resource.Id.itemDescription);
            _status = FindViewById<TextView>(Resource.Id.itemStatus);

            _btnBack = FindViewById<Button>(Resource.Id.buttonBack);
            _btnClose = FindViewById<Button>(Resource.Id.buttonCloseItem);
            _btnReopen = FindViewById<Button>(Resource.Id.buttonReopenItem);
        }

        protected override void OnStart()
        {
            base.OnStart();

            string itemID = Intent?.GetStringExtra(AndroidNavigationService.ParameterExtraKey);
            var uid = Guid.Parse(itemID);
            ViewModel.LoadItem(uid);
        }

        protected override void ViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.ViewModelPropertyChanged(sender, e);
            switch (e.PropertyName)
            {
                case nameof(ViewModel.ToDoItem):
                    _desciption.Text = ViewModel.ToDoItem.Description;
                    _status.Text = ViewModel.ToDoItem.Status.ToString();
                    if (ViewModel.ToDoItem.Status == ToDoItemStatus.Closed)
                    {
                        _btnClose.Visibility = ViewStates.Gone;
                        _btnReopen.Visibility = ViewStates.Visible;
                    }
                    else
                    {
                        _btnReopen.Visibility = ViewStates.Gone;
                        _btnClose.Visibility = ViewStates.Visible;
                    }
                    break;
                default:
                    break;
            }
        }

        [Export("OnBackClick")]
        public void OnBackClick(View view)
        {
            ViewModel.GoBack();
        }

        [Export("OnDoneClick")]
        public void OnDoneClick(View view)
        {
            ViewModel.MarkDone();
        }

        [Export("OnReopenClick")]
        public void OnReopenClick(View view)
        {
            ViewModel.Reopen();
        }
    }
}