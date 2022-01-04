
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotelWebSystem.DAL;
using HotelWebSystem.Models;

namespace HotelWebSystem.Controllers
{
    public class OrderController : Controller
    {
        private readonly HotelDbcontext _context;

        public OrderController(HotelDbcontext context)
        {
            _context = context;
        }

        // GET: Order
        public ActionResult Index()
        {
            var list = _context.orders.Include(x=>x.OrderType).ToList();
            return View(list);
        }

        // GET: Order/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.orders.Include(s=>s.OrderType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Order/Create
        public IActionResult Create(int id)
        {
            ViewData["orderTypes"]=_context.orderTypes.ToList();
            var model = _context.orders.Find(id);
            return View(model);
            //return View();
        }

        // POST: Order/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id,[Bind("Id,RoomNum,Price,Quantity,OrderTypeName")] Order order)
        {
            if (ModelState.IsValid)
            {
                if (order.Id==0)
                {
                    _context.Add(order);
                }
                _context.Update(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        // GET: Order/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.orders.Include(s=>s.OrderType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.orders.FindAsync(id);
            _context.orders.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.orders.Any(e => e.Id == id);
        }

    }
}
        