using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using ToDoList.Application.Handlers.Common;
using ToDoList.Application.Repository;
using ToDoList.Application.Repository.Entity;
using ToDoList.ServiceModel.Common;
using ToDoList.ServiceModel.ToDoItem;

namespace ToDoList.Application.Handlers.ToDoItem
{
    public class AddOrUpdateItemHandler : IRequestHandler<AddOrUpdateItemCommand, SuccessResponse>
    {
        private static readonly Lazy<IMapper> _mapper = new Lazy<IMapper>(CreateMapper());
        private static IMapper Mapper => _mapper.Value;


        private readonly IToDoRepository _repository;

        public AddOrUpdateItemHandler(IToDoRepository repository)
        {
            _repository = repository;
        }

        public async Task<SuccessResponse> Handle(AddOrUpdateItemCommand request, CancellationToken cancellationToken)
        {
            var response = new SuccessResponse() { IsSuccess = false };
            var entity = ToModel(request.ToDoItem);
            if (entity == null)
            {
                return response;
            }

            var result = await _repository.AddOrUpdateToDoItem(entity);
            response.IsSuccess = result;
            return response;
        }

        private ToDoItemEntity ToModel(ToDoItemModel item)
        {
            return Mapper.Map<ToDoItemEntity>(item);
        }

        private static IMapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg => { cfg.AddProfile<ToDoItemMapperProfile>(); });
            return config.CreateMapper();
        }
    }
}
