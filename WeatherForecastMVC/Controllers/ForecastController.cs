using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WeatherForecastReader;

namespace WeatherForecastMVC.Controllers
{
    public class ForecastController : ApiController
    {
       
        
        
        // GET api/values/5
        public string Get(int id)
        {
            var weatherSource = new LiveWeatherUndergroundSource();
            var weatherReader = new WeatherUndergroundReader(weatherSource);
            var temp = weatherReader.GetPeriodTemp(id);
            return  temp;
        }

        public string GetTempType()
        {
            return "celsius";
        }
    }
}
