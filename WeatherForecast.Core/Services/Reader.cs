using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherForecast.Core.Domain.WUG;

namespace WeatherForecast.Core.Services
{
    public class WeatherUndergroundReader
    {
        private readonly WeatherUndergroundSource _weatherUndergroundSource;
        private WUGResponse response;

        public WeatherUndergroundReader(WeatherUndergroundSource weatherUndergroundSource)
        {
            _weatherUndergroundSource = weatherUndergroundSource;
            
        }

        private async Task<string> GetJsonData()
        {
           return await _weatherUndergroundSource.GetJsonAsync();
        }

        public async Task<string> GetPeriodMinTempAsync(int periodId)
        {

            var result = await GetWUGForecast();
            var forecastDays =  result.forecast.simpleforecast.forecastday;
            Func<Forecastday2, bool> predicate = p => p.period == periodId;
            var period = GetForecastDay(forecastDays, predicate);
            return period.low.celsius;
        }

        private async Task<WUGResponse> GetWUGForecast()
        {
            if (response == null)
                response = JsonConvert.DeserializeObject<WUGResponse>(await GetJsonData());
            return response;
        }

        private static T GetForecastDay<T>(IEnumerable<T> periods, Func<T, bool> predicate)
        {
            return periods.Where(predicate).FirstOrDefault();
        }
    }
}
