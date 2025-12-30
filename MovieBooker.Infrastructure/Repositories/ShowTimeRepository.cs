using MovieBooker.Domain.Entities;
using MovieBooker.Infrastructure.DbContexts;
using MovieBooker.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace MovieBooker.Infrastructure.Repositories
{
    public class ShowTimeRepository : IShowTimeRepository
    {
        private readonly MovieBookerDbContext DbContext;

        public ShowTimeRepository(MovieBookerDbContext context)
        {
            DbContext = context;
        }

        public async Task<List<ShowTime>> GetByMovieAsync(int movieId)
        {
            return await DbContext.ShowTimes
                .Include(s => s.Screen)
                .ThenInclude(sc => sc.Cinema)
                .Where(s => s.MovieId == movieId)
                .ToListAsync();
        }
    }
}
