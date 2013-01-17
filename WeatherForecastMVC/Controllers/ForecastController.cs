using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WeatherForecast.Core;
using WeatherForecast.Core.Services;
using WeatherForecastReader;

namespace WeatherForecastMVC.Controllers
{
    public class ForecastController : ApiController
    {
       
        
        
        // GET api/values/5
        public async Task<string> Get(int id)
        {
            var weatherSource = new LiveWeatherUndergroundSource();
            var weatherReader = new WeatherUndergroundReader(weatherSource);
            var temp = await weatherReader.GetPeriodMinTempAsync(id);
            return  temp;
        }

        public string GetTempType()
        {
            return "celsius";
        }
    }
}
