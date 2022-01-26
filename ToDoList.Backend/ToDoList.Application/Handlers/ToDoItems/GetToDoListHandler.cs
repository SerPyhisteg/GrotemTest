using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ToDoList.Application.Handlers.Common;
using ToDoList.Application.Repository;
using ToDoList.Application.Repository.Entity;
using ToDoList.ServiceModel.ItemList;
using ToDoList.ServiceModel.ToDoItem;

namespace ToDoList.Application.Handlers.ToDoList
{
    public class GetToDoListHandler : IRequestHandler<GetToDoListQuery, ToDoItemListResponse>
    {
        private static readonly Lazy<IMapper> _mapper = new Lazy<IMapper>(CreateMapper());
        private static IMapper Mapper => _mapper.Value;

        private readonly IToDoRepository _toDoRepository;

        public GetToDoListHandler(IToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }

        public async Task<ToDoItemListResponse> Handle(GetToDoListQuery request, CancellationToken cancellationToken)
        {
            var items = await _toDoRepository.GetAllToDoItems();

            return ToModel(items);
        }

        private ToDoItemListResponse ToModel(IEnumerable<ToDoItemEntity> toDoItems)
        {
            var items = toDoItems
                .OrderBy(item => item.ID)
                .Select(ToModel);

            return new ToDoItemListResponse()
            {
                ToDoItems = items
            };
        }

        private ToDoItemModel ToModel(ToDoItemEntity itemEntity)
        {
            return Mapper.Map<ToDoItemModel>(itemEntity);
        }

        private static IMapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg => { cfg.AddProfile<ToDoItemMapperProfile>(); });
            return config.CreateMapper();
        }
    }
}
