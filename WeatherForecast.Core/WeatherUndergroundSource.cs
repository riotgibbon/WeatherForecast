using System.Threading.Tasks;

namespace WeatherForecast.Core
{
    public interface WeatherUndergroundSource
    {
        Task<string> GetJsonAsync();
    }
}
