using System;
namespace WeatherForecast.Model
{
    public class CityInfo
    {
        public string CityName { get; set; }
        public string Country { get; set; }
        public string CountryCode { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public WeatherInfo CityWeather { get; set; }
    }
}
