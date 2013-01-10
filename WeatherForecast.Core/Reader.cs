using System.Linq;
using Newtonsoft.Json.Linq;
using WeatherForecast.Core.Domain.WUG;
using Newtonsoft.Json;
using System.Linq;

namespace WeatherForecast.Core
{
    public class WeatherUndergroundReader
    {

        string jsonSource;
        public WeatherUndergroundReader(WeatherUndergroundSource weatherUndergroundSource)
        {
            jsonSource = weatherUndergroundSource.GetJson();
        }

        public string GetPeriodTemp(int periodId)
        {

            var result = JsonConvert.DeserializeObject < WUGResponse>(jsonSource);
            

            var periods =  result.forecast.simpleforecast.forecastday;

        //var dictionary = root.ToDictionary(x => (int) x["period"],
        //                                   x => (dynamic)x["low"]);
            var period = periods.Where(p => p.period == periodId).FirstOrDefault();

            return period.low.celsius;
        }
    }
}
