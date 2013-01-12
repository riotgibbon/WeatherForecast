using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherForecast.Core.Domain;
using WeatherForecast.Core.Domain.WUG;
using WeatherForecast.Core.Interfaces;

namespace WeatherForecast.Core
{
    public class CityForecastProvider
    {
        private List<City> cities;
        private IWebTools webTools;

        public CityForecastProvider(List<City> cities, IWebTools webTools)
        {
            // TODO: Complete member initialization
            this.cities = cities;
            this.webTools = webTools;
        }

        public async Task<List<CityForecast>> GetCityForecastsAsync()
        {
            
            var cityForecasts = new List<CityForecast>();
            foreach (var city in cities)
            {
                var cityWeatherForecastSource = new CityWeatherForecastSource(city, webTools);
                var forecastJson = await cityWeatherForecastSource.GetJsonAsync();
                var response = JsonConvert.DeserializeObject<WUGResponse>(forecastJson);

                cityForecasts.Add(new CityForecast {City = city, Forecast = response.forecast});
                        
            }
            return cityForecasts;
                 
        }
    }
}