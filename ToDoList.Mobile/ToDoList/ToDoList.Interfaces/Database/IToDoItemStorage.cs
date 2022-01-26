using System;
using System.Collections.Generic;
using ToDoList.Core.Models.ToDoItem;

namespace ToDoList.Core.Interfaces.Database
{
    public interface IToDoItemStorage
    {
        IEnumerable<ToDoItemModel> GetAllItems();
        void SaveAllItems(IEnumerable<ToDoItemModel> items);
        void SaveItem(ToDoItemModel item);
        void UpdateItem(ToDoItemModel item);
        ToDoItemModel GetItem(Guid uid);
    }
}
