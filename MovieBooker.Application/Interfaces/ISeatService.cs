using MovieBooker.Domain.Entities;

namespace MovieBooker.Application.Interfaces
{
    public interface ISeatService
    {
        Task<List<Seat>> GetAvailableSeatsAsync(int showTimeId);
    }

}
