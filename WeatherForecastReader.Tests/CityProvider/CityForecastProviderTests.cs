using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using Moq;
using WeatherForecast.Core;
using WeatherForecast.Core.Domain;
using WeatherForecast.Core.Interfaces;
using WeatherForecast.Core.Services;
using WeatherForecast.MVVMCore.Models;
using WeatherForecastReader.Tests.Data;
using ThenIt = Machine.Specifications.It;
using MoqIt = Moq.It;

namespace WeatherForecastReader.Tests.CityProvider
{
    [Subject(typeof(CityForecastProvider),"Retrieving Forecasts for multiple Cities")]
    public class CityForecastProviderTests
    {
        protected static CityForecastProvider cityForecastProvider;
        protected static List<City> cities;
        protected static Mock<IWebTools> mockWebTools;
        protected static List<CityForecast> cityForecasts; 

        private Establish context = () =>
            {
                mockWebTools = new Mock<IWebTools>();
                var mockWeatherUndergroundSource = new MockWeatherUndergroundSource();
                mockWebTools.Setup(m => m.DownloadString(MoqIt.IsAny<string>()))
                            .Returns(mockWeatherUndergroundSource.GetJsonAsync());
                cities = MockCityProvider.GetCurrentCities();
                cityForecastProvider = new CityForecastProvider(mockWebTools.Object);
            };

        private Because of = async () => cityForecasts = await cityForecastProvider.GetCityForecastsAsync(cities);

        private ThenIt should_call_WebTools_DownloadString_twice =
            () => mockWebTools.Verify(wb => wb.DownloadString(MoqIt.IsAny<string>()), Times.Exactly(2));

        private ThenIt should_return_two_cityForecasts = () => cityForecasts.Count.ShouldEqual(2);

        private ThenIt first_city_should_be_Slough = () => cityForecasts.First().City.ShouldEqual(cities.First());

        private ThenIt first_forecast_should_be_for_Wednesday =
            () => cityForecasts.First().Forecast.txt_forecast.forecastday.First().title.ShouldEqual("Wednesday");

        private ThenIt now_should_be_period_0 = () => cityForecasts.First().Now.period.ShouldEqual(0);
        private ThenIt now_should_be_partly_cloudy = () => cityForecasts.First().Now.icon.ShouldEqual("partlycloudy");
        
    }
}
