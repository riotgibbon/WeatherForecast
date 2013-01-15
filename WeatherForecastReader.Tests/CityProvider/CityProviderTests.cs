using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Machine.Specifications;
using WeatherForecast.Core.Domain;
using WeatherForecast.MVVMCore.Models;
using WeatherForecastReader.Tests.Data;

namespace WeatherForecastReader.Tests.CityProvider
{
    public class WithStaticCityProvider
    {
        protected static List<City> cities;
        protected static MockCityProvider MockCityProvider;

        private Establish context = () =>
                                        {
                                            MockCityProvider = new MockCityProvider();
                                        };
    }

    public class WithSyncCities : WithStaticCityProvider
    {
        Because of = () => cities = MockCityProvider.GetCurrentCities();
    }

    [Subject(typeof(MockCityProvider), "When reading cities sync")]
    public class WhenReadingCitiesDirectly : WithSyncCities
    {
        private It should_have_2_cities = () => cities.Count.ShouldEqual(2);
        private It first_city_should_be_Slough = () => cities.First().Name.ShouldEqual("Slough");
        private It first_country_should_be_UK = () => cities.First().CountryCode.ShouldEqual("UK");
        private It second_city_should_be_Shanghai = () => cities[1].Name.ShouldEqual("Shanghai");
        private It second_country_should_be_CN = () => cities[1].CountryCode.ShouldEqual("CN");
    }


    [Subject(typeof(MockCityProvider), "When reading cities async")]
    public class WhenReadingCitiesAsync : WithStaticCityProvider
    {
        Because of = () => cities = MockCityProvider.GetCurrentCitiesAsync().Result;
        private It should_have_2_cities = () => cities.Count.ShouldEqual(2);
    }
}
