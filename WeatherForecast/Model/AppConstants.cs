using System;
namespace WeatherForecast.Model
{
    public static class AppConstants
    {
        public static string WeatherEndpoint = "https://api.openweathermap.org/data/2.5/onecall";//"https://api.openweathermap.org/data/2.5/weather";

        //"https://api.openweathermap.org/data/2.5/onecall?lat=33.441792&lon=-94.037689&units=metric&
        //exclude=hourly,minutely,current&appid=656932c9033804c69d8cdc644d9a687e"
        public static string WeatherAPIKey = "656932c9033804c69d8cdc644d9a687e";

        public static string WeatherIcon = "http://openweathermap.org/img/wn/";//"http://openweathermap.org/img/wn/10d@2x.png"
    }
}
