using MovieBooker.Application.DTOs;

namespace MovieBooker.Application.Interfaces
{
    public interface IBookingService
    {
        Task<BookingDto> BookAsync(CreateBookingDto dto);
        Task<BookingDto?> GetAsync(int id);
        Task CancelAsync(int id);
    }

}
