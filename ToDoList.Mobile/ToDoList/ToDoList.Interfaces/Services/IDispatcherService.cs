using System;

namespace ToDoList.Core.Interfaces.Services
{
    public interface IDispatcherService
    {
        void RunOnUIThread(Action action);
    }
}
