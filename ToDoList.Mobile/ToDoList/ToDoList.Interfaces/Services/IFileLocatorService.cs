namespace ToDoList.Core.Interfaces.Services
{
    public interface IFileLocatorService
    {
        string ApplicationDataFolderPath { get; }
    }
}
