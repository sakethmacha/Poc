using MovieBooker.Domain.Entities;
namespace MovieBooker.Infrastructure.Interfaces
{
    public interface IBookingRepository
    {
        Task<Booking> BookAsync(Booking booking);
        Task<Booking?> GetAsync(int id);
        Task CancelAsync(int id);
    }

}
