using WeatherData.Models;

namespace WeatherData.Services;

public class CSVFileGenerator : ICSVFileGenerator
{

    private const string  Location ="New York";
    private const string CSVDataFilePath="ForecastWeatherData.csv";
    public void GenerateCSVWeatherDataFile( List<Hourly> hourlyTimeSeriesList)
    {
            //Console.WriteLine($"GenerateCSVWeatherDataFile");
            string fileHeader = "Location, Date Time, Temperature";
            using (FileStream fileStreamOverWrite = new FileStream(CSVDataFilePath,FileMode.Create))
            {
                using (StreamWriter streamWriter = new StreamWriter(fileStreamOverWrite))
                {
                    streamWriter.WriteLine(fileHeader);
                    foreach(Hourly wdItem in hourlyTimeSeriesList.OrderBy(wd =>wd.time).ToList())
                    {
                        streamWriter.Write(Environment.NewLine);
                        streamWriter.Write(string.Format("{0},{1},{2}",Location, wdItem.time.ToString("MM-dd-yyyy hh:mm"),wdItem.values.temperature));
                    }
                }
            }
            Console.WriteLine("Forecast data file has been successfully generated.");
    }
}
