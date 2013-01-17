using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cirrious.MvvmCross.ViewModels;
using Newtonsoft.Json;
using WeatherForecast.Core.Domain;

namespace WeatherForecast.MVVMCore.ViewModels
{
    public class CityViewModel : MvxViewModel
    {
        private CityForecast _cityForecast;

        public CityViewModel(string forecastJson)
        {
            CityForecast = JsonConvert.DeserializeObject<CityForecast>(forecastJson);
        }

        public CityForecast CityForecast
        {
            get { return _cityForecast; }
            set
            {
                _cityForecast = value;
                RaisePropertyChanged(() => CityForecast);
            }
        }
    }
}
