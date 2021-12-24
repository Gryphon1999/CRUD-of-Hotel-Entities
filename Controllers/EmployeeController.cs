using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HotelWebSystem.Models;
using HotelWebSystem.DAL;

namespace HotelWebSystem.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly HotelDbcontext db;
        public EmployeeController(HotelDbcontext context)
        {
            db = context;
        }

        // GET: EmployeeController
        public ActionResult Index()
        {
            var data = db.employees.ToList();
            return View(data);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            var data = db.employees.Find(id);
            return View(data);
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            try
            {
                    db.employees.Add(employee);
                    db.SaveChanges();
                    return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = db.employees.Find(id);
            return View(data);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Employee employee)
        {
            try
            {
                var data = db.employees.Find(id);
                data.EmployeeName = employee.EmployeeName;
                data.EmployeeAddress = employee.EmployeeAddress;
                data.EmployeeSalary = employee.EmployeeSalary;
                data.EmployeeNumber = employee.EmployeeNumber;
                data.EmployeePost = employee.EmployeePost;
                db.employees.Update(data);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = db.employees.Find(id);
            return View(data);
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Employee employee)
        {
            try
            {
                var data = db.employees.Find(id);
                data.EmployeeName = employee.EmployeeName;
                data.EmployeeAddress = employee.EmployeeAddress;
                data.EmployeeSalary = employee.EmployeeSalary;
                data.EmployeeNumber = employee.EmployeeNumber;
                data.EmployeePost = employee.EmployeePost;
                db.employees.Remove(data);
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
