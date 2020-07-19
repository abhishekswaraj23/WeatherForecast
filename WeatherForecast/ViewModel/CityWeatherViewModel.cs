using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using WeatherForecast.Model;
using WeatherForecast.ServiceProvider;
using WeatherForecast.View;
using Xamarin.Forms;

namespace WeatherForecast.ViewModel
{
    public class CityWeatherViewModel : ViewModel
    {

        public INavigation Navigation { get; set; }
        public CityWeatherViewModel(INavigation navigation)
        {
            Navigation = navigation;

            City = new CityInfo() { CityName = "Patna", Country = "India", CountryCode = "IN", Latitude = 25.5941, Longitude = 85.158875 };
            WeatherList = new ObservableCollection<WeatherInfo>();
            LoadWeatherData();


        }

        private async Task LoadWeatherData()
        {
            WeatherList.Clear();
            var list = await new WeatherForecastService().GetWeatherInfo(City.Longitude, City.Latitude);

            foreach (var item in list)
            {
                WeatherList.Add(item);
            }
        }

        CityInfo city;
        public CityInfo City
        {
            get
            {
                return city;
            }
            set
            {
                if (SetProperty(ref city, value))
                {
                    LoadWeatherData();
                }
            }
        }
        public ObservableCollection<WeatherInfo> WeatherList { get; set; }

        public ICommand ChangeCity => new Command(() =>
        {
            Navigation.PushAsync(new AddCityView(this));
        });

        public ICommand ItemTapped => new Command((e) =>
        {
            var data = (Model.WeatherInfo)(e);
            Navigation.PushAsync(new WeatherDetailView(data, $"{this.City.CityName}, {this.City.CountryCode}"));
        });

    }
}
