using AutoMapper;
using ToDoList.Core.Models.ToDoItem;
using ToDoList.Network.ServiceModel;

namespace ToDoList.Network.Mapping
{
    public class ToDoItemMapperProfile : Profile
    {
        public ToDoItemMapperProfile()
        {
            CreateMap<ToDoItemModel, ApiToDoItemModel>();
            CreateMap<ApiToDoItemModel, ToDoItemModel>();
        }
    }
}
