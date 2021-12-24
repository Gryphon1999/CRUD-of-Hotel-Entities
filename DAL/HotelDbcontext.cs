using HotelWebSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelWebSystem.DAL
{

    public class HotelDbcontext : DbContext
    {
        public HotelDbcontext(DbContextOptions<HotelDbcontext> options) : base(options)
        {
        }
        public DbSet<Employee>employees{get;set;}
        public DbSet<Customer> customers { get; set; }
        public DbSet<Booking> bookings { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<Events> events { get; set; }
        public DbSet<OrderType> orderTypes { get; set; }
    }
}
