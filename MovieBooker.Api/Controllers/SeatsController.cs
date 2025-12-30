using Microsoft.AspNetCore.Mvc;
using MovieBooker.Application.Interfaces;

namespace MovieBooker.Api.Controllers
{
    [ApiController]
    [Route("api/seats")]
    public class SeatsController : ControllerBase
    {
        private readonly ISeatService SeatService;

        public SeatsController(ISeatService seatService)
        {
            SeatService = seatService;
        }

        // GET: api/seats/available/5
        [HttpGet("available/{showTimeId}")]
        public async Task<IActionResult> GetAvailableSeats(int showTimeId)
        {
            var seats = await SeatService.GetAvailableSeatsAsync(showTimeId);
            return Ok(seats);
        }
    }

}
