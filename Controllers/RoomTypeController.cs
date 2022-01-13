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
    public class RoomTypeController : Controller
    {
        private readonly HotelDbcontext context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public RoomTypeController(HotelDbcontext _context, IWebHostEnvironment webHostEnvironment)
        {
            context = _context;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var model = context.roomTypes.ToList();
            return View(model);
        }
        public IActionResult Create(int id)
        {
            var roomType = new RoomType();
            if (id == 0)
            {
                return View(roomType);
            }
            else
            {
                var data = context.roomTypes.Find(id);
                return View(data);
            }
        }
        [HttpPost]
        public IActionResult Create(int id, RoomType roomType)
        {
            if (roomType.Id == 0)
            {
                var folder = "roomImg/";
                folder += Guid.NewGuid().ToString() + roomType.ImageFile.FileName;
                roomType.ImgPath = folder;
                var serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                using (var fileStream = new FileStream(serverFolder, FileMode.Create))
                {
                    roomType.ImageFile.CopyTo(fileStream);
                }
                context.roomTypes.Add(roomType);
            }
            else
            {
                var model = context.roomTypes.Find(id);
                var OldImgPath = Path.Combine(_webHostEnvironment.WebRootPath, model.ImgPath);
                if (System.IO.File.Exists(OldImgPath))
                {
                    System.IO.File.Delete(OldImgPath);
                }
                var folder = "roomImg/";
                folder += Guid.NewGuid().ToString() + roomType.ImageFile.FileName;
                roomType.ImgPath = folder;
                var serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                using (var fileStream = new FileStream(serverFolder, FileMode.Create))
                {
                    roomType.ImageFile.CopyTo(fileStream);
                }
                model.Name = roomType.Name;
                model.ImgPath = roomType.ImgPath;
                context.roomTypes.Update(model);
            }
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            var data = context.roomTypes.Find(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var data = context.roomTypes.Find(id);
            var OldImgPath = Path.Combine(_webHostEnvironment.WebRootPath, data.ImgPath);
            if (System.IO.File.Exists(OldImgPath))
            {
                System.IO.File.Delete(OldImgPath);
            }
            context.roomTypes.Remove(data);
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