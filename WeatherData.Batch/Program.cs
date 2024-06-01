using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Http;
using WeatherData.Services;

namespace WeatherData.Batch;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        IHostBuilder hostBuilder = Host.CreateDefaultBuilder();
        hostBuilder.ConfigureServices((context,services) =>
        {
            services.AddSingleton<Application>();
            services.AddHttpClient();
            services.AddScoped<IWeatherDataService, WeatherDataService>();
             services.AddScoped<ICSVFileGenerator,CSVFileGenerator>();
        });
        IHost host = hostBuilder.UseConsoleLifetime().Build();
        Application app = host.Services.GetRequiredService<Application>();
        app.Run();
    }
}



