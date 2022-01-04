using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotelWebSystem.DAL;
using HotelWebSystem.Models;

namespace HotelWebSystem.Controllers
{
    public class AssignController : Controller
    {
        private readonly HotelDbcontext _context;

        public AssignController(HotelDbcontext context)
        {
            _context = context;
        }

        // GET: Assign
        public async Task<IActionResult> Index()
        {
            var hotelDbcontext = _context.assigns.Include(a => a.Customer).Include(a => a.Employee);
            return View(await hotelDbcontext.ToListAsync());
        }

        // GET: Assign/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assign = await _context.assigns
                .Include(a => a.Customer)
                .Include(a => a.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assign == null)
            {
                return NotFound();
            }

            return View(assign);
        }

        // GET: Assign/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.customers, "Id", "Name");
            ViewData["EmployeeId"] = new SelectList(_context.employees, "EmployeeId", "EmployeeName");
            return View();
        }

        // POST: Assign/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CustomerId,EmployeeId")] Assign assign)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assign);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(assign);
        }

        // GET: Assign/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assign = await _context.assigns.FindAsync(id);
            if (assign == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.customers, "Id", "Name", assign.CustomerId);
            ViewData["EmployeeId"] = new SelectList(_context.employees, "EmployeeId", "EmployeeName", assign.EmployeeId);
            return View(assign);
        }

        // POST: Assign/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CustomerId,EmployeeId")] Assign assign)
        {
            if (id != assign.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assign);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssignExists(assign.Id))
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
            return View(assign);
        }

        // GET: Assign/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assign = await _context.assigns
                .Include(a => a.Customer)
                .Include(a => a.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assign == null)
            {
                return NotFound();
            }

            return View(assign);
        }

        // POST: Assign/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assign = await _context.assigns.FindAsync(id);
            _context.assigns.Remove(assign);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssignExists(int id)
        {
            return _context.assigns.Any(e => e.Id == id);
        }
    }
}
