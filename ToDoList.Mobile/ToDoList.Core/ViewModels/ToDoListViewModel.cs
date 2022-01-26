using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoList.Core.Interfaces.Providers;
using ToDoList.Core.Interfaces.Services;
using ToDoList.Core.Models.Common;
using ToDoList.Core.Models.ToDoItem;
using System.Linq;

namespace ToDoList.Core.ViewModels
{
    public class ToDoListViewModel : BaseViewModel
    {
        private IEnumerable<ToDoItemModel> toDoItems;
        public IEnumerable<ToDoItemModel> ToDoItems
        {
            get => toDoItems;
            set
            {
                toDoItems = value;
                NotifyOfPropertyChange();
            }
        }

        private readonly IToDoItemProvider _toDoItemProvider;
        private readonly INavigationService _navigationService;

        public ToDoListViewModel(IToDoItemProvider toDoItemProvider, INavigationService navigationService)
        {
            _toDoItemProvider = toDoItemProvider;
            _navigationService = navigationService;
        }

        public override async Task LoadData()
        {
            ToDoItems = await _toDoItemProvider.GetAll();
        }

        public async Task FilterItems(ToDoItemStatus itemStatus)
        {
            var items = await _toDoItemProvider.GetAll();
            ToDoItems = items.Where(item => item.Status == itemStatus);
        }

        public void OpenItem(ToDoItemModel item)
        {
            _navigationService.GoToPage(ModelState.ToDoItem, item.UID.ToString());
        }

        public void AddItem()
        {
            _navigationService.GoToPage(ModelState.AddToDoItem);
        }
    }
}
