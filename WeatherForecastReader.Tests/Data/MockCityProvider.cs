using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherForecast.Core.Domain;
using WeatherForecast.Core.Interfaces;

namespace WeatherForecastReader.Tests.Data
{
    public class MockCityProvider : ICityProvider 
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
                                 new City { CountryCode = "CN", Name = "Shanghai" }
                             };
            return cities;
        }
    }
}
