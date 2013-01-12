using System.Threading.Tasks;

namespace WeatherForecast.Core.Interfaces
{
    public interface IWebTools
    {
        Task<string> DownloadString(string sourceUrl);
    }
}