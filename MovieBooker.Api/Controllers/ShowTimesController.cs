using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieBooker.Application.Interfaces;

namespace MovieBooker.Api.Controllers
{
    [ApiController]
    [Route("api/showtimes")]
    public class ShowTimesController : ControllerBase
    {
        private readonly IShowTimeService ShowTimeService;

        public ShowTimesController(IShowTimeService showTimeService)
        {
            ShowTimeService = showTimeService;
        }

        [HttpGet("movie/{movieId}")]
        public async Task<IActionResult> Get(int movieId)
            => Ok(await ShowTimeService.GetByMovieAsync(movieId));
    }

}
