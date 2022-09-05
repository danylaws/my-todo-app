using MyTodoApp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyTodoApp.Data.Repositories
{
    public interface ITodoRepository
    {
        Task Add(Todo todo);

        Task<IEnumerable<Todo>> GetAll();
    }
}