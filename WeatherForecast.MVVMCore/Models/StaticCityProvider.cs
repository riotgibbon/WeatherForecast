using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Core.Domain;
using WeatherForecast.Core.Interfaces;

namespace WeatherForecast.MVVMCore.Models
{
    public class StaticCityProvider : ICityProvider 
    {
        public Task<List<City>> GetCurrentCitiesAsync()
        {
            return Task.Run(() => GetCurrentCities());
        }

        public static List<City> GetCurrentCities()
        {
            var cities = new List<City>
                             {
                                 new City { CountryCode = "UK", Name = "Slough" },
                                 new City { CountryCode = "UK", Name = "Leeds" },
                                 new City { CountryCode = "UK", Name = "Glasgow" },
                                 new City { CountryCode = "CN", Name = "Shanghai" }
                             };
            return cities;
        }
    }
}
