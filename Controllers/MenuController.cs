using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using HotelWebSystem.DAL;
using HotelWebSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HotelWebSystem.Controllers
{
    public class MenuController : Controller
    {
        private readonly HotelDbcontext context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public MenuController(HotelDbcontext _context, IWebHostEnvironment webHostEnvironment)
        {
            context = _context;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var data = context.menus.Include(x => x.Category).ToList();
            return View(data);
        }
        public ActionResult Details(int id)
        {
            var data = context.menus.Include(x => x.Category).Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }
        public IActionResult Create()
        {
            ViewData["categories"] = context.categories.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Menu menu)
        {
            var folder = "menuImg/";
            folder += Guid.NewGuid().ToString() + menu.ImgFile.FileName;
            menu.ImgPath = folder;
            var serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
            using (var fileStream = new FileStream(serverFolder, FileMode.Create))
            {
                menu.ImgFile.CopyTo(fileStream);
            }
            context.menus.Add(menu);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            var data = context.menus.Find(id);
            ViewData["categories"] = context.categories.ToList();
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(int id, Menu menu)
        {
            var model = context.menus.Find(id);
            var OldImgPath = Path.Combine(_webHostEnvironment.WebRootPath, model.ImgPath);
            if (System.IO.File.Exists(OldImgPath))
            {
                System.IO.File.Delete(OldImgPath);
            }
            var folder = "menuImg/";
            folder += Guid.NewGuid().ToString() + menu.ImgFile.FileName;
            menu.ImgPath = folder;
            var serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
            using (var fileStream = new FileStream(serverFolder, FileMode.Create))
            {
                menu.ImgFile.CopyTo(fileStream);
            }
            model.Name = menu.Name;
            model.Description = menu.Description;
            model.Price = menu.Price;
            model.ImgPath = menu.ImgPath;
            model.CategoryId = menu.CategoryId;
            context.menus.Update(model);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            var data = context.menus.Include(x => x.Category).Where(x=>x.Id==id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var data = context.menus.Find(id);
            context.menus.Remove(data);
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