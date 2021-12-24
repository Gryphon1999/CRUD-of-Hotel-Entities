namespace HotelWebSystem.Models
{
    public class Events
    {
        public int Id { get; set; }
        public string EventType { get; set; }
        public int Price { get; set; }
        public string Location { get; set; }
        public DateTime Time { get; set; }
    }
}
