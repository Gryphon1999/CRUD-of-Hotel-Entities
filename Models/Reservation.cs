namespace HotelWebSystem.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int RoomTypeId { get; set; }
        public RoomType RoomType { get; set; }
        public int NoOfChilderns { get; set; }
        public int NoOfAdults { get; set; }
        public int NoOfNights { get; set; }




    }
}
