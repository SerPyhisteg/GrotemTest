using ToDoList.Core.Interfaces.Services;
using Xamarin.Essentials;

namespace ToDoList.Core.Services
{
    public class FileLocatorService : IFileLocatorService
    {
        public string ApplicationDataFolderPath => FileSystem.AppDataDirectory;
    }
}
