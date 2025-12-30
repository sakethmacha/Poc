namespace MovieBooker.Application.DTOs
{
    public class ShowTimeDto
    {
        public int ShowTimeId { get; set; }
        public string? Cinema { get; set; }
        public string? Screen { get; set; }
        public DateTime Time { get; set; }
    }

}
