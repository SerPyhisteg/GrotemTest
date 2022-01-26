using Android.App;
using Android.OS;
using System;
using System.Threading;
using ToDoList.Core.Interfaces.Services;
using ToDoList.Core.Models.Common;

namespace ToDoList.AndroidWork.Activities
{
    [Activity(Label = "StartUpActivity", MainLauncher = true, Theme = "@style/AppTheme.NoActionBar")]
    public class StartUpActivity : BaseActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_startup);
        }

        protected override void OnResume()
        {
            base.OnResume();

            _ = new Timer(SplashEnds, this, TimeSpan.FromSeconds(1), Timeout.InfiniteTimeSpan);
        }

        private void SplashEnds(object sender)
        {
            var navigationService = (ApplicationContext as IDependencyResolver).GetInstance<INavigationService>();
            navigationService.GoToPage(ModelState.ToDoList);
        }
    }
}