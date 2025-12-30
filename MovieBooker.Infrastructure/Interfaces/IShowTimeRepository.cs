using MovieBooker.Domain.Entities;
namespace MovieBooker.Infrastructure.Interfaces
{
    public interface IShowTimeRepository
    {
        Task<List<ShowTime>> GetByMovieAsync(int movieId);
    }

}
