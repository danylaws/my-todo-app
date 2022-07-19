using Microsoft.AspNetCore.Mvc;
using MyTodoApp.Core.BusinessRules;
using MyTodoApp.Domain.Entities;
using MyTodoApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MyTodoApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITodoBR _br;
        private readonly ICategoryBR _categoryBR;

        public HomeController(ITodoBR br, ICategoryBR categoryBR)
        {
            _br = br;
            _categoryBR = categoryBR;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _br.GetAll());
        }

        public async Task<IActionResult> Add()
        {
            return View(await EmptyTodoViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Add(TodoViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var todo = new Todo()
                {
                    CategoryId = vm.CategoryId,
                    Title = vm.Title,
                    Description = vm.Description,
                    ScheduledFor = vm.ScheduledFor
                };

                await _br.Add(todo);

                return RedirectToAction("Index");
            }

            return View(await EmptyTodoViewModel());
        }

        public async Task<TodoViewModel> EmptyTodoViewModel()
        {
            return new TodoViewModel()
            {
                Categories = await _categoryBR.GetAll(),
                ScheduledFor = DateTime.Today
            };
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}