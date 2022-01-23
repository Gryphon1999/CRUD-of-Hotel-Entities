using HotelWebSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace HotelWebSystem.DAL
{

    public class HotelDbcontext : DbContext
    {
        public HotelDbcontext(DbContextOptions<HotelDbcontext> options) : base(options)
        {
        }
        public DbSet<Employee>employees{get;set;}
        public DbSet<Customer> customers { get; set; }
        public DbSet<Reservation> reservations { get; set; }
        public DbSet<Event> events { get; set; }
        public DbSet<RoomType> roomTypes { get; set; }
        public DbSet<EventBooking> eventBookings { get; set; }
        public DbSet<CustomerEmployee> customerEmployees {get; set;}
        public DbSet<Category> categories {get; set;}
        public DbSet<Menu> menus {get; set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<CustomerEmployee>().HasKey(x=> new {x.CustomerId,x.EmployeeId});
        }
    }
}
