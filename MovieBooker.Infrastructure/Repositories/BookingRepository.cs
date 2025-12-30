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

        //public async Task<Booking> BookAsync(Booking booking)
        //{
        //    using var tx = await DbContext.Database.BeginTransactionAsync();

        //    var seat = await DbContext.Seats
        //        .FirstAsync(s => s.SeatNumber == booking.SeatNumber && !s.IsBooked);

        //    seat.IsBooked = true;

        //    DbContext.Bookings.Add(booking);
        //    await DbContext.SaveChangesAsync();

        //    // EXPLICITLY LOAD NAVIGATION DATA
        //    await DbContext.Entry(booking)
        //        .Reference(b => b.ShowTime)
        //        .LoadAsync();

        //    await DbContext.Entry(booking.ShowTime)
        //        .Reference(st => st.Movie)
        //        .LoadAsync();

        //    await tx.CommitAsync();

        //    return booking;
        //}
        public async Task<Booking> BookAsync(Booking booking)
        {
            using var tx = await DbContext.Database.BeginTransactionAsync();

            var seat = await DbContext.Seats
                .FirstAsync(s => s.SeatNumber == booking.SeatNumber && !s.IsBooked);

            seat.IsBooked = true;

            DbContext.Bookings.Add(booking);
            await DbContext.SaveChangesAsync();

            //  RELOAD WITH NAVIGATION PROPERTIES
            var fullBooking = await DbContext.Bookings
                .Include(b => b.ShowTime)
                .ThenInclude(st => st.Movie)
                .FirstAsync(b => b.Id == booking.Id);

            await tx.CommitAsync();

            return fullBooking;
        }


        public async Task<Booking?> GetAsync(int id)
            => await DbContext.Bookings
                .Include(b => b.ShowTime)
                .ThenInclude(st => st.Movie)
                .FirstOrDefaultAsync(b => b.Id == id);

        public async Task CancelAsync(int id)
        {
            var booking = await DbContext.Bookings.FindAsync(id);
            if (booking == null) return;

            booking.IsCancelled = true;

            var seat = await DbContext.Seats
                .FirstAsync(s => s.SeatNumber == booking.SeatNumber);

            seat.IsBooked = false;

            await DbContext.SaveChangesAsync();
        }
    }
}
