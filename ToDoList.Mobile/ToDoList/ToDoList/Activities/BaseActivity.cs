using Android.App;
using Android.OS;
using Android.Support.V7.App;
using System;
using System.ComponentModel;
using ToDoList.Core.Interfaces.Services;
using ToDoList.Core.ViewModels;
using ToDoList.Services;
using Xamarin.Essentials;

namespace ToDoList.Activities
{
    public class BaseActivity : AppCompatActivity
    {
        protected BaseViewModel BaseViewModel { get; private set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Platform.Init(this, savedInstanceState);
        }

        protected override void OnStart()
        {
            base.OnStart();

            var viewModelName = Intent?.GetStringExtra(AndroidNavigationService.ViewModelNameExtraKey);
            if (!string.IsNullOrWhiteSpace(viewModelName))
            {
                var type = Type.GetType(viewModelName);
                BaseViewModel = (ApplicationContext as IDependencyResolver).GetInstance(type) as BaseViewModel;
                BaseViewModel.PropertyChanged += ViewModelPropertyChanged;
                
                BaseViewModel.LoadData();
            }
        }

        protected virtual void ViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            
        }
    }
}