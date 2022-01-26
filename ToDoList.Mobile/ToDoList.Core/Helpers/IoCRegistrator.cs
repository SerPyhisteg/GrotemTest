using SimpleInjector;
using ToDoList.Core.Interfaces.Database;
using ToDoList.Core.Interfaces.Network;
using ToDoList.Core.Interfaces.Providers;
using ToDoList.Core.Interfaces.Services;
using ToDoList.Core.Providers;
using ToDoList.Core.Services;
using ToDoList.Core.ViewModels;
using ToDoList.Database.Storage;
using ToDoList.Network.Services;

namespace ToDoList.Core.Helpers
{
    public static class IoCRegistrator
    {
        public static void Register(Container container)
        {
            //network
            container.Register<IToDoItemsNetworkService, ToDoItemsNetworkService>(Lifestyle.Singleton);

            //services
            container.Register<IFileLocatorService, FileLocatorService>(Lifestyle.Singleton);

            //providers
            container.Register<IToDoItemProvider, ToDoItemProvider>(Lifestyle.Singleton);

            //database
            var databaseRegistration = Lifestyle.Singleton.CreateRegistration<DatabaseStorage>(container);
            container.AddRegistration<IDatabaseStorage>(databaseRegistration);
            container.AddRegistration<IToDoItemStorage>(databaseRegistration);

            //viewModels
            container.Register<ToDoListViewModel>(Lifestyle.Transient);
            container.Register<ToDoItemViewModel>(Lifestyle.Transient);
        }
    }
}
