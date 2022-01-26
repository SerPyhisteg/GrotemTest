using System.Collections.Generic;

namespace ToDoList.Network.ServiceModel
{
    public class ApiToDoItemListResponse
    {
        public IEnumerable<ApiToDoItemModel> ToDoItems { get; set; }
    }
}
