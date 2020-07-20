using System;
using System.Collections.Generic;
using System.Windows.Input;
using WeatherForecast.ServiceProvider;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Linq;
using System.Threading.Tasks;

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

        public ICommand PerformSearch => new Command(async () =>
        {
            Address = "";
            if (!string.IsNullOrEmpty(CityName))
            {
                try
                {
                    IsLoading = true;
                    var locations = await Geocoding.GetLocationsAsync(CityName);
                    IsLoading = false;
                    var location = locations?.FirstOrDefault();
                    if (location != null)
                    {
                        IsLoading = true;
                        await GetPlaceMarks(location.Latitude, location.Longitude);
                        IsLoading = false;
                    }
                    else
                    {
                        Address = "Invalid Address";
                    }
                }
                catch (Exception ex)
                {
                    Address = "Invalid Address";
                    EnableAddCity = false;
                    IsLoading = false;
                }

            }
            else
            {
                Address = "Invalid Address";
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

        public ICommand CurrentLocation => new Command(async () =>
        {
            try
            {
                Address = "";
                var location = await Geolocation.GetLastKnownLocationAsync();

                if (location != null)
                {
                    IsLoading = true;
                    await GetPlaceMarks(location.Latitude, location.Longitude);
                    IsLoading = false;
                    AddCityCommand.Execute(null);
                }
                else
                {
                    Address = "Unable to detect location";
                }
            }
            catch (Exception ex)
            {
                Address = "Unable to detect location";
            }
            finally
            {
                IsLoading = false;
            }
        });


        async Task GetPlaceMarks(double lat,double lon)
        {
            var fullAddress = await Geocoding.GetPlacemarksAsync(lat, lon);

            if (fullAddress != null)
            {
                Address = $"City: {fullAddress.FirstOrDefault().Locality}, Country: {fullAddress.FirstOrDefault().CountryName}\nLatitude: {lat}, Longitude: {lon}";
                CityName = fullAddress.FirstOrDefault().Locality;
                EnableAddCity = true;
                Latitude = lat;
                Longitude = lon;
                Country = fullAddress.FirstOrDefault().CountryName;
                CountryCode = fullAddress.FirstOrDefault().CountryCode;
            }
        }
    }
}
