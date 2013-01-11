using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Machine.Specifications;
using WeatherForecast.Core;

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

        Because of = async () => expectedTemp = await weatherReader.GetPeriodMinTempAsync(1);

        It should_be_valid = () =>
            expectedTemp.ShouldNotBeNull();
    }


}
