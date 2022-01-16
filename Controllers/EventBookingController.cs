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
    public class EventBookingController : Controller
    {
        private readonly HotelDbcontext context;

        public EventBookingController(HotelDbcontext _context)
        {
            context = _context;
        }

        public IActionResult Index()
        {
            var data = context.eventBookings.Include(x=>x.Event).ToList();
            return View(data);
        }
        public IActionResult Create()
        {
            ViewData["event"] = context.events.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(EventBooking eventBooking)
        {
            context.eventBookings.Add(eventBooking);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            var data = context.eventBookings.Find(id);
            ViewData["event"] = context.events.ToList();
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(EventBooking eventBooking)
        {
            context.eventBookings.Update(eventBooking);
            context.SaveChanges();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}