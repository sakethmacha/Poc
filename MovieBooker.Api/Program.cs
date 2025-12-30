
using Microsoft.EntityFrameworkCore;
using MovieBooker.Application.Interfaces;
using MovieBooker.Application.Services;
using MovieBooker.Infrastructure.DbContexts;
using MovieBooker.Infrastructure.Interfaces;
using MovieBooker.Infrastructure.Repositories;

namespace MovieBooker.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<MovieBookerDbContext>(options =>
                                        options.UseSqlServer(
                                            builder.Configuration.GetConnectionString("Constr")
                                        )
                                    );

            // 🔹 Dependency Injection
            builder.Services.AddScoped<IMovieRepository, MovieRepository>();
            builder.Services.AddScoped<IShowTimeRepository, ShowTimeRepository>();
            builder.Services.AddScoped<IBookingRepository, BookingRepository>();

            builder.Services.AddScoped<IMovieService, MovieService>();
            builder.Services.AddScoped<IShowTimeService, ShowTimeService>();
            builder.Services.AddScoped<IBookingService, BookingService>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
