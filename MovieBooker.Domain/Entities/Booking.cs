namespace MovieBooker.Domain.Entities;

public class Booking
{
    public int Id { get; set; }

    public int ShowTimeId { get; set; }
    public ShowTime? ShowTime { get; set; }

    public string CustomerName { get; set; } = string.Empty;
    public DateTime BookedAt { get; set; }
    public bool IsCancelled { get; set; }

    public ICollection<BookingSeat> BookingSeats { get; set; }
        = new List<BookingSeat>();
}
