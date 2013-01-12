using System.Net.Http;
using System.Threading.Tasks;
using WeatherForecast.Core.Interfaces;

namespace WeatherForecastReader
{
    public class WebTools : IWebTools
    {
        public  async Task<string> DownloadString(string sourceUrl)
        {
            var webClient = new HttpClient();
            var downloadString = await webClient.GetStringAsync(sourceUrl);
            return downloadString;
        }
    }
}