using System.ComponentModel.DataAnnotations;

namespace HotelWebSystem.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeAddress { get; set; }
        public string EmployeeNumber { get; set; } 
        public double EmployeeSalary { get; set; }
        public string EmployeePost { get; set; }
    }
}
