using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Core;
using WeatherForecast.Core.Domain;
using WeatherForecast.Core.Domain.WUG;
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
                                 new City { CountryCode = "ES", Name = "Madrid" },
                                 new City { CountryCode = "CN", Name = "Shanghai" }
                             };
            return cities;
        }

        public static List<CityForecast> MockCityForecasts
        {
            get
            {
                var forecasts = new List<CityForecast>();
                forecasts.Add(new CityForecast
                    {
                        City = GetCurrentCities()[0],
                        Now = new TxtForecast.Forecastday
                            {
                                icon_url = "Assets/partlycloudy.gif",
                                fcttext_metric =
                                    "Partly cloudy. High of 4C with a windchill as low as -4C. Breezy. Winds from the NNW at 10 to 25 km/h."
                            }
                    });
                return forecasts;
                //var cityForecastProvider = new CityForecastProvider(new StaticWebTool());
                //return cityForecastProvider.GetCityForecastsAsync(GetCurrentCities()).Result;
            }
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
