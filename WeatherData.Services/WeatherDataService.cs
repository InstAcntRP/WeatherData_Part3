using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WeatherData.Models;

namespace WeatherData.Services;

public class WeatherDataService: IWeatherDataService
{
    private readonly HttpClient _httpClient;

    public WeatherDataService(HttpClient httpClient)
    {
        _httpClient= httpClient;
    }

    public async Task< List<Hourly>>  GetWeatherDataViaAPI()
    {
        Console.WriteLine("GetWeatherDataViaAPI");
        List<Hourly> hourlyTimeSeriesList = new List<Hourly>();
        //await Task.Delay(1);
       // HttpResponseMessage responseMessage =  await _httpClient.GetAsync("https://api.tomorrow.io/v4/weather/forecast?location=new%20york&apikey=oYe6xAYp7mNaAI4bOmMVzqHnZqHiggNq");
        HttpResponseMessage responseMessage =  await _httpClient.GetAsync("https://api.tomorrow.io/v4/weather/forecast?location=42.3478,-71.0466&apikey=oYe6xAYp7mNaAI4bOmMVzqHnZqHiggNq");
        if(responseMessage.IsSuccessStatusCode)
        {
            string? weatherDataStr = await responseMessage.Content.ReadAsStringAsync();
           // Console.WriteLine($"response-{weatherDataStr}");
            if(!string.IsNullOrEmpty(weatherDataStr))
            {
                 #pragma warning disable CS8600
                  JObject sourceRootData = (JObject) JsonConvert.DeserializeObject(weatherDataStr);
                  if(sourceRootData!=null)
                  {
                    Dictionary<string,object> parentNodeDict = JsonConvert.DeserializeObject<Dictionary<string,object>>(sourceRootData.ToString());
                    #pragma warning disable CS8604
                    KeyValuePair<string,Object> timelinesKeyValuePair = parentNodeDict.Where(pn =>pn.Key.ToLower().Equals("timelines".ToLower())).FirstOrDefault();
                    Dictionary<string,object> timeSeriesDataDict = JsonConvert.DeserializeObject<Dictionary<string,object>>(timelinesKeyValuePair.Value.ToString());
                     KeyValuePair<string,Object> hourlyKeyValuepair = timeSeriesDataDict.Where(hkv =>hkv.Key.ToLower().Equals("hourly".ToLower())).FirstOrDefault();
                     Console.WriteLine($"hourlyKey - {hourlyKeyValuepair.Key}, hourlyValue- {hourlyKeyValuepair.Value}");
                    hourlyTimeSeriesList = JsonConvert.DeserializeObject<List<Hourly>>(hourlyKeyValuepair.Value.ToString());
                  }
            }
        }
         #pragma warning disable CS8603
        return hourlyTimeSeriesList;
    }

}
