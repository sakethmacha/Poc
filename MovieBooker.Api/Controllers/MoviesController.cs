using Microsoft.AspNetCore.Mvc;
using MovieBooker.Application.Interfaces;

namespace MovieBooker.Api.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService MovieService;

        public MoviesController(IMovieService movieService)
        {
            MovieService = movieService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await MovieService.GetMoviesAsync());
    }

}
