using System;
using System.Collections.Generic;
using WeatherForecast.Model;
using WeatherForecast.ViewModel;
using Xamarin.Forms;

namespace WeatherForecast.View
{
    public partial class WeatherDetailView : ContentPage
    {
        public WeatherDetailView(WeatherInfo info,string currentCity)
        {
            InitializeComponent();
            BindingContext = new WeatherDetailViewModel(info, currentCity);
        }
    }
}
