using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using ToDoList.Application.Handlers.ToDoList;

namespace ToDoList.Backend.Container
{
    internal class RegisterMediatR : IServiceRegistration
    {
        public void RegisterAppServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(typeof(GetToDoListHandler).GetTypeInfo().Assembly);
        }
    }
}