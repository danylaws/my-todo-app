using MyTodoApp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyTodoApp.Data.Repositories
{
    public interface ICategoryRepository
    {
        Task Add(Category category);

        Task<IEnumerable<Category>> GetAll();
    }
}