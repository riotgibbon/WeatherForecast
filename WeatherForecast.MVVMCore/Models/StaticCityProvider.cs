using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherForecast.Core;
using WeatherForecast.Core.Domain;
using WeatherForecast.Core.Domain.WUG;
using WeatherForecast.Core.Interfaces;
using WeatherForecast.Core.Services;

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
                                 new City { CountryCode = "ES", Name = "Madrid" },
                                 new City { CountryCode = "CN", Name = "Shanghai" }
                             };
            return cities;
        }

        public static List<CityForecast> MockCityForecasts
        {
            get
            {
                return (GetCurrentCities().Select(GetCityForecast)).ToList();
            }
        }

        public static CityForecast MockCityForecast()
        {
            return GetCityForecast(GetCurrentCities()[0]);
        }

        private static CityForecast GetCityForecast(City currentCity)
        {
            var forecast = JsonConvert.DeserializeObject<WUGResponse>(new MockWeatherUndergroundSource().GetJson()).forecast;

            var cityForecast = new CityForecast
                                   {
                                       City = currentCity,
                                       Now = forecast.txt_forecast.forecastday[0],
                                       Forecast = forecast
                                   };
            return cityForecast;
        }

        class StaticWebTool:IWebTools
        {

            public Task<string> DownloadString(string sourceUrl)
            {
                return new MockWeatherUndergroundSource().GetJsonAsync();
            }
        }
    }
}
