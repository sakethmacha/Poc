using MovieBooker.Domain.Entities;
namespace MovieBooker.Infrastructure.Interfaces
{
    public interface IMovieRepository
    {
        Task<List<Movie>> GetAllAsync();
    }

}
