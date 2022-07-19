using Microsoft.AspNetCore.Mvc;
using MyTodoApp.Core.BusinessRules;
using MyTodoApp.Domain.Entities;
using MyTodoApp.Models;
using System.Threading.Tasks;

namespace MyTodoApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryBR _br;

        public CategoryController(ICategoryBR br)
        {
            _br = br;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _br.GetAll());
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var category = new Category()
                {
                    Name = vm.Name
                };

                await _br.Add(category);

                return RedirectToAction("Index");
            }

            return View();
        }
    }
}