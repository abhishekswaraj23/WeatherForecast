using System;
using System.Collections.Generic;
using WeatherForecast.ViewModel;
using Xamarin.Forms;

namespace WeatherForecast.View
{
    public partial class CityWeatherView : ContentPage
    {
        CityWeatherViewModel cityWeatherViewModel;
        public CityWeatherView()
        {
            InitializeComponent();
            cityWeatherViewModel = new CityWeatherViewModel(Navigation);
            BindingContext = cityWeatherViewModel;
        }

    }
}
