using System;
using System.IO;
using System.Net;
using System.Text;
using Microsoft.SPOT;

namespace ColdAlert
{
    public interface WeatherSource
    {
        string GetWeatherData(string period);
    }

    public  class  JsonWeatherSource: WeatherSource
    {
        public string GetWeatherData(string period)
        {
            string requestUri="http://weatherpreview.azurewebsites.net/api/forecast/" + period ;
            byte[] buffer;
            Stream stream;
            HttpWebResponse response;
           
                using (var request = (HttpWebRequest) WebRequest.Create(requestUri))
                {
                    response = (HttpWebResponse) request.GetResponse();
                }

                buffer = new byte[response.ContentLength]; 
                stream = response.GetResponseStream();
            
            int read;
            using (var ms = new MemoryStream())
            {
                while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
            }
            char[] chars = Encoding.UTF8.GetChars(buffer);
            var text = new string(chars);
            
            return text;

        }
    }

}
