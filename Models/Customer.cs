using System.Collections.ObjectModel;

namespace HotelWebSystem.Models
{
    public class Customer
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public ICollection<CustomerEmployee> CustomerEmployees { get; set; }
        public Customer()
        {
            CustomerEmployees = new Collection<CustomerEmployee>();
        }
    }
}
