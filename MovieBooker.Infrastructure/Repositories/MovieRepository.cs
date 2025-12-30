using MovieBooker.Domain.Entities;
using MovieBooker.Infrastructure.DbContexts;
using MovieBooker.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace MovieBooker.Infrastructure.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieBookerDbContext DbContext;

        public MovieRepository(MovieBookerDbContext context)
        {
            DbContext = context;
        }

        public async Task<List<Movie>> GetAllAsync()
            => await DbContext.Movies.ToListAsync();
    }
}
