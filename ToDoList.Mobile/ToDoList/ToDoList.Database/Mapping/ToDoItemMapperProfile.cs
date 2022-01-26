using AutoMapper;
using ToDoList.Core.Models.ToDoItem;
using ToDoList.Database.Entities;

namespace ToDoList.Database.Mapping
{
    public class ToDoItemMapperProfile : Profile
    {
        public ToDoItemMapperProfile()
        {
            CreateMap<ToDoItemModel, ToDoItemEntity>();
            CreateMap<ToDoItemEntity, ToDoItemModel>();

        }
    }
}
