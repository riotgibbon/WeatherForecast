using WeatherForecast.Core.Domain.WUG;

namespace WeatherForecast.Core.Domain
{
    public class CityForecast
    {
        public City City { get; set; }
        public Forecast Forecast { get; set; }
        public TxtForecast.Forecastday Now { get; set; }
    }
}