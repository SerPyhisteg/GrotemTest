using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ToDoList.Application.Handlers.ToDoItem;
using ToDoList.ServiceModel.Common;
using ToDoList.ServiceModel.ToDoItem;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace ToDoList.Backend.Controllers
{
    [ApiController]
    [Route("item")]
    [Produces("application/json")]
    public class ItemController : ApiController
    {
        [HttpPost]
        [Route("add")]
        [ProducesResponseType(typeof(SuccessResponse), Status200OK)]
        public async Task<SuccessResponse> AddItem(AddOrUpdateItemRequest request)
        {
            var command = new AddOrUpdateItemCommand()
            {
                ToDoItem = request.ToDoItem
            };

            return await Mediator.Send(command);
        }

        [HttpPost]
        [Route("update")]
        [ProducesResponseType(typeof(SuccessResponse), Status200OK)]
        public async Task<SuccessResponse> UpdateItem(AddOrUpdateItemRequest request)
        {
            var command = new AddOrUpdateItemCommand()
            {
                ToDoItem = request.ToDoItem
            };

            return await Mediator.Send(command);
        }
    }
}
