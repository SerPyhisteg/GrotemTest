using Microsoft.EntityFrameworkCore;
using System;
using ToDoList.Application.Repository.Entity;
using ToDoList.ServiceModel.ToDoItem;

namespace ToDoList.Infrastructure.Database
{
    public class ToDoDBContext : DbContext
    {
        public DbSet<ToDoItemEntity> ToDoItems { get; set; }

        public ToDoDBContext(DbContextOptions options) : base(options)
        {
            Database.Migrate();
        }

        private void CreateTestItems()
        {
            var item = new ToDoItemEntity()
            {
                UID = Guid.NewGuid(),
                Description = "Test ToDo item please ignore",
                Status = ToDoItemStatus.Open
            };
            ToDoItems.Add(item);

            item = new ToDoItemEntity()
            {
                UID = Guid.NewGuid(),
                Description = "Yet Anouther Test ToDo item please ignore",
                Status = ToDoItemStatus.Open
            };
            ToDoItems.Add(item);

            item = new ToDoItemEntity()
            {
                UID = Guid.NewGuid(),
                Description = "Yet Anouther Another Test ToDo item please ignore",
                Status = ToDoItemStatus.Closed
            };
            ToDoItems.Add(item);

            SaveChanges();
        }
    }
}
