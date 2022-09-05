using MyTodoApp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyTodoApp.Core.BusinessRules
{
    public interface ITodoBR
    {
        Task Add(Todo todo);

        Task<IEnumerable<Todo>> GetAll();
    }
}