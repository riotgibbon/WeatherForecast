using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using WeatherForecast.Core;

namespace WeatherForecastReader
{
    public class LiveWeatherUndergroundSource: WeatherUndergroundSource
    {
        #region WeatherUndergroundSource Members

        //TODO - make async
        public string GetJson()
        {
            var webClient = new WebClient();
            var shanghaiJson = "http://api.wunderground.com/api/8a497054d4f3f9e8/forecast/q/CN/Shanghai.json";
            var sloughJson = "http://api.wunderground.com/api/8a497054d4f3f9e8/forecast/q/UK/Slough.json";
            return (webClient.DownloadString (sloughJson));
        }

        #endregion
    }
}
