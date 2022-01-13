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
    public class ReservationController : Controller
    {
        private readonly HotelDbcontext _context;

        public ReservationController(HotelDbcontext context)
        {
            _context = context;
        }

        // GET: Booking
        public IActionResult Index()
        {
            var data = _context.reservations.Include(x=>x.RoomType).ToList();
            return View(data);
        }

        // GET: Booking/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.reservations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // GET: Booking/Create
        public IActionResult Create(int id)
        {
            var reservation = new Reservation();
            if (id == 0)
            {
                ViewData["roomType"] = _context.roomTypes.ToList();
                return View(reservation);
            }
            else
            {
                ViewData["roomType"] = _context.roomTypes.ToList();
                var model = _context.reservations.Find(id);
                return View(model);
            }
        }

        // POST: Booking/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id, Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                if (reservation.Id == 0)
                {
                    _context.Add(reservation);
                }
                else
                {
                    _context.Update(reservation);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reservation);
        }

        // GET: Booking/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.reservations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // POST: Booking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservation = await _context.reservations.FindAsync(id);
            _context.reservations.Remove(reservation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingExists(int id)
        {
            return _context.reservations.Any(e => e.Id == id);
        }
    }
}
