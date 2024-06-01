using WeatherData.Models;
namespace WeatherData.Services;

public interface IWeatherDataService
{
    Task< List<Hourly>>  GetWeatherDataViaAPI();
}
