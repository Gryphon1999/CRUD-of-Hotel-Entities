﻿using HotelWebSystem.DAL;
using HotelWebSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelWebSystem.Controllers
{
    public class CustomerController : Controller
    {
        private readonly HotelDbcontext db;
        public CustomerController(HotelDbcontext context)
        {
            db = context;
        }
        // GET: CustomerController
        public ActionResult Index()
        {
            var data = db.customers.ToList();
            return View(data);
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            var data = db.customers.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer model)
        {
            try
            {
                db.customers.Add(model);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = db.customers.Find(id);
            return View(data);
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Customer model)
        {
            try
            {
                var data = db.customers.Find(id);
                data.Name = model.Name;
                data.Address = model.Address;
                data.PhoneNumber = model.PhoneNumber;
                db.customers.Update(data);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = db.customers.Find(id);
            return View(data);
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Customer model)
        {
            try
            {
                var data = db.customers.Find(id);
                data.Name = model.Name;
                data.Address = model.Address;
                data.PhoneNumber = model.PhoneNumber;
                db.customers.Remove(data);
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