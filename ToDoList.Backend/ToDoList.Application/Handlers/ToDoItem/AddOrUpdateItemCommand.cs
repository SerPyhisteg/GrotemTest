using MediatR;
using ToDoList.ServiceModel.Common;
using ToDoList.ServiceModel.ToDoItem;

namespace ToDoList.Application.Handlers.ToDoItem
{
    public class AddOrUpdateItemCommand : IRequest<SuccessResponse>
    {
        public ToDoItemModel ToDoItem { get; set; }
    }
}
