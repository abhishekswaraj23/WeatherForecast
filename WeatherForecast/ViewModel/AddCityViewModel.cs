using System;
using System.Collections.Generic;
using System.Windows.Input;
using WeatherForecast.ServiceProvider;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Linq;

namespace WeatherForecast.ViewModel
{
    public class AddCityViewModel : ViewModel
    {
        public INavigation Navigation { get; set; }
        public CityWeatherViewModel WeatherPage { get; set; }
        public AddCityViewModel(INavigation navigation, CityWeatherViewModel prevPage)
        {
            Navigation = navigation;
            WeatherPage = prevPage;
        }

        string cityName;
        public string CityName
        {
            get
            {
                return cityName;
            }
            set
            {
                SetProperty(ref cityName, value);
            }
        }
        string country;
        public string Country
        {
            get
            {
                return country;
            }
            set
            {
                SetProperty(ref country, value);
            }
        }
        string countryCode;
        public string CountryCode
        {
            get
            {
                return countryCode;
            }
            set
            {
                SetProperty(ref countryCode, value);
            }
        }

        double longitude;
        public double Longitude
        {
            get
            {
                return longitude;
            }
            set
            {
                SetProperty(ref longitude, value);
            }
        }
        double latitude;
        public double Latitude
        {
            get
            {
                return latitude;
            }
            set
            {
                SetProperty(ref latitude, value);
            }
        }

        string address;
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                SetProperty(ref address, value);
            }
        }

        bool enableAddCity = false;
        public bool EnableAddCity
        {
            get
            {
                return enableAddCity;
            }
            set
            {
                SetProperty(ref enableAddCity, value);
            }
        }


        public ICommand PerformSearch => new Command(async () =>
        {
            if (CityName != null)
            {
                try
                {
                    var locations = await Geocoding.GetLocationsAsync(CityName);
                    var location = locations?.FirstOrDefault();
                    if (location != null)
                    {
                        Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                        var fullAddress = await Geocoding.GetPlacemarksAsync(location.Latitude, location.Longitude);

                        if (fullAddress != null)
                        {

                            Address = $"City: {fullAddress.FirstOrDefault().Locality}, Country: {fullAddress.FirstOrDefault().CountryName},\n Latitude: {location.Latitude}, Longitude: {location.Longitude}";
                            EnableAddCity = true;
                            Latitude = location.Latitude;
                            Longitude = location.Longitude;
                            Country = fullAddress.FirstOrDefault().CountryName;
                            CountryCode = fullAddress.FirstOrDefault().CountryCode;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Address = "Invalid Address";
                    EnableAddCity = false;
                }

            }
        });

        public ICommand AddCityCommand => new Command(() =>
        {
            WeatherPage.City = new Model.CityInfo()
            {
                CityName = cityName,
                Latitude = latitude,
                Longitude = longitude,
                Country = country,
                CountryCode = countryCode
            };
            Navigation.PopAsync();
        });

    }
}
