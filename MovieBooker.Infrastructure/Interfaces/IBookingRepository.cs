using MovieBooker.Domain.Entities;
namespace MovieBooker.Infrastructure.Interfaces
{
    public interface IBookingRepository
    {
        Task<Booking> BookAsync(Booking booking, List<int> seatIds);
        
            Task<Booking?> GetAsync(int id);
           Task CancelAsync(int id);
    }

}
