using MyTodoApp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyTodoApp.Core.BusinessRules
{
    public interface ICategoryBR
    {
        Task Add(Category category);

        Task<IEnumerable<Category>> GetAll();
    }
}