using System;
using System.Collections.Generic;
using WeatherForecast.ViewModel;
using Xamarin.Forms;

namespace WeatherForecast.View
{
    public partial class CityWeatherView : ContentPage
    {
        public CityWeatherView()
        {
            InitializeComponent();
            BindingContext = new CityWeatherViewModel(Navigation);
        }
    }
}
