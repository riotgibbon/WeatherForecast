using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Core;
using WeatherForecast.Core.Domain;

namespace WeatherForecastReader
{
    public class LiveWeatherUndergroundSource: WeatherUndergroundSource
    {
        #region WeatherUndergroundSource Members

        //TODO - make async
        public async Task<string> GetJsonAsync()
        {
            
            var shanghaiJson = "http://api.wunderground.com/api/8a497054d4f3f9e8/forecast/q/CN/Shanghai.json";
            var sloughJson = "http://api.wunderground.com/api/8a497054d4f3f9e8/forecast/q/UK/Slough.json";


            var webTools = new WebTools();
            var slough = new City {CountryCode = "UK", Name = "Slough"};
            var forecast = new CityWeatherForecastSource(webTools);
            return await forecast.GetJsonAsync(slough);
        }

        #endregion
    }
}
