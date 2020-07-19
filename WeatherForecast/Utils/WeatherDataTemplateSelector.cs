using System;
using WeatherForecast.Model;
using Xamarin.Forms;

namespace WeatherForecast.Utils
{
    public class WeatherDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate CurrentDayTemplate { get; set; }
        public DataTemplate FutureDayTemplate { get; set; }
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return ((WeatherInfo)item).Date.Date == DateTime.Now.Date ? CurrentDayTemplate : FutureDayTemplate;
        }
    }
}
