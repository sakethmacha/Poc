using Microsoft.AspNetCore.Mvc;
using MovieBooker.Application.DTOs;
using MovieBooker.Application.Interfaces;

namespace MovieBooker.Api.Controllers
{
    [ApiController]
    [Route("api/bookings")]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService BookingService;

        public BookingsController(IBookingService bookingService)
        {
            BookingService = bookingService;
        }

        [HttpPost]
        public async Task<IActionResult> Book(CreateBookingDto dto)
            => Ok(await BookingService.BookAsync(dto));

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
            => Ok(await BookingService.GetAsync(id));

        [HttpDelete("{id}")]
        public async Task<IActionResult> Cancel(int id)
        {
            await BookingService.CancelAsync(id);
            return NoContent();
        }
    }

}
