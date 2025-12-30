namespace MovieBooker.Application.DTOs
{
    public class BookingDto
    {
        public int Id { get; set; }
        public string Movie { get; set; }
        public List<string> Seats { get; set; } = new();
        public bool IsCancelled { get; set; }
    }

}
