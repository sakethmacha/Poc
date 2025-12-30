using MovieBooker.Application.DTOs;

namespace MovieBooker.Application.Interfaces
{
    public interface IMovieService
    {
        Task<List<MovieDto>> GetMoviesAsync();
    }

}
