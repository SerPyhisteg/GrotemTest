using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ToDoList.Application.Handlers.ToDoList;
using ToDoList.ServiceModel.ItemList;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace ToDoList.Backend.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class ToDoListController : ApiController
    {
        [HttpGet]
        [Route("items")]
        [ProducesResponseType(typeof(ToDoItemListResponse), Status200OK)]
        public async Task<ToDoItemListResponse> GetToDoList()
        {
            var query = new GetToDoListQuery();

            return await Mediator.Send(query);
        }
    }
}