using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Machine.Specifications;
using WeatherForecast.Core.Domain;
using WeatherForecast.MVVMCore.Models;

namespace WeatherForecastReader.Tests.CityProvider
{
    public class WithStaticCityProvider
    {
        protected static List<City> cities;
        protected static StaticCityProvider staticCityProvider;

        private Establish context = () =>
                                        {
                                            staticCityProvider = new StaticCityProvider();
                                        };
    }

    [Subject("When reading cities sync")]
    public class WhenReadingCitiesDirectly:WithStaticCityProvider
    {
        Because of = () => cities = StaticCityProvider.GetCurrentCities();
        private It should_have_2_cities = () => cities.Count.ShouldEqual(2);
    }

    [Subject("When reading cities async")]
    public class WhenReadingCitiesAsync : WithStaticCityProvider
    {
        Because of = () => cities = staticCityProvider.GetCurrentCitiesAsync().Result;
        private It should_have_2_cities = () => cities.Count.ShouldEqual(2);
    }
}
