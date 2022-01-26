using SQLite;
using System;

namespace ToDoList.Database.Entities
{
    [Table("ToDoItems")]
    public class ToDoItemEntity
    {
        [AutoIncrement]
        [PrimaryKey]
        public int Id { get; set; }
        public Guid UID { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
    }
}
