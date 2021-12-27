
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
            var list = from a in _context.orders
                       join b in _context.orderTypes
                       on a.OrderTypeId equals b.Id
                       into Order
                       from b in Order.DefaultIfEmpty()
                       select new Order()
                       {
                           Id = a.Id,
                           RoomNum = a.RoomNum,
                           Price = a.Price,
                           Quantity = a.Quantity,
                           OrderTypeId = a.OrderTypeId,
                           OrderTypeName = b==null?"":b.Name
                       };
            return View(list);
        }

        // GET: Order/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.orders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Order/Create
        public IActionResult Create()
        {
            var model = new Order()
            {
                ordertypes = GetAllOrderTypes(),
            };
            return View(model);
            //return View();
        }

        // POST: Order/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RoomNum,Price,Quantity,OrderTypeName")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        // GET: Order/Edit/5
        public IActionResult Edit(int id)
        {
            var order = _context.orders.Find(id);
            order.ordertypes = GetAllOrderTypes();
            return View(order);
        }

        // POST: Order/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RoomNum,Price,Quantity,OrderTypeId")] Order order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
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

            var order = await _context.orders
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

        public IEnumerable<SelectListItem>GetAllOrderTypes()
        {
            return _context.orderTypes.ToList().Select(wh => new SelectListItem()
            {
                Text=wh.Name,
                Value = wh.Id.ToString(),
            });
        }
    }
}
        