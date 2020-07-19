using System;
using WeatherForecast.Model;

namespace WeatherForecast.ViewModel
{
    public class WeatherDetailViewModel : ViewModel
    {

        public WeatherDetailViewModel(WeatherInfo weatherInfo, string currentCity)
        {
            WeatherInfo = weatherInfo;
            City = currentCity;
        }

        WeatherInfo weatherInfo;
        public WeatherInfo WeatherInfo
        {
            get
            {
                return weatherInfo;
            }
            set
            {
                SetProperty(ref weatherInfo, value);
            }
        }

        string city;
        public string City
        {
            get
            {
                return city;
            }
            set
            {
                SetProperty(ref city, value);
            }
        }
    }
}
