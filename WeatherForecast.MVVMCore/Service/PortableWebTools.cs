using System.IO;
using System.Net;
using System.Threading.Tasks;
using WeatherForecast.Core.Interfaces;

namespace WeatherForecast.MVVMCore.Service
{
	public class PortableWebTools : IWebTools
	{
		public Task<string> DownloadString(string sourceUrl)
		{
            var request = (HttpWebRequest)WebRequest.Create(sourceUrl);
            request.ContentType = "application/json";
            Task<WebResponse> task = Task.Factory.FromAsync(
                request.BeginGetResponse,
                asyncResult => request.EndGetResponse(asyncResult),
                null);
            return task.ContinueWith(t => ReadStreamFromResponse(t.Result)); 
		}

        private static string ReadStreamFromResponse(WebResponse response)
        {
            using (var responseStream = response.GetResponseStream())
            using (var reader = new StreamReader(responseStream))
            {
                var content = reader.ReadToEnd();
                return content;
            }
        } 
	}
}

