﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    public class CityForecastProviderTests
    {
        protected static CityForecastProvider cityForecastProvider;
        protected static List<City> cities;
        protected static Mock<IWebTools> mockWebTools;
        protected static List<CityForecast> cityForecasts; 

        private Establish context = () =>
            {
                mockWebTools = new Mock<IWebTools>();
                MockWeatherUndergroundSource mockWeatherUndergroundSource = new MockWeatherUndergroundSource();
                mockWebTools.Setup(m => m.DownloadString(MoqIt.IsAny<string>()))
                            .Returns(mockWeatherUndergroundSource.GetJsonAsync());
                cities = StaticCityProvider.GetCurrentCities();
                cityForecastProvider = new CityForecastProvider(cities, mockWebTools.Object);
            };

        private Because of = async () => cityForecasts = await cityForecastProvider.GetCityForecastsAsync();

        private ThenIt should_call_WebTools_DownloadString_twice =
            () => mockWebTools.Verify(wb => wb.DownloadString(MoqIt.IsAny<string>()), Times.Exactly(2));

        private ThenIt should_return_two_cityForecasts = () => cityForecasts.Count.ShouldEqual(2);

        private ThenIt first_city_should_be_Slough = () => cityForecasts.First().City.ShouldEqual(cities.First());

        private ThenIt first_forecast_should_be_for_Wednesday =
            () => cityForecasts.First().Forecast.txt_forecast.forecastday.First().title.ShouldEqual("Wednesday");
    }
}