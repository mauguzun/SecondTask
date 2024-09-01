using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SecondTask.Infrastructure.DbContext;
using SecondTask.Infrastructure.Implementations.Repositories;
using SecondTask.Infrastructure.Implementations.Services;
using SecondTask.Infrastructure.Inerfaces.Repositories;
using SecondTask.Infrastructure.Inerfaces.Services;
using TestTask.Application.Implementations;
using TestTask.Application.Inerfaces;
using TestTask.Domain.Entites;
using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.OpenApi.Models;
using TestTask.Application;


namespace SecondTask.Web.Server
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString));
            //Repositories
            builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddTransient<ILocationRepository, LocationRepository>();
            builder.Services.AddTransient<IWeatherDataRepostiory, WeatherDataRepostiory>();
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
            builder.Services.AddAutoMapper(typeof(MapperProfile));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Second  task",
                    Description = "Very important Api",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Example Contact",
                        Url = new Uri("https://example.com/contact")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Example License",
                        Url = new Uri("https://example.com/license")
                    }
                });
       
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
            });


            builder.Services.AddCors(options =>
            {
                options.AddPolicy("localhost", builder =>
                {
                    builder
                        .SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });


            //builder.Services.AddHangfire(configuration => configuration
            //    .UseSimpleAssemblyNameTypeSerializer()
            //    .UseRecommendedSerializerSettings()
            //    .UseMemoryStorage()).AddHangfireServer();

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
            
            //app.UseHangfireDashboard(); // for some reason 

            app.MapControllers();

            //RecurringJob.AddOrUpdate(
            //    recurringJobId: "FetchWeatherData",
            //    methodCall: (IWeatherService x) => x.FetchAndStoreWeatherDataAsync(default(CancellationToken)),
            //    cronExpression: Cron.Minutely,
            //    options: new RecurringJobOptions()
            //);


            app.UseCors("localhost");
            app.MapFallbackToFile("/index.html");

            app.Run();
        }
    }
}
