using ToDoList.Core.Models.Common;

namespace ToDoList.Core.Interfaces.Services
{
    public interface INavigationService
    {
        void GoToPage(ModelState state, string parameter = null);
    }
}
