using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherForecast.Core.Domain;
using WeatherForecast.Core.Domain.WUG;
using WeatherForecast.Core.Interfaces;

namespace WeatherForecast.Core.Services
{
    public interface ICityForecastProvider
    {
        Task<List<CityForecast>> GetCityForecastsAsync(List<City> cities);
    }

    public class CityForecastProvider : ICityForecastProvider
    {

        private IWebTools _webTools;

        public CityForecastProvider( IWebTools webTools)
        {
            _webTools = webTools;
        }

        public async Task<List<CityForecast>> GetCityForecastsAsync(List<City> cities)
        {
            var cityWeatherForecastSource = new CityWeatherForecastSource(_webTools);
            var cityForecasts = new List<CityForecast>();
            foreach (var city in cities)
            {
                cityForecasts.Add(await GetCityForecast(cityWeatherForecastSource, city));
            }
            return cityForecasts;
                 
        }

        private static async Task<CityForecast> GetCityForecast(CityWeatherForecastSource cityWeatherForecastSource, City city)
        {
            var forecastJson = await cityWeatherForecastSource.GetJsonAsync(city);
            var response = JsonConvert.DeserializeObject<WUGResponse>(forecastJson);
            return GetCityForecast(city, response);
        }

        public static CityForecast GetCityForecast(City city, WUGResponse response)
        {
            return new CityForecast
                {
                    City = city,
                    Forecast = response.forecast,
                    Now = response.forecast.txt_forecast.forecastday.FirstOrDefault()
                };
        }
    }
}