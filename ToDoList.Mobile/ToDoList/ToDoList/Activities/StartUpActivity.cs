using Android.App;
using Android.OS;

namespace ToDoList.Activities
{
    [Activity(Label = "StartUpActivity", MainLauncher = true)]
    public class StartUpActivity : BaseActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_startup);
        }
    }
}