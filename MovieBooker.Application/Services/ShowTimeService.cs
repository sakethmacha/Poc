using MovieBooker.Application.DTOs;
using MovieBooker.Application.Interfaces;
using MovieBooker.Infrastructure.Interfaces;

namespace MovieBooker.Application.Services
{
    public class ShowTimeService : IShowTimeService
    {
        private readonly IShowTimeRepository ShowTimeRepository;

        public ShowTimeService(IShowTimeRepository showTimeRepository)
        {
            ShowTimeRepository = showTimeRepository;
        }

        public async Task<List<ShowTimeDto>> GetByMovieAsync(int movieId)
        {
            var list = await ShowTimeRepository.GetByMovieAsync(movieId);

            return list.Select(s => new ShowTimeDto
            {
                ShowTimeId = s.Id,
                Cinema = s.Screen.Cinema.Name,
                Screen = s.Screen.Name,
                Time = s.StartTime
            }).ToList();
        }
    }

}
