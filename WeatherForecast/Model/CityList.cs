using System;
using System.Collections.Generic;

namespace WeatherForecast.Model
{
    public static class CityList
    {
        public static List<CityInfo> AllCity { get; set; }

        static CityList()
        {
            AllCity = new List<CityInfo>();
        }

        public static void AddCity(CityInfo city)
        {
            AllCity.Add(city);
        }

        public static void RemoveCity(CityInfo city)
        {
            AllCity.Remove(city);
        }
    }
}
