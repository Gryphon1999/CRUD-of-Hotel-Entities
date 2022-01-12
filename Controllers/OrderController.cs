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
    public class OrderController : Controller
    {
        private readonly HotelDbcontext context;

        public OrderController(HotelDbcontext _context)
        {
            context = _context;
        }

        public IActionResult Index()
        {
            var data = context.orders.Include(x => x.OrderType).ToList();
            return View(data);
        }
        public IActionResult Create()
        {
            ViewData["orderType"] = context.orderTypes.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Order order)
        {
            context.orders.Add(order);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            var model = context.orders.Include(s => s.OrderType).FirstOrDefault(x => x.Id == id);
            ViewData["orderType"] = context.orderTypes.ToList();
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(Order order)
        {
            context.orders.Update(order);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            var model = context.orders.Find(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var order = context.orders.Find(id);
            context.orders.Remove(order);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


    }
}