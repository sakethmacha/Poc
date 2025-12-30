using MovieBooker.Domain.Entities;
using MovieBooker.Infrastructure.DbContexts;
using MovieBooker.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace MovieBooker.Infrastructure.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly MovieBookerDbContext DbContext;

        public BookingRepository(MovieBookerDbContext context)
        {
            DbContext = context;
        }
        public async Task<Booking> BookAsync(Booking booking, List<int> seatIds)
        {
            using var tx = await DbContext.Database.BeginTransactionAsync();

            // 1️⃣ Fetch seats
            var seats = await DbContext.Seats
                .Where(s => seatIds.Contains(s.Id))
                .ToListAsync();

            // 2️⃣ Validate availability
            if (seats.Any(s => s.IsBooked))
                throw new Exception("One or more seats already booked.");

            // 3️⃣ Mark seats as booked
            foreach (var seat in seats)
                seat.IsBooked = true;

            // 4️⃣ Save booking
            DbContext.Bookings.Add(booking);
            await DbContext.SaveChangesAsync();

            // 5️⃣ Create BookingSeats
            foreach (var seat in seats)
            {
                DbContext.BookingSeats.Add(new BookingSeat
                {
                    BookingId = booking.Id,
                    SeatId = seat.Id
                });
            }

            await DbContext.SaveChangesAsync();
            await tx.CommitAsync();

            // 6️⃣ Reload with navigation data
            return await DbContext.Bookings
                .Include(b => b.ShowTime)
                .ThenInclude(st => st.Movie)
                .Include(b => b.BookingSeats)
                .ThenInclude(bs => bs.Seat)
                .FirstAsync(b => b.Id == booking.Id);
        }



        public async Task<Booking?> GetAsync(int id)
        {
            return await DbContext.Bookings
                .Include(b => b.ShowTime)
                    .ThenInclude(st => st.Movie)
                .Include(b => b.BookingSeats)
                    .ThenInclude(bs => bs.Seat)
                .FirstOrDefaultAsync(b => b.Id == id);
        }


        public async Task CancelAsync(int id)
        {
            using var tx = await DbContext.Database.BeginTransactionAsync();

            var booking = await DbContext.Bookings
                .Include(b => b.BookingSeats)
                .ThenInclude(bs => bs.Seat)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (booking == null || booking.IsCancelled)
                return;

            // 1️⃣ Mark booking as cancelled
            booking.IsCancelled = true;

            // 2️⃣ Release all seats
            foreach (var bookingSeat in booking.BookingSeats)
            {
                bookingSeat.Seat.IsBooked = false;
            }

            await DbContext.SaveChangesAsync();
            await tx.CommitAsync();
        }

    }
}
