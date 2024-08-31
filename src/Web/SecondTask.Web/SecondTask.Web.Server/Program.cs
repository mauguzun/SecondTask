using Microsoft.EntityFrameworkCore;
using SecondTask.Infrastructure.DbContext;
using SecondTask.Infrastructure.Implementations.Repositories;
using SecondTask.Infrastructure.Implementations.Services;
using SecondTask.Infrastructure.Inerfaces.Repositories;
using SecondTask.Infrastructure.Inerfaces.Services;
using TestTask.Application.Implementations;
using TestTask.Application.Inerfaces;
using TestTask.Domain.Entites;

namespace SecondTask.Web.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(connectionString));
            //Repositories
            builder.Services.AddTransient<IGenericRepository<Location>, LocationRepository>();
            builder.Services.AddTransient<IGenericRepository<WeatherData>, WeatherDataRepostiory>();
            //ApiRequest
            builder.Services.AddTransient<IOpenWeatherService, OpenWeatherService>();
            //Application
            builder.Services.AddTransient<IWeatherService, WeatherService>();

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.MapFallbackToFile("/index.html");

            app.Run();
        }
    }
}
