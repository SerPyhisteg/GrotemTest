using MediatR;
using ToDoList.ServiceModel.ItemList;

namespace ToDoList.Application.Handlers.ToDoList
{
    public class GetToDoListQuery : IRequest<ToDoItemListResponse>
    {
    }
}
