﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Machine.Specifications;

namespace WeatherForecastReader.Tests
{
    public class JsonForecastBase
    {
        protected static string expectedTemp;
        protected static WeatherUndergroundSource weatherSource;
        protected static WeatherUndergroundReader weatherReader;

        Establish context = () =>
        {
            expectedTemp = string.Empty;
            weatherSource = new MockWeatherUndergroundSource();
            weatherReader = new WeatherUndergroundReader(weatherSource);
        };

    }


    [Subject("reading Period 1 data")]
    public class WhenReadingJsonForecastPeriod1Data : JsonForecastBase
    {
       
        Because of = () => expectedTemp = weatherReader.GetPeriodTemp(1);

        It should_be_4 = () =>
            expectedTemp.ShouldEqual<string>("4");
    }

    [Subject("reading Period 2 data")]
    public class WhenReadingJsonForecastPeriod2Data : JsonForecastBase
    {

        Because of = () => expectedTemp = weatherReader.GetPeriodTemp(2);

        It should_be_3 = () =>
            expectedTemp.ShouldEqual<string>("3");
    }
}