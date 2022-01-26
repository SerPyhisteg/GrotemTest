using System;
using System.Threading.Tasks;
using ToDoList.Core.Interfaces.Providers;
using ToDoList.Core.Interfaces.Services;
using ToDoList.Core.Models.Common;
using ToDoList.Core.Models.ToDoItem;

namespace ToDoList.Core.ViewModels
{
    public class ToDoItemViewModel : BaseViewModel
    {
        private ToDoItemModel toDoItem;
        public ToDoItemModel ToDoItem
        {
            get => toDoItem;
            set
            {
                toDoItem = value;
                NotifyOfPropertyChange();
            }
        }

        private readonly IToDoItemProvider _toDoItemProvider;
        private readonly IDialogService _dialogService;
        private readonly INavigationService _navigationService;

        public ToDoItemViewModel(IToDoItemProvider toDoItemProvider, IDialogService dialogService, INavigationService navigationService)
        {
            _toDoItemProvider = toDoItemProvider;
            _dialogService = dialogService;
            _navigationService = navigationService;
        }

        public async Task LoadItem(Guid uid)
        {
            ToDoItem = await _toDoItemProvider.GetItem(uid);
        }

        public async Task MarkDone()
        {
            ToDoItem.Status = ToDoItemStatus.Closed;
            var result = await _toDoItemProvider.UpdateItem(ToDoItem);
            if (result)
            {
                _dialogService.ShowToast("Item marked as done");
                NotifyOfPropertyChange(nameof(ToDoItem));
            }
            else
            {
                _dialogService.ShowToast("Cannot save TODO item");
            }
        }

        public async Task Reopen()
        {
            ToDoItem.Status = ToDoItemStatus.Open;
            var result = await _toDoItemProvider.UpdateItem(ToDoItem);
            if (result)
            {
                _dialogService.ShowToast("Item reopened");
                NotifyOfPropertyChange(nameof(ToDoItem));
            }
            else
            {
                _dialogService.ShowToast("Cannot save TODO item");
            }
        }

        public async Task AddItem()
        {
            var result = await _toDoItemProvider.AddItem(ToDoItem);
            if (result)
            {
                _dialogService.ShowToast("Item created");
                _navigationService.GoToPage(ModelState.ToDoItem, ToDoItem.UID.ToString());
            }
            else
            {
                _dialogService.ShowToast("Cannot create TODO item");
            }
        }

        public void GoBack()
        {
            _navigationService.GoToPage(ModelState.ToDoList);
        }
    }
}
