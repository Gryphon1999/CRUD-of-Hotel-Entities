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

        public RoomTypeController(HotelDbcontext _context)
        {
            context = _context;
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
        public IActionResult Create(RoomType roomType)
        {
            if (roomType.Id == 0)
            {
                context.roomTypes.Add(roomType);
            }
            else
            {
                context.roomTypes.Update(roomType);
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