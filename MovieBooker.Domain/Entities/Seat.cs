namespace MovieBooker.Domain.Entities;

public class Seat
{
    public int Id { get; set; }
    public int ScreenId { get; set; }
    public string SeatNumber { get; set; } = string.Empty;
    public bool IsBooked { get; set; }
}
