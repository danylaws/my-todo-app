using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;
using System;

namespace MyTodoApp.Data
{
    public static class PersistenceRegistration
    {
        public static IServiceCollection RegisterPersistenceServices(
          this IServiceCollection services,
          IConfiguration configuration)
        {
            MySqlConnectionStringBuilder connectionBuilder = new MySqlConnectionStringBuilder(configuration.GetConnectionString("LocalDbConnection"));
            services.AddDbContext<TodoAppDbContext>((Action<DbContextOptionsBuilder>)(options => options.UseMySql(connectionBuilder.ConnectionString)));
            return services;
        }
    }
}