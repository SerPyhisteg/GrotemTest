using AutoMapper;
using ToDoList.Application.Repository.Entity;
using ToDoList.ServiceModel.ToDoItem;

namespace ToDoList.Application.Handlers.Common
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
