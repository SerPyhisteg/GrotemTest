using System;
using ToDoList.ServiceModel.ToDoItem;

namespace ToDoList.Application.Repository.Entity
{
    public class ToDoItemEntity
    {
        public int ID { get; set; }
        public Guid UID { get; set; }
        public string Description { get; set; }
        public ToDoItemStatus Status { get; set; }
    }
}
