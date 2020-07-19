using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherForecast.Model;

namespace WeatherForecast.ServiceProvider
{
    public class WeatherForecastService
    {
        HttpClient client;
        public WeatherForecastService()
        {
            client = new HttpClient();
        }

        public async Task<WeatherData> GetWeatherData(string query)
        {
            WeatherData weatherData = null;
            try
            {
                var response = await client.GetAsync(query);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    weatherData = JsonConvert.DeserializeObject<WeatherData>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return weatherData;
        }

        public async Task<List<WeatherInfo>> GetWeatherInfo(double lon, double lat)
        {
            List<WeatherInfo> weatherInfos = new List<WeatherInfo>();

            string query = AppConstants.WeatherEndpoint;
            query += $"?lat={lat}&lon={lon}";
            query += $"&units=metric&exclude=hourly,minutely,current";
            query += $"&appid={AppConstants.WeatherAPIKey}";

            WeatherData data = await GetWeatherData(query);
            if (data != null)
            {
                foreach (var item in data.Daily)
                {
                    WeatherInfo info = new WeatherInfo();
                    info.Date = ConvertUTCtoDT(item.Dt);
                    info.DayTemp = item.Temp.Day;
                    info.FeelsLikeDay = item.FeelsLike.Day;
                    info.FeelsLikeNight = item.FeelsLike.Night;
                    info.Humidity = item.Humidity;
                    info.MaxTemp = item.Temp.Max;
                    info.MinTemp = item.Temp.Min;
                    info.NightTemp = item.Temp.Night;
                    info.Pressure = item.Pressure;
                    info.SunriseTime = ConvertUTCtoDT(item.Sunrise);
                    info.SunsetTime = ConvertUTCtoDT(item.Sunset);
                    info.WeatherDesc = item.Weather.FirstOrDefault()?.Description;
                    info.WeatherIcon = $"{AppConstants.WeatherIcon}{item.Weather.FirstOrDefault()?.Icon}@2x.png"; //"http://openweathermap.org/img/wn/10d@2x.png";
                    info.WindSpeed = $"{DegreeToDirect(item.WindDeg)}, {(item.WindSpeed * 3.6).ToString("#.0")}";
                    info.UVI = item.Uvi;
                    info.Rain = item.Rain;

                    weatherInfos.Add(info);
                }
            }

            return weatherInfos;
        }

        DateTime ConvertUTCtoDT(double dt)
        {
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(dt).ToLocalTime();

            return dtDateTime;
        }

        string DegreeToDirect(double deg)
        {
            string dir = "N";
            if(deg==0)
            {
                dir = "N";
            }
            else if(deg<90)
            {
                dir = "NE";
            }
            else if (deg == 90)
            {
                dir = "E";
            }
            else if (deg < 180)
            {
                dir = "SE";
            }
            else if (deg == 180)
            {
                dir = "S";
            }
            else if (deg < 270)
            {
                dir = "SW";
            }
            else if (deg == 270)
            {
                dir = "W";
            }
            else if (deg < 360)
            {
                dir = "NW";
            }
            return dir;
        }
    }
}
