using MovieBooker.Domain.Entities;
using MovieBooker.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using MovieBooker.Infrastructure.Interfaces;
namespace MovieBooker.Infrastructure.Repositories
{
    public class SeatRepository : ISeatRepository
    {
        private readonly MovieBookerDbContext DbContext;

        public SeatRepository(MovieBookerDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<List<Seat>> GetAvailableSeatsByShowTimeAsync(int showTimeId)
        {
            // 1️ Get screenId from showtime
            var showTime = await DbContext.ShowTimes
                .AsNoTracking()
                .FirstOrDefaultAsync(st => st.Id == showTimeId);

            if (showTime == null)
            {
                return new List<Seat>();
            }

            // 2️ Get available seats for that screen
            return await DbContext.Seats
                .Where(s => s.ScreenId == showTime.ScreenId && !s.IsBooked)
                .AsNoTracking()
                .ToListAsync();
        }

    }
}
