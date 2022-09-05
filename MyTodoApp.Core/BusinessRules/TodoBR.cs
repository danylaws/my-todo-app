using MyTodoApp.Data.Repositories;
using MyTodoApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyTodoApp.Core.BusinessRules
{
    public class TodoBR : ITodoBR
    {
        private readonly ITodoRepository _repo;

        public TodoBR(ITodoRepository repo) => this._repo = repo;

        public async Task Add(Todo todo)
        {
            todo.Id = Guid.NewGuid().ToString();
            todo.CreatedAt = DateTime.Now;
            await this._repo.Add(todo);
        }

        public async Task<IEnumerable<Todo>> GetAll()
        {
            IEnumerable<Todo> all = await this._repo.GetAll();
            return all;
        }
    }
}