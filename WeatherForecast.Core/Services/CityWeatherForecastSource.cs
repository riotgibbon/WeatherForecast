using System.Threading.Tasks;
using WeatherForecast.Core.Domain;
using WeatherForecast.Core.Interfaces;

namespace WeatherForecast.Core.Services
{
    public class CityWeatherForecastSource
    {
        
        private IWebTools webTools;

        public CityWeatherForecastSource(IWebTools webTools)
        {
            this.webTools = webTools;
        }
        public Task<string> GetJsonAsync(City city)
        {
            var jsonUrl = GetCityJsonUrl(city);
            return webTools.DownloadString(jsonUrl);
        }

        private string GetCityJsonUrl(City city)
        {
            var apiKey = "8a497054d4f3f9e8";
            string jsonUrl = string.Format("http://api.wunderground.com/api/{2}/forecast/q/{0}/{1}.json", city.CountryCode,
                                           city.Name, apiKey);
            return jsonUrl;
        }
    }
}