using MovieBooker.Application.DTOs;
using MovieBooker.Application.Interfaces;
using MovieBooker.Domain.Entities;
using MovieBooker.Infrastructure.Interfaces;

namespace MovieBooker.Application.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository BookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            BookingRepository = bookingRepository;
        }

        public async Task<BookingDto> BookAsync(CreateBookingDto dto)
        {
            var booking = new Booking
            {
                ShowTimeId = dto.ShowTimeId,
                CustomerName = dto.CustomerName,
                BookedAt = DateTime.UtcNow
            };

            var result = await BookingRepository.BookAsync(booking, dto.SeatIds);

            return new BookingDto
            {
                Id = result.Id,
                Movie = result.ShowTime.Movie.Title,
                Seats = result.BookingSeats
                    .Select(bs => bs.Seat.SeatNumber)
                    .ToList()
            };
        }


        public async Task<BookingDto?> GetAsync(int id)
        {
            var b = await BookingRepository.GetAsync(id);
            if (b == null) return null;

            return new BookingDto
            {
                Id = b.Id,
                Movie = b.ShowTime.Movie.Title,

                // ✅ MULTIPLE SEATS
                Seats = b.BookingSeats
                    .Select(bs => bs.Seat.SeatNumber)
                    .ToList(),

                IsCancelled = b.IsCancelled
            };
        }


        public Task CancelAsync(int id) => BookingRepository.CancelAsync(id);
    }

}
