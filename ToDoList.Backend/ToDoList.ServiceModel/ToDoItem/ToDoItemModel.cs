using System;

namespace ToDoList.ServiceModel.ToDoItem
{
    public class ToDoItemModel
    {
        public Guid UID { get; set; }
        public string Description { get; set; }
        public ToDoItemStatus Status { get; set; }
    }
}
