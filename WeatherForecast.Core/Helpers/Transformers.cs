using System.Linq;
using WeatherForecast.Core.Domain;
using WeatherForecast.Core.Domain.WUG;

namespace WeatherForecast.Core.Helpers
{
    public class Transformers
    {
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
