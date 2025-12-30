namespace MovieBooker.Application.DTOs
{
    public class BookingDto
    {
        public int Id { get; set; }
        public string? Movie { get; set; }
        public string? Seat { get; set; }
        public bool IsCancelled { get; set; }
    }

}
