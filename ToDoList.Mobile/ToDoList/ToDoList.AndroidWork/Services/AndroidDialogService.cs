using Android.Widget;
using ToDoList.Core.Interfaces.Services;
using Xamarin.Essentials;

namespace ToDoList.AndroidWork.Services
{
    public class AndroidDialogService : IDialogService
    {
        private readonly IDispatcherService _dispatcherService;

        public AndroidDialogService(IDispatcherService dispatcherService)
        {
            _dispatcherService = dispatcherService;
        }

        public void ShowToast(string message)
        {
            var toast = Toast.MakeText(Platform.CurrentActivity, message, ToastLength.Short);
            _dispatcherService.RunOnUIThread(toast.Show);
        }
    }
}