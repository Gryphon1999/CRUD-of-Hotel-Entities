using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using HotelWebSystem.DAL;
using HotelWebSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HotelWebSystem.Controllers
{
    public class CategoryController : Controller
    {
        private readonly HotelDbcontext context;

        public CategoryController(HotelDbcontext _context)
        {
            context = _context;
        }

        public IActionResult Index()
        {
            var data = context.categories.ToList();
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            context.categories.Add(category);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            var data = context.categories.Find(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            context.categories.Update(category);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            var data = context.categories.Find(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var data = context.categories.Find(id);
            context.categories.Remove(data);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}