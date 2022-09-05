using MyTodoApp.Data.Repositories;
using MyTodoApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyTodoApp.Core.BusinessRules
{
    public class CategoryBR : ICategoryBR
    {
        private readonly ICategoryRepository _repo;

        public CategoryBR(ICategoryRepository repo) => _repo = repo;

        public async Task Add(Category category)
        {
            category.Id = Guid.NewGuid().ToString();
            await _repo.Add(category);
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            IEnumerable<Category> all = await _repo.GetAll();
            return all;
        }
    }
}