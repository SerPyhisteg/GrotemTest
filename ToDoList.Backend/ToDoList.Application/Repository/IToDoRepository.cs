using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoList.Application.Repository.Entity;

namespace ToDoList.Application.Repository
{
    public interface IToDoRepository
    {
        public Task<List<ToDoItemEntity>> GetAllToDoItems();
        public Task<bool> AddOrUpdateToDoItem(ToDoItemEntity entity);
    }
}