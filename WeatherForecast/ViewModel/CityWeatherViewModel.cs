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
            WeatherList = new ObservableCollection<WeatherInfo>();
            if (city == null)
            {
                if (Application.Current.Properties.ContainsKey("CityInfo"))
                {
                    City = Utils.JSONManager.DeserializeObject<CityInfo>(Application.Current.Properties["CityInfo"].ToString());
                }
                else
                {
                    Navigation.PushAsync(new AddCityView(this));
                }
            }
            else
            {
                LoadWeatherData();
            }

        }

        private async Task LoadWeatherData()
        {
            WeatherList.Clear();
            IsLoading = true;
            var list = await new WeatherForecastService().GetWeatherInfo(City.Longitude, City.Latitude);
            IsLoading = false;
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
                    Application.Current.Properties["CityInfo"] = Utils.JSONManager.SerializeObject(city);
                    Application.Current.SavePropertiesAsync();
                    LoadWeatherData();
                }
            }
        }

        bool isLoading;
        public bool IsLoading
        {
            get
            {
                return isLoading;
            }
            set
            {
                SetProperty(ref isLoading, value);
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

        public ICommand RefreshCommand => new Command(async () =>
        {
            await LoadWeatherData();
        });

    }
}
