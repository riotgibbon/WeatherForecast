using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherForecast.Core.Domain;
using WeatherForecast.Core.Domain.WUG;
using WeatherForecast.Core.Interfaces;

namespace WeatherForecast.Core
{
    public interface ICityForecastProvider
    {
        Task<List<CityForecast>> GetCityForecastsAsync(List<City> cities);
    }

    public class CityForecastProvider : ICityForecastProvider
    {
        private IWebTools webTools;
        public CityForecastProvider( IWebTools webTools)
        {
            this.webTools = webTools;
        }

        public async Task<List<CityForecast>> GetCityForecastsAsync(List<City> cities)
        {
            
            var cityForecasts = new List<CityForecast>();
            var cityWeatherForecastSource = new CityWeatherForecastSource(webTools);
            foreach (var city in cities)
            {
               
                var forecastJson = await cityWeatherForecastSource.GetJsonAsync(city);
                var response = JsonConvert.DeserializeObject<WUGResponse>(forecastJson);

                cityForecasts.Add(new CityForecast {City = city, Forecast = response.forecast});
                        
            }
            return cityForecasts;
                 
        }
    }
}