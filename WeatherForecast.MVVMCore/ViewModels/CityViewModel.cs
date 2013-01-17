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
        public CityViewModel(string forecastJson)
        {
            var forecast = JsonConvert.DeserializeObject<CityForecast>(forecastJson);
        }
    }
}
