using MovieBooker.Application.DTOs;

namespace MovieBooker.Application.Interfaces
{
    public interface IShowTimeService
    {
        Task<List<ShowTimeDto>> GetByMovieAsync(int movieId);
    }

}
