using Android.Content;
using System;
using ToDoList.AndroidWork.Activities;
using ToDoList.Core.Interfaces.Services;
using ToDoList.Core.Models.Common;
using ToDoList.Core.ViewModels;
using Xamarin.Essentials;

namespace ToDoList.AndroidWork.Services
{
    public class AndroidNavigationService : INavigationService
    {
        public const string ViewModelNameExtraKey = "ViewModelName";
        public const string ParameterExtraKey = "Parameter";

        public void GoToPage(ModelState state, string parameter = null)
        {
            var viewControllerType = GetViewForState(state);
            var viewModelType = GetViewModelForState(state);

            bool isNeededType = viewControllerType.IsSubclassOf(typeof(BaseActivity));

            if (!isNeededType)
            {
                throw new InvalidOperationException("Activity must be an ancestor of BaseActivity");
            }

            var intent = new Intent(Platform.CurrentActivity, viewControllerType);
            intent.PutExtra(ViewModelNameExtraKey, viewModelType.AssemblyQualifiedName);

            if (!string.IsNullOrWhiteSpace(parameter))
            {
                intent.PutExtra(ParameterExtraKey, parameter);
            }

            intent.AddFlags(ActivityFlags.ClearTop);

            Platform.CurrentActivity.StartActivity(intent);
        }

        private Type GetViewForState(ModelState state)
        {
            switch (state)
            {
                case ModelState.ToDoList:
                    return typeof(ToDoListActivity);
                case ModelState.ToDoItem:
                    return typeof(ToDoItemActivity);
                case ModelState.AddToDoItem:
                    return typeof(AddToDoItemActivity);
            }

            throw new ApplicationException($"No corresponding view for {state} was found");
        }

        private Type GetViewModelForState(ModelState state)
        {
            switch (state)
            {
                case ModelState.ToDoList:
                    return typeof(ToDoListViewModel);
                case ModelState.ToDoItem:
                case ModelState.AddToDoItem:
                    return typeof(ToDoItemViewModel);
            }

            throw new ApplicationException($"No corresponding view for {state} was found");
        }
    }
}