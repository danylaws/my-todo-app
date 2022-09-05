using Microsoft.EntityFrameworkCore;
using MyTodoApp.Domain.Entities;

namespace MyTodoApp.Data
{
    public class TodoAppDbContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; }

        public DbSet<Category> Categories { get; set; }

        public TodoAppDbContext(DbContextOptions<TodoAppDbContext> options)
          : base((DbContextOptions)options)
        {
        }
    }
}