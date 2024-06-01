using WeatherData.Models;
namespace WeatherData.Services;

public interface ICSVFileGenerator
{
    void GenerateCSVWeatherDataFile( List<Hourly> hourlyTimeSeriesList);
}
