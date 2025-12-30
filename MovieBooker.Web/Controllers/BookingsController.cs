using Microsoft.AspNetCore.Mvc;
using MovieBooker.Application.DTOs;
using MovieBooker.Application.Interfaces;

namespace MovieBooker.Web.Controllers
{
    public class BookingsController : Controller
    {
        private readonly IBookingService BookingService;

        public BookingsController(IBookingService bookingService)
        {
            BookingService = bookingService;
        }

        public IActionResult Create(int showTimeId)
            => View(new CreateBookingDto { ShowTimeId = showTimeId });

        [HttpPost]
        public async Task<IActionResult> Create(CreateBookingDto dto)
            => RedirectToAction("Details", new { id = (await BookingService.BookAsync(dto)).Id });

        public async Task<IActionResult> Details(int id)
            => View(await BookingService.GetAsync(id));

        public async Task<IActionResult> Cancel(int id)
        {
            await BookingService.CancelAsync(id);
            return RedirectToAction("Index", "Movies");
        }
    }

}
