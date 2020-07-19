using System;
using Newtonsoft.Json;

namespace WeatherForecast.Utils
{
    public static class JSONManager
    {
        public static T DeserializeObject<T>(string content)
        {
            return JsonConvert.DeserializeObject<T>(content);
        }

        public static string SerializeObject<T>(T content)
        {
            return JsonConvert.SerializeObject(content);
        }
    }
}
