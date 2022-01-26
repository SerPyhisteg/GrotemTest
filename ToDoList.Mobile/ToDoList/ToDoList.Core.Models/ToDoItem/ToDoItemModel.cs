using System;

namespace ToDoList.Core.Models.ToDoItem
{
    public class ToDoItemModel
    {
        public int Id { get; set; }
        public Guid UID { get; set; }
        public string Description { get; set; }
        public ToDoItemStatus Status { get; set; }
    }
}
