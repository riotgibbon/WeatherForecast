using System.Collections.Generic;
using System.Windows.Input;
using Cirrious.MvvmCross.Commands;
using Cirrious.MvvmCross.ExtensionMethods;
using Cirrious.MvvmCross.ViewModels;
using Newtonsoft.Json;
using WeatherForecast.Core.Domain;
using WeatherForecast.Core.Interfaces;
using WeatherForecast.Core.Services;

namespace WeatherForecast.MVVMCore.ViewModels
{
    public class HomeViewModel : MvxViewModel
    {
        private List<City> _cities;
        private List<CityForecast> _cityForecasts;
        private bool _isBusy;
        private CityForecast _selectedCityForecast;

        public HomeViewModel()
        {
            LoadCities();
        }
        public ICommand SearchCommand
        {
            get
            {
                return new MvxRelayCommand(GetDetailForecast);
            }
        }

        public ICommand DetailCommand
        {
            get
            {
                return new MvxRelayCommand(GetDetailForecast);
            }
        }

        private void GetDetailForecast()
        {
            var forecastJson = JsonConvert.SerializeObject(SelectedCityForecast);
            RequestNavigate<CityViewModel>(new { forecastJson = forecastJson });
        }


        public List<City> Cities
        {
            get { return _cities; }
            set
            {
                _cities = value;
                RaisePropertyChanged(() => Cities);
            }
        }

        public CityForecast SelectedCityForecast
        {
            get { return _selectedCityForecast; }
            set
            {
                _selectedCityForecast = value;
                RaisePropertyChanged(() => SelectedCityForecast);
            }
        }
      
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                RaisePropertyChanged(() => IsBusy);
            }
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
                RaisePropertyChanged(() => CityForecasts);
            }
        }


        private ICityProvider CityProvider
        {
            get { return this.GetService<ICityProvider>(); }
        }

        private ICityForecastProvider CityForecastProvider
        {
            get { return this.GetService<ICityForecastProvider>(); }
        }

        private async void LoadCities()
        {
            IsBusy = true;
            Cities = await CityProvider.GetCurrentCitiesAsync();
            CityForecasts = await CityForecastProvider.GetCityForecastsAsync(Cities);
            IsBusy = false;
        }
    }
}