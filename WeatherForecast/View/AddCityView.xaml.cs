using System;
using System.Collections.Generic;
using WeatherForecast.ViewModel;
using Xamarin.Forms;

namespace WeatherForecast.View
{
    public partial class AddCityView : ContentPage
    {
        public AddCityView(CityWeatherViewModel prevPage)
        {
            InitializeComponent();
            BindingContext = new AddCityViewModel(Navigation, prevPage);
        }

        
    }
}
