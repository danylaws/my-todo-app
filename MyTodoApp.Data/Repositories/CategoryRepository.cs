using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MyTodoApp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyTodoApp.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly TodoAppDbContext _context;

        public CategoryRepository(TodoAppDbContext context) => this._context = context;

        public async Task Add(Category category)
        {
            EntityEntry<Category> entityEntry = await this._context.Categories.AddAsync(category);
            this._context.SaveChanges();
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            List<Category> listAsync = await this._context.Categories.ToListAsync<Category>();
            return (IEnumerable<Category>)listAsync;
        }
    }
}