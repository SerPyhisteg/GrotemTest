using System.Collections.Generic;
using ToDoList.ServiceModel.ToDoItem;

namespace ToDoList.ServiceModel.ItemList
{
    public class ToDoItemListResponse
    {
        public IEnumerable<ToDoItemModel> ToDoItems { get; set; }
    }
}
