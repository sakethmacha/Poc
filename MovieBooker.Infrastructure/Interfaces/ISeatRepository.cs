using MovieBooker.Domain.Entities;

namespace MovieBooker.Infrastructure.Interfaces
{
    public interface ISeatRepository
    {
        Task<List<Seat>> GetAvailableSeatsByShowTimeAsync(int showTimeId);
    }

}
