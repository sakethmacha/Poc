using Microsoft.EntityFrameworkCore;
using MovieBooker.Domain.Entities;
using System.Collections.Generic;

namespace MovieBooker.Infrastructure.DbContexts;

public class MovieBookerDbContext : DbContext
{
    public MovieBookerDbContext(DbContextOptions<MovieBookerDbContext> options)
        : base(options) { }

    public DbSet<Movie> Movies { get; set; }
    public DbSet<Cinema> Cinemas { get; set; }
    public DbSet<Screen> Screens { get; set; }
    public DbSet<ShowTime> ShowTimes { get; set; }
    public DbSet<Seat> Seats { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<BookingSeat> BookingSeats { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Movie>().HasData(
            new Movie { Id = 1, Title = "Inception" },
            new Movie { Id = 2, Title = "Interstellar" },
            new Movie { Id = 3, Title = "Avengers: Endgame" }
        );

        modelBuilder.Entity<Cinema>().HasData(
            new Cinema { Id = 1, Name = "PVR Cinemas", City = "Bangalore" },
            new Cinema { Id = 2, Name = "INOX", City = "Bangalore" }
        );

        modelBuilder.Entity<Screen>().HasData(
            new Screen { Id = 1, Name = "Audi 1", CinemaId = 1 },
            new Screen { Id = 2, Name = "Audi 2", CinemaId = 1 },
            new Screen { Id = 3, Name = "Screen 1", CinemaId = 2 }
        );

        modelBuilder.Entity<ShowTime>().HasData(
            new ShowTime { Id = 1, MovieId = 1, ScreenId = 1, StartTime = new DateTime(2025, 1, 1, 10, 0, 0) },
            new ShowTime { Id = 2, MovieId = 1, ScreenId = 1, StartTime = new DateTime(2025, 1, 1, 14, 0, 0) },
            new ShowTime { Id = 3, MovieId = 2, ScreenId = 2, StartTime = new DateTime(2025, 1, 1, 18, 30, 0) },
            new ShowTime { Id = 4, MovieId = 3, ScreenId = 3, StartTime = new DateTime(2025, 1, 1, 21, 0, 0) }
        );

        // ✅ SEATS — FLATTENED, EXPLICIT IDS
        modelBuilder.Entity<Seat>().HasData(
            new Seat { Id = 1, ScreenId = 1, SeatNumber = "A1", IsBooked = false },
            new Seat { Id = 2, ScreenId = 1, SeatNumber = "A2", IsBooked = false },
            new Seat { Id = 3, ScreenId = 1, SeatNumber = "A3", IsBooked = false },
            new Seat { Id = 4, ScreenId = 1, SeatNumber = "A4", IsBooked = false },
            new Seat { Id = 5, ScreenId = 1, SeatNumber = "A5", IsBooked = false },

            new Seat { Id = 6, ScreenId = 2, SeatNumber = "A1", IsBooked = false },
            new Seat { Id = 7, ScreenId = 2, SeatNumber = "A2", IsBooked = false },
            new Seat { Id = 8, ScreenId = 2, SeatNumber = "A3", IsBooked = false },
            new Seat { Id = 9, ScreenId = 2, SeatNumber = "A4", IsBooked = false },
            new Seat { Id = 10, ScreenId = 2, SeatNumber = "A5", IsBooked = false },

            new Seat { Id = 11, ScreenId = 3, SeatNumber = "A1", IsBooked = false },
            new Seat { Id = 12, ScreenId = 3, SeatNumber = "A2", IsBooked = false },
            new Seat { Id = 13, ScreenId = 3, SeatNumber = "A3", IsBooked = false },
            new Seat { Id = 14, ScreenId = 3, SeatNumber = "A4", IsBooked = false },
            new Seat { Id = 15, ScreenId = 3, SeatNumber = "A5", IsBooked = false }
        );
    }


}
