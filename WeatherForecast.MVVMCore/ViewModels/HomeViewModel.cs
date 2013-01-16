using System.Collections.Generic;
using Cirrious.MvvmCross.ExtensionMethods;
using Cirrious.MvvmCross.Interfaces.ServiceProvider;
using Cirrious.MvvmCross.ViewModels;
using WeatherForecast.Core;
using WeatherForecast.Core.Domain;
using WeatherForecast.Core.Interfaces;

namespace WeatherForecast.MVVMCore.ViewModels
{
    public class HomeViewModel : MvxViewModel
    {
        private List<City> _cities;
        private List<CityForecast> _cityForecasts;
        private bool _isBusy;

        public List<City> Cities
        {
            get
            {
                return _cities;
            }
            set { 
                _cities = value;
                RaisePropertyChanged("Cities");
            }
        }

        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }
            set 
            { 
                _isBusy = value;
                RaisePropertyChanged(() => IsBusy);
            }
        }

        public HomeViewModel()
        {
            LoadCities();
        }

        private async void LoadCities()
        {
            IsBusy = true;
           Cities = await CityProvider.GetCurrentCitiesAsync();
           CityForecasts = await CityForecastProvider.GetCityForecastsAsync(Cities);
           IsBusy = false;
        }

        private ICityProvider CityProvider
        {
            get { return this.GetService<ICityProvider>(); }
        }
        private ICityForecastProvider CityForecastProvider
        {
            get { return this.GetService<ICityForecastProvider>(); }
        }

        public List<CityForecast> CityForecasts
        {
            get
            {
                return _cityForecasts;
            }
            set
            {
                _cityForecasts = value;
                RaisePropertyChanged(()=>CityForecasts);
            }
        }
    }
}
