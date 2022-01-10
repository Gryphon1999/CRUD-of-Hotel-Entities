using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelWebSystem.Models
{
    public class CustomerEmployee
    {
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public Customer Customer {get; set;}
        public Employee Employee {get; set;}
    }
}