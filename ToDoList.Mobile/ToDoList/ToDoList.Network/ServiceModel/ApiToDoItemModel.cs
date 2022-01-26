using System;

namespace ToDoList.Network.ServiceModel
{
    public class ApiToDoItemModel
    {
        public int Id { get; set; }
        public Guid UID { get; set; }
        public string Description { get; set; }
        public ApiToDoItemStatus Status { get; set; }
    }
}
