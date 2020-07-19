using System;
using WeatherForecast.View;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherForecast
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var nav = new NavigationPage(new CityWeatherView());
            nav.BarBackgroundColor = Color.FromHex("#140736");
            nav.BarTextColor = Color.White;

            MainPage = nav;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
