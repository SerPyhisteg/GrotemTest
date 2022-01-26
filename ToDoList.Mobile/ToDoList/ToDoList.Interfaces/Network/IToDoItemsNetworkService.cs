using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoList.Core.Models.ToDoItem;

namespace ToDoList.Core.Interfaces.Network
{
    public interface IToDoItemsNetworkService
    {
        Task<IEnumerable<ToDoItemModel>> GetAll();
        Task<bool> AddItem(ToDoItemModel item);
        Task<bool> UpdateItem(ToDoItemModel item);
    }
}
