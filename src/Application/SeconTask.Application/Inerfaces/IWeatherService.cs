using OneOf;
using TestTask.Domain.Entites;

namespace TestTask.Application.Inerfaces
{
    public interface IWeatherService
    {
        Task FetchAndStoreWeatherDataAsync(string location, CancellationToken cancellationToken);

    }
}
