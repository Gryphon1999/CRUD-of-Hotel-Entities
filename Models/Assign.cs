namespace HotelWebSystem.Models
{
    public class Assign
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
