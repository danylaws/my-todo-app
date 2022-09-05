using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyTodoApp.Data.Repositories;

namespace MyTodoApp.Core.BusinessRules
{
    public static class DependenciesRegistration
    {
        public static IServiceCollection RegisterDependencies(
          this IServiceCollection services,
          IConfiguration configuration)
        {
            services.AddScoped<ICategoryBR, CategoryBR>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ITodoBR, TodoBR>();
            services.AddScoped<ITodoRepository, TodoRepository>();
            return services;
        }
    }
}