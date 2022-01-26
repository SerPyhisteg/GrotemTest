using AutoMapper;
using SQLite;
using System;
using System.IO;
using ToDoList.Core.Interfaces.Database;
using ToDoList.Core.Interfaces.Services;
using ToDoList.Core.Models;
using ToDoList.Database.Entities;
using ToDoList.Database.Mapping;

namespace ToDoList.Database.Storage
{
    public partial class DatabaseStorage : IDatabaseStorage
    {
        private static readonly Lazy<IMapper> _mapper = new Lazy<IMapper>(CreateMapper);

        private static IMapper Mapper => _mapper.Value;

        private readonly IFileLocatorService _fileLocatorService;

        public DatabaseStorage(IFileLocatorService fileLocatorService)
        {
            _fileLocatorService = fileLocatorService;
        }

        public void Init()
        {
            using (var connection = Connection)
            {
                connection.CreateTable<ToDoItemEntity>();
            }
        }

        private SQLiteConnection Connection
        {
            get
            {
                string pathToDatabase = Path.Combine(_fileLocatorService.ApplicationDataFolderPath, Constants.DatabaseFilename);
                return new SQLiteConnection(pathToDatabase);
            }
        }

        private static IMapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg => { cfg.AddProfile<ToDoItemMapperProfile>(); });
            return config.CreateMapper();
        }
    }
}
