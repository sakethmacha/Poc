using Microsoft.AspNetCore.Mvc;
using MovieBooker.Application.Interfaces;

namespace MovieBooker.Web.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService MovieService;

        public MoviesController(IMovieService movieService)
        {
            MovieService = movieService;
        }

        public async Task<IActionResult> Index()
            => View(await MovieService.GetMoviesAsync());
    }

}
