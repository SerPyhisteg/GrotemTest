using Android.Widget;
using ToDoList.Core.Interfaces.Services;
using ToDoList.Core.Models.Common;
using Xamarin.Essentials;

namespace ToDoList.Services
{
    public class AndroidDialogService : IDialogService
    {
        public void ShowToast(string message)
        {
            Toast.MakeText(Platform.CurrentActivity, message, ToastLength.Short);
        }
    }

    public class AndroidNavigationService : INavigationService
    {
        public const string ViewModelNameExtraKey = "ViewModelName";

        public void GoToPage(ModelState state, string extra = null)
        {
            throw new System.NotImplementedException();
        }
    }
}