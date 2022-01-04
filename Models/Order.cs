using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelWebSystem.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string RoomNum { get; set; }
        public string Price { get; set; }
        public int Quantity { get; set; }
        public int OrderTypeId { get; set; }
        public OrderType OrderType { get; set; }


    }
}
