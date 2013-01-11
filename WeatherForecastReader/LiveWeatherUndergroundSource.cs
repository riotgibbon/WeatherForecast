using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Core;

namespace WeatherForecastReader
{
    public class LiveWeatherUndergroundSource: WeatherUndergroundSource
    {
        #region WeatherUndergroundSource Members

        //TODO - make async
        public async Task<string> GetJsonAsync()
        {
            var webClient = new HttpClient();
            var shanghaiJson = "http://api.wunderground.com/api/8a497054d4f3f9e8/forecast/q/CN/Shanghai.json";
            var sloughJson = "http://api.wunderground.com/api/8a497054d4f3f9e8/forecast/q/UK/Slough.json";
            var downloadString = await webClient.GetStringAsync(sloughJson);
            return downloadString;
        }

        #endregion
    }
}
