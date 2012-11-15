
using System.Linq;
using System.Net;

using Newtonsoft.Json.Linq;


namespace WeatherForecastReader
{
    public class WeatherUndergroundReader
    {
        WebClient webClient;
        string jsonSource;
        public WeatherUndergroundReader(WeatherUndergroundSource weatherUndergroundSource)
        {
            jsonSource = weatherUndergroundSource.GetJson();
            webClient = new WebClient();
            
            
            
        }

        public string GetPeriodTemp(int periodId)
        {
            dynamic result = JValue.Parse(jsonSource);

            JArray root = (JArray) result.forecast.simpleforecast.forecastday;

        var dictionary = root.ToDictionary(x => (int) x["period"],
                                           x => (dynamic)x["low"]);

        var period = dictionary[periodId];
        var celsius = period.celsius.Value;
        return celsius;
        }
    }
}
