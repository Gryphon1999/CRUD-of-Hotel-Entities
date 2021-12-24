using HotelWebSystem.DAL;
using HotelWebSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelWebSystem.Controllers
{
    public class OrderTypeController : Controller
    {
        private readonly HotelDbcontext db;
        public OrderTypeController(HotelDbcontext context)
        {
            db=context;
        }

        // GET: OrderTypeController
        public ActionResult Index()
        {
            var data = db.orderTypes.ToList();
            return View(data);
        }

        // GET: OrderTypeController/Details/5
        public ActionResult Details(int id)
        {
            var data = db.orderTypes.Find(id);
            return View(data);
        }

        // GET: OrderTypeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderType model)
        {
            try
            {
                db.orderTypes.Add(model);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderTypeController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = db.orderTypes.Find(id);
            return View(data);
        }

        // POST: OrderTypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, OrderType model)
        {
            try
            {
                var data = db.orderTypes.Find(id);
                data.Name = model.Name;
                db.orderTypes.Update(data);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderTypeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderTypeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
