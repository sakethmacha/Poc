namespace MovieBooker.Application.DTOs
{
    public class CreateBookingDto
    {
        public int ShowTimeId { get; set; }
        public string? CustomerName { get; set; }
        public string? SeatNumber { get; set; }
    }

}
