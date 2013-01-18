using System.Collections.Generic;
using System.Windows.Input;
using System.Linq;
using Cirrious.MvvmCross.Commands;
using Cirrious.MvvmCross.ExtensionMethods;
using Cirrious.MvvmCross.ViewModels;
using Newtonsoft.Json;
using WeatherForecast.Core.Domain;
using WeatherForecast.Core.Interfaces;
using WeatherForecast.Core.Services;
using WeatherForecast.MVVMCore.Helpers;


namespace WeatherForecast.MVVMCore.ViewModels
{
    public class HomeViewModel : MvxViewModel
    {
        private List<City> _cities;
        private List<WithCommand<CityForecast>> _cityForecasts;
        private bool _isBusy;
        

        public HomeViewModel()
        {
            LoadCities();
        }
       

       
        private void NavigateToForecast(CityForecast selectedCityForecast)
        {
            var forecastJson = JsonConvert.SerializeObject(selectedCityForecast);
            RequestNavigate<CityViewModel>(new {forecastJson = forecastJson});
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

        
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                RaisePropertyChanged(() => IsBusy);
            }
        }

        public List<WithCommand<CityForecast>> CityForecasts
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
            var cityForecasts = await CityForecastProvider.GetCityForecastsAsync(Cities);
            CityForecasts =
                cityForecasts.Select(
                    forecast =>
                    new WithCommand<CityForecast>(forecast, new MvxRelayCommand(() => 
                        NavigateToForecast(forecast))))
                             .ToList();
            IsBusy = false;
        }
    }
}