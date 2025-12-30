namespace MovieBooker.Domain.Entities;

public class Screen
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public int CinemaId { get; set; }
    public Cinema? Cinema { get; set; }
}
