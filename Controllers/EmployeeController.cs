using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HotelWebSystem.Models;
using HotelWebSystem.DAL;

namespace HotelWebSystem.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly HotelDbcontext db;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EmployeeController(HotelDbcontext context, IWebHostEnvironment webHostEnvironment)
        {
            db = context;
            _webHostEnvironment = webHostEnvironment;
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
        public ActionResult Save(int id)
        {
            var model = new Employee();
            if (id==0)
            {
                return View(model);
            }
            model = db.employees.Find(id);
            return View(model);
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(int id,Employee employee)
        {
            try
            {
                if (employee.EmployeeId==0)
                {
                    var folder = "img/";
                    var extension = Path.GetExtension(employee.ImageFile.FileName);
                    folder += Guid.NewGuid().ToString() + employee.ImageFile.FileName;
                    IFormFile formFile = employee.ImageFile;
                    long size = formFile.Length;
                    if (extension.ToLower()==".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".png")
                    {
                        if (size<=1000000)
                        {
                            employee.ImgPath = folder;
                            var serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                            using (var fileStream = new FileStream(serverFolder, FileMode.Create))
                            {
                                employee.ImageFile.CopyTo(fileStream);
                            }
                            db.employees.Add(employee);
                        }
                        else
                        {
                            TempData["SizeMessage"] = "<script>alert('File Size Less than 1MB!')</script>";
                            return View(employee);
                        }
                    }
                    else
                    {
                        TempData["ExtensionMessage"] = "<script>alert('File Formate Not Supported')</script>";
                        return View(employee);
                    }
                }
                else
                {
                    var model = db.employees.Find(id);
                    var OldImgPath = Path.Combine(_webHostEnvironment.WebRootPath, model.ImgPath);
                    if (System.IO.File.Exists(OldImgPath))
                    {
                        System.IO.File.Delete(OldImgPath);
                    }
                    var folder = "img/";
                    var extension = Path.GetExtension(employee.ImageFile.FileName);
                    folder += Guid.NewGuid().ToString() + employee.ImageFile.FileName;
                    IFormFile formFile = employee.ImageFile;
                    long size = formFile.Length;
                    if (extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".png")
                    {
                        if (size <= 1000000)
                        {
                            employee.ImgPath = folder;
                            var serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                            using (var fileStream = new FileStream(serverFolder, FileMode.Create))
                            {
                                employee.ImageFile.CopyTo(fileStream);
                            }
                            model.EmployeeName = employee.EmployeeName;
                            model.EmployeeAddress = employee.EmployeeAddress;
                            model.EmployeeNumber = employee.EmployeeNumber;
                            model.EmployeeSalary = employee.EmployeeSalary;
                            model.EmployeePost = employee.EmployeePost;
                            model.ImgPath = folder;
                            db.employees.Update(model);
                        }
                        else
                        {
                            TempData["SizeMessage"] = "<script>alert('File Size Less than 1MB!')</script>";
                            return View(model);
                        }
                    }
                    else
                    {
                        TempData["ExtensionMessage"] = "<script>alert('File Formate Not Supported')</script>";
                        return View(model);
                    }
                }
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
                var model = db.employees.Find(id);
                var OldImgPath = Path.Combine(_webHostEnvironment.WebRootPath, model.ImgPath);
                if (System.IO.File.Exists(OldImgPath))
                {
                    System.IO.File.Delete(OldImgPath);
                }
                db.employees.Remove(model);
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
