using MovieBooker.Application.Interfaces;
using MovieBooker.Domain.Entities;
using MovieBooker.Infrastructure.Interfaces;
namespace MovieBooker.Application.Services
{
    public class SeatService : ISeatService
    {
        private readonly ISeatRepository SeatRepository;

        public SeatService(ISeatRepository seatRepository)
        {
            SeatRepository = seatRepository;
        }

        public async Task<List<Seat>> GetAvailableSeatsAsync(int showTimeId)
        {
            return await SeatRepository.GetAvailableSeatsByShowTimeAsync(showTimeId);
        }
    }

}
