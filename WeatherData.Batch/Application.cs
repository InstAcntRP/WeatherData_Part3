using WeatherData.Services;
using WeatherData.Models;

namespace WeatherData.Batch;

public class Application
{
    private readonly IWeatherDataService _weatherDataService;
    private readonly ICSVFileGenerator _csvFileGenerator;

    public Application(IWeatherDataService weatherDataService,ICSVFileGenerator csvFileGenerator)
    {
        _weatherDataService= weatherDataService;
        _csvFileGenerator = csvFileGenerator;
    }
    public void Run()
    {
        Console.WriteLine("Run method is invoked");
         List<Hourly> hourlyTimeSeriesList = new List<Hourly>();
        var  task = Task.Run(async()=> hourlyTimeSeriesList = await _weatherDataService.GetWeatherDataViaAPI()).Result;
        _csvFileGenerator.GenerateCSVWeatherDataFile(hourlyTimeSeriesList);
    }
}