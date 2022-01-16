using HotelWebSystem.DAL;
using HotelWebSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> Index(string searchItems,int pageNumber=1)
        {

            var data = db.customers
            .Include(c => c.CustomerEmployees)
            .ThenInclude(c => c.Employee)
            .OrderByDescending(p => p.Id);
            return View(await PaginatedList<Customer>.CreateAsync(data,pageNumber,5));
        }
        
        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            var data = db.customers.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }

        // GET: CustomerController/Create
        public ActionResult Create(int id)
        {
            var customer = new Customer();
            if (id == 0)
            {
                ViewData["employee"] = db.employees.ToList();
                return View(customer);
            }
            else
            {
                ViewData["employee"] = db.employees.ToList();
                var model = db.customers.Include(p => p.CustomerEmployees).FirstOrDefault(x => x.Id == id);
                return View(model);
            }
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int id, Customer customer, int[] SelectedEmpIds)
        {
            try
            {
                if (customer.Id == 0)
                {
                    foreach (var item in SelectedEmpIds)
                    {
                        customer.CustomerEmployees.Add(new CustomerEmployee { EmployeeId = item });
                    }
                    db.customers.Add(customer);
                    db.SaveChanges();

                }
                else
                {
                    var data = db.customers.Include(p => p.CustomerEmployees).FirstOrDefault(x => x.Id == id);
                    //remove selected category
                    var removeCustomer = new List<CustomerEmployee>();
                    foreach (var item in data.CustomerEmployees)
                    {
                        if (!SelectedEmpIds.Contains(item.EmployeeId))
                        {
                            removeCustomer.Add(item);
                        }
                    }
                    //remove oldselect
                    foreach (var item in removeCustomer)
                    {
                        db.customerEmployees.Remove(item);
                    }
                    //add new selected Category
                    foreach (var item in SelectedEmpIds)
                    {
                        if (!data.CustomerEmployees.Any(pc => pc.EmployeeId == item))
                            data.CustomerEmployees.Add(new CustomerEmployee { EmployeeId = item, CustomerId = customer.Id });
                    }
                    data.Name = customer.Name;
                    data.Address = customer.Address;
                    data.PhoneNumber = customer.PhoneNumber;
                    db.SaveChanges();
                }
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
