using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDoList.Application.Repository;
using ToDoList.Infrastructure.Repository;

namespace ToDoList.Backend.Container
{
    internal class RegisterRepositories : IServiceRegistration
    {
        public void RegisterAppServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IToDoRepository, ToDoRepository>();
        }
    }
}
