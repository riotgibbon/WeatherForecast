﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Machine.Specifications;

namespace WeatherForecastReader.Tests
{
    public class LiveForecastBase
    {
        protected static string expectedTemp;
        protected static WeatherUndergroundSource weatherSource;
        protected static WeatherUndergroundReader weatherReader;

        Establish context = () =>
        {
            expectedTemp = string.Empty;
            weatherSource = new LiveWeatherUndergroundSource();
            weatherReader = new WeatherUndergroundReader(weatherSource);
        };

    }


    [Subject("reading Live data")]
    public class WhenReadingLiveForecast: LiveForecastBase
    {
       
        Because of = () => expectedTemp = weatherReader.GetPeriodTemp(1);

        It should_be_valid = () =>
            expectedTemp.ShouldNotBeNull();
    }


}