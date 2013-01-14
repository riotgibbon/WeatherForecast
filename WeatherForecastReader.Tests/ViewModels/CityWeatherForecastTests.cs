using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Machine.Specifications;
using Moq;
using WeatherForecast.Core;
using WeatherForecast.Core.Domain;
using WeatherForecast.Core.Interfaces;
using WeatherForecast.MVVMCore.Models;
using ThenIt = Machine.Specifications.It;
using MoqIt = Moq.It;

namespace WeatherForecastReader.Tests.CityProvider
{
    [Subject(typeof(CityWeatherForecastSource), "Retrieving weather forecasts for a City")]
    public class CityWeatherForecastTests
    {
        protected static CityWeatherForecastSource CityWeatherForecastSource;
        protected static Mock<IWebTools> mockWebTools;
        protected static City Slough;

        private Establish context = () =>
            {
                mockWebTools = new Mock<IWebTools>();
                Slough = StaticCityProvider.GetCurrentCities().First();
                CityWeatherForecastSource = new CityWeatherForecastSource(mockWebTools.Object);
            };

        private Because of = () =>  CityWeatherForecastSource.GetJsonAsync(Slough) ;

        private ThenIt should_call_WebTools_DownloadString =
            () => mockWebTools.Verify(wb => wb.DownloadString(MoqIt.IsAny<string>()));

        private ThenIt should_call_WebTools_DownloadString_with_correct_url =
            () => mockWebTools.Verify(wb => wb.DownloadString("http://api.wunderground.com/api/8a497054d4f3f9e8/forecast/q/UK/Slough.json"));
    }
}
