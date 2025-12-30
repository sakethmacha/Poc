using Microsoft.AspNetCore.Mvc;
using MovieBooker.Application.Interfaces;

namespace MovieBooker.Web.Controllers
{
    public class ShowTimesController : Controller
    {
        private readonly IShowTimeService ShowTimeService;

        public ShowTimesController(IShowTimeService showTimeService)
        {
            ShowTimeService = showTimeService;
        }

        public async Task<IActionResult> Index(int movieId)
            => View(await ShowTimeService.GetByMovieAsync(movieId));
    }

}
