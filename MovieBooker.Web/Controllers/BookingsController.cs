using Microsoft.AspNetCore.Mvc;
using MovieBooker.Application.DTOs;
using MovieBooker.Application.Interfaces;

namespace MovieBooker.Web.Controllers
{
    public class BookingsController : Controller
    {
        private readonly IBookingService BookingService;
        private readonly ISeatService SeatService;

        public BookingsController(IBookingService bookingService, ISeatService seatService)
        {
            BookingService = bookingService;
            SeatService = seatService;

        }

        public async Task<IActionResult> Create(int showTimeId)
        {
            ViewBag.Seats = await SeatService.GetAvailableSeatsAsync(showTimeId);

            return View(new CreateBookingDto
            {
                ShowTimeId = showTimeId
            });
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateBookingDto dto)
        {
            //  CHECK THIS
            var count = dto.SeatIds.Count;

            var booking = await BookingService.BookAsync(dto);
            return RedirectToAction("Details", new { id = booking.Id });
        }

        public async Task<IActionResult> Details(int id)
            => View(await BookingService.GetAsync(id));

        public async Task<IActionResult> Cancel(int id)
        {
            await BookingService.CancelAsync(id);
            return RedirectToAction("Index", "Movies");
        }
    }

}
