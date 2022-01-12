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
            db = context;
        }

        // GET: OrderTypeController
        public ActionResult Index(string searchItems)
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
        public ActionResult Create(int id)
        {
            if (id == 0)
            {
                return View();
            }
            else
            {
                var model = db.orderTypes.Find(id);
                return View(model);
            }
        }

        // POST: OrderTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int id, OrderType model)
        {
            try
            {
                if (model.Id == 0)
                {
                    db.orderTypes.Add(model);
                }
                else
                {
                    db.orderTypes.Update(model);
                }
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
            var model = db.orderTypes.Find(id);
            return View(model);
        }

        // POST: OrderTypeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var model = db.orderTypes.Find(id);
                db.orderTypes.Remove(model);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
