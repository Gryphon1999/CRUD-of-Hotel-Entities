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
        public DbSet<Order> orders { get; set; }
        public DbSet<Events> events { get; set; }
        public DbSet<OrderType> orderTypes { get; set; }
        public DbSet<RoomType> roomTypes { get; set; }
        public DbSet<CustomerEmployee> customerEmployees {get; set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<CustomerEmployee>().HasKey(x=> new {x.CustomerId,x.EmployeeId});
        }
    }
}
