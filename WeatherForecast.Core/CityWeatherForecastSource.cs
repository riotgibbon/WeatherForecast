using System.Threading.Tasks;
using WeatherForecast.Core.Domain;
using WeatherForecast.Core.Interfaces;

namespace WeatherForecast.Core
{
    public class CityWeatherForecastSource:WeatherUndergroundSource
    {
        private City city;
        private IWebTools webTools;

        public CityWeatherForecastSource(City city, IWebTools webTools)
        {
            // TODO: Complete member initialization
            this.city = city;
            this.webTools = webTools;
        }
        public Task<string> GetJsonAsync()
        {
            var jsonUrl = GetCityJsonUrl();
            return webTools.DownloadString(jsonUrl);
        }

        private string GetCityJsonUrl()
        {
            var apiKey = "8a497054d4f3f9e8";
            string jsonUrl = string.Format("http://api.wunderground.com/api/{2}/forecast/q/{0}/{1}.json", city.CountryCode,
                                           city.Name, apiKey);
            return jsonUrl;
        }
    }
}