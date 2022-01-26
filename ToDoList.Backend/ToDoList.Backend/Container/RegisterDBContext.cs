using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDoList.Infrastructure.Database;

namespace ToDoList.Backend.Container
{
    internal class RegisterDBContext : IServiceRegistration
    {
        public void RegisterAppServices(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString(nameof(ToDoDBContext));
            services.AddDbContext<ToDoDBContext>(opt => opt.UseNpgsql(connectionString));
            services.AddScoped<ToDoDBContext>();
        }
    }
}
