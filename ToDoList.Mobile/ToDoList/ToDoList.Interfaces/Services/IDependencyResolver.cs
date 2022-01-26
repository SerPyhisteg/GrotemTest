using System;

namespace ToDoList.Core.Interfaces.Services
{
    public interface IDependencyResolver
    {
        T GetInstance<T>() where T : class;
        object GetInstance(Type objectType);
    }
}
