using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelWebSystem.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeAddress { get; set; }
        public string EmployeeNumber { get; set; } 
        public decimal EmployeeSalary { get; set; }
        public string EmployeePost { get; set; }
        public string ImgPath { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
