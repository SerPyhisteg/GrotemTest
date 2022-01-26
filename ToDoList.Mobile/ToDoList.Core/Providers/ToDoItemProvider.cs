using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Core.Interfaces.Database;
using ToDoList.Core.Interfaces.Network;
using ToDoList.Core.Interfaces.Providers;
using ToDoList.Core.Models.ToDoItem;

namespace ToDoList.Core.Providers
{
    public class ToDoItemProvider : IToDoItemProvider
    {
        private readonly IToDoItemsNetworkService _toDoItemNetworkService;
        private readonly IToDoItemStorage _toDoItemStorage;

        public ToDoItemProvider(IToDoItemsNetworkService toDoItemNetworkService, IToDoItemStorage toDoItemStorage)
        {
            _toDoItemNetworkService = toDoItemNetworkService;
            _toDoItemStorage = toDoItemStorage;
        }

        public async Task<IEnumerable<ToDoItemModel>> GetAll()
        {
            var items = await _toDoItemNetworkService.GetAll();

            _toDoItemStorage.SaveAllItems(items);
            return items;
        }

        public async Task<IEnumerable<ToDoItemModel>> GetItemsWithStatus(ToDoItemStatus itemStatus)
        {
            var items = _toDoItemStorage.GetAllItems();

            if (!items.Any())
            {
                items = await _toDoItemNetworkService.GetAll();
                _toDoItemStorage.SaveAllItems(items);
            }

            return items.Where(item => item.Status == itemStatus);
        }


        public async Task<bool> AddItem(ToDoItemModel item)
        {
            bool result = await _toDoItemNetworkService.AddItem(item);

            if (result)
            {
                _toDoItemStorage.SaveItem(item);
            }

            return result;
        }

        public async Task<bool> UpdateItem(ToDoItemModel item)
        {
            bool result = await _toDoItemNetworkService.UpdateItem(item);

            if (result)
            {
                _toDoItemStorage.UpdateItem(item);
            }
            return result;
        }

        public async Task<ToDoItemModel> GetItem(Guid uid)
        {
            var item = _toDoItemStorage.GetItem(uid);

            if (item != null)
            {
                return item;
            }

            var items = await _toDoItemNetworkService.GetAll();
            item = items.FirstOrDefault(todo => todo.UID == uid);

            if (item != null)
            {
                _toDoItemStorage.SaveAllItems(items);
                return item;
            }

            return new ToDoItemModel() { UID = Guid.NewGuid() };
        }
    }
}
