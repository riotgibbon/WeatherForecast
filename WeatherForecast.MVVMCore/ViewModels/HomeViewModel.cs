using System.Collections.Generic;
using Cirrious.MvvmCross.ExtensionMethods;
using Cirrious.MvvmCross.Interfaces.ServiceProvider;
using Cirrious.MvvmCross.ViewModels;
using WeatherForecast.Core;
using WeatherForecast.Core.Domain;
using WeatherForecast.Core.Interfaces;

namespace WeatherForecast.MVVMCore.ViewModels
{
    public class HomeViewModel : MvxViewModel, IMvxServiceConsumer<ICityProvider>
    {
        private List<City> _cities;
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

        public HomeViewModel()
        {
            LoadCities();
        }

        private async void LoadCities()
        {
            Cities = await CityProvider.GetCurrentCitiesAsync();
            //CityForecastProvider cityForecastProvider = new CityForecastProvider(Cities, new WebTools);
        }

        private ICityProvider CityProvider
        {
            get { return this.GetService<ICityProvider>(); }
        }


    }
}
