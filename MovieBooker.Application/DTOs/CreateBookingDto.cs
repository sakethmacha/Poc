namespace MovieBooker.Application.DTOs
{
    public class CreateBookingDto
    {
        public int ShowTimeId { get; set; }
        public string CustomerName { get; set; }

        // ⭐ MULTIPLE SEATS
        public List<int> SeatIds { get; set; } = new();
    }


}
