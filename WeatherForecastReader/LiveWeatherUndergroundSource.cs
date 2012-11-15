using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace WeatherForecastReader
{
    public class LiveWeatherUndergroundSource: WeatherUndergroundSource
    {
        #region WeatherUndergroundSource Members

        public string GetJson()
        {
            WebClient webClient = new WebClient();
            return (webClient.DownloadString("http://api.wunderground.com/api/8a497054d4f3f9e8/forecast/q/UK/Slough.json"));
        }

        #endregion
    }
}
