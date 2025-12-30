namespace MovieBooker.Domain.Entities;

public class Booking
{
    public int Id { get; set; }

    public int ShowTimeId { get; set; }
    public ShowTime ShowTime { get; set; }

    public string CustomerName { get; set; } = string.Empty;
    public string SeatNumber { get; set; } = string.Empty;

    public bool IsCancelled { get; set; }
    public DateTime BookedAt { get; set; }
}
