using System.Threading.Tasks;

namespace WeatherForecast.Core.Services
{
    public interface WeatherUndergroundSource
    {
        Task<string> GetJsonAsync();
    }
}
