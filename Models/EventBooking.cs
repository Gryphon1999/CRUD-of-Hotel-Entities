using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelWebSystem.Models
{
    public class EventBooking
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Number { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}