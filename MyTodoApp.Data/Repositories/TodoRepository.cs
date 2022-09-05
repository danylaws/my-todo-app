using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MyTodoApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyTodoApp.Data.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoAppDbContext _context;

        public TodoRepository(TodoAppDbContext context) => this._context = context;

        public async Task Add(Todo todo)
        {
            EntityEntry<Todo> entityEntry = await this._context.Todos.AddAsync(todo);
            this._context.SaveChanges();
        }

        public async Task<IEnumerable<Todo>> GetAll()
        {
            List<Todo> listAsync = await this._context.Todos.Include<Todo, Category>((Expression<Func<Todo, Category>>)(t => t.Category)).ToListAsync<Todo>();
            return (IEnumerable<Todo>)listAsync;
        }
    }
}