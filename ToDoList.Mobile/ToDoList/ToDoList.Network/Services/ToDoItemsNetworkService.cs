using AutoMapper;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoList.Core.Interfaces.Network;
using ToDoList.Core.Models;
using ToDoList.Core.Models.ToDoItem;
using ToDoList.Network.Factories;
using ToDoList.Network.Mapping;
using ToDoList.Network.ServiceModel;

namespace ToDoList.Network.Services
{
    public class ToDoItemsNetworkService : IToDoItemsNetworkService
    {
        private static readonly Lazy<IMapper> _mapper = new Lazy<IMapper>(CreateMapper);

        private static IMapper Mapper => _mapper.Value;

        private readonly IFlurlClient _httpClient;
        private IFlurlClient HttpClient
        {
            get
            {
                _httpClient.BaseUrl = Constants.ServerUrl;
                return _httpClient;
            }
        }



        public ToDoItemsNetworkService()
        {
            var factory = new FlurlClientFactory();
            _httpClient = factory.Get(Constants.ServerUrl);
        }

        public async Task<IEnumerable<ToDoItemModel>> GetAll()
        {
            var result = await HttpClient
                    .Request("items")
                    .GetJsonAsync<ApiToDoItemListResponse>();

            return ToModel(result);
        }

        public async Task<bool> AddItem(ToDoItemModel item)
        {
            var request = ToModel(item);

            var result = await HttpClient
                .Request("item/add")
                .PostJsonAsync(request)
                .ReceiveJson<ApiSuccessResponse>();

            return result.IsSuccess;
        }

        public async Task<bool> UpdateItem(ToDoItemModel item)
        {
            var request = ToModel(item);

            var result = await HttpClient
                .Request("item/update")
                .PostJsonAsync(request)
                .ReceiveJson<ApiSuccessResponse>();

            return result.IsSuccess;
        }

        private IEnumerable<ToDoItemModel> ToModel(ApiToDoItemListResponse response)
        {
            return Mapper.Map<IEnumerable<ToDoItemModel>>(response.ToDoItems);
        }

        private ApiAddOrUpdateToDoItemRequest ToModel(ToDoItemModel item)
        {
            var request = new ApiAddOrUpdateToDoItemRequest()
            {
                ToDoItem = Mapper.Map<ApiToDoItemModel>(item)
            };

            return request;
        }

        private static IMapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg => { cfg.AddProfile<ToDoItemMapperProfile>(); });
            return config.CreateMapper();
        }
    }
}
