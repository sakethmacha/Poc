namespace MovieBooker.Application.DTOs
{
    public class SeatDto
    {
        public int Id { get; set; }
        public int ScreenId { get; set; }
        public string SeatNumber { get; set; } = string.Empty;
        public bool IsBooked { get; set; }
    }
}
