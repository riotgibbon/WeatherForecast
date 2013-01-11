using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;

namespace ColdAlert.Tests
{
    [Subject ("reading Weather Underground data")]
    public class when_reading_weather_records
    {
        static string expectedTemp;
        private static WeatherSource weatherSource;
        private static WeatherReader weatherReader;

        Establish context = () =>
                                {
                                    expectedTemp = string.Empty;
                                    weatherSource = new JsonWeatherSource();
                                    weatherReader = new WeatherReader(weatherSource);
                                };

        Because of = () => expectedTemp = weatherReader.GetTemp("1");

        It should_be_15 = () =>
            expectedTemp.ShouldEqual<string>("15");
    }
}
