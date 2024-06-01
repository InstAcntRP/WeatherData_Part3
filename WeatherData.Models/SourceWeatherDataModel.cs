namespace WeatherData.Models;

public class Hourly
    {
        public DateTime time { get; set; }
          #pragma warning disable CS8618
        public Values values { get; set; }
    }

 public class Values
    {
        public string cloudBase { get; set; } = null!;
        public string cloudCeiling { get; set; }  = null!;
        public string cloudCover { get; set; }  = null!;
        public string dewPoint { get; set; }  = null!;
        public string evapotranspiration { get; set; }  = null!;
        public string freezingRainIntensity { get; set; }  = null!;
        public string humidity { get; set; }  = null!;
        public string iceAccumulation { get; set; }  = null!;
        public string iceAccumulationLwe { get; set; }  = null!;
        public string precipitationProbability { get; set; }  = null!;
        public string pressureSurfaceLevel { get; set; }  = null!;
        public string rainAccumulation { get; set; }  = null!;
        public string rainAccumulationLwe { get; set; }  = null!;
        public string rainIntensity { get; set; }  = null!;
        public string sleetAccumulation { get; set; }  = null!;
        public string sleetAccumulationLwe { get; set; }  = null!;
        public string sleetIntensity { get; set; }  = null!;
        public string snowAccumulation { get; set; }  = null!;
        public string snowAccumulationLwe { get; set; }  = null!;
        public string snowDepth { get; set; } = null!;
        public string snowIntensity { get; set; } = null!;
        public string temperature { get; set; } = null!;
        public string temperatureApparent { get; set; } = null!;
        public string uvHealthConcern { get; set; } = null!;
        public string uvIndex { get; set; } = null!;
        public string visibility { get; set; } = null!;
        public string weatherCode { get; set; } = null!;
        public string windDirection { get; set; } = null!;
        public string windGust { get; set; } = null!;
        public string windSpeed { get; set; } = null!;
    }
