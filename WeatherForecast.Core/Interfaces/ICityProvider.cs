using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Core.Domain;

namespace WeatherForecast.Core.Interfaces
{
    public interface ICityProvider
    {
        Task<List<City>> GetCurrentCitiesAsync();
    }
}
