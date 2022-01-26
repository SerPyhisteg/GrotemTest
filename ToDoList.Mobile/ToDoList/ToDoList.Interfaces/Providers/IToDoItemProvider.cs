using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoList.Core.Models.ToDoItem;

namespace ToDoList.Core.Interfaces.Providers
{
    public interface IToDoItemProvider
    {
        Task<IEnumerable<ToDoItemModel>> GetAll();
        Task<IEnumerable<ToDoItemModel>> GetItemsWithStatus(ToDoItemStatus itemStatus);
        Task<bool> AddItem(ToDoItemModel item);
        Task<bool> UpdateItem(ToDoItemModel item);
        Task<ToDoItemModel> GetItem(Guid uid);

    }
}
