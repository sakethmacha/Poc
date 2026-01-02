using MovieBooker.Application.DTOs;
using MovieBooker.Application.Interfaces;
using MovieBooker.Infrastructure.Interfaces;

namespace MovieBooker.Application.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository MovieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            MovieRepository = movieRepository;
        }

        public async Task<List<MovieDto>> GetMoviesAsync()
            => (await MovieRepository.GetAllAsync())
                .Select(m => new MovieDto { Id = m.Id, Title = m.Title })
                .ToList();
    }

}
