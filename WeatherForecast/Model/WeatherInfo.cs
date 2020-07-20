using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WeatherForecast.Model
{
    public class WeatherInfo
    {
        public DateTime Date { get; set; }
        public DateTime SunriseTime { get; set; }
        public DateTime SunsetTime { get; set; }
        public double DayTemp { get; set; }
        public double NightTemp { get; set; }
        public double MaxTemp { get; set; }
        public double MinTemp { get; set; }
        public double FeelsLikeDay { get; set; }
        public double FeelsLikeNight { get; set; }
        public double Pressure { get; set; }
        public double Humidity { get; set; }
        public string WindSpeed { get; set; }
        public string WeatherDesc { get; set; }
        public string WeatherIcon { get; set; }
        public double UVI { get; set; }
        public double? Rain { get; set; }

    }
}