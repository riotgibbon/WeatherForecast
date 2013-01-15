using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cirrious.MvvmCross.Core;
using Cirrious.MvvmCross.Interfaces.IoC;
using Cirrious.MvvmCross.Interfaces.ServiceProvider;
using Cirrious.MvvmCross.IoC;
using Cirrious.MvvmCross.Platform;
using Machine.Specifications;
using Moq;
using WeatherForecast.Core;
using WeatherForecast.Core.Domain;
using WeatherForecast.Core.Interfaces;
using WeatherForecast.MVVMCore.Models;
using WeatherForecast.MVVMCore.ViewModels;
using WeatherForecastReader.Tests.Data;
using ThenIt = Machine.Specifications.It;
using MoqIt = Moq.It;

namespace WeatherForecastReader.Tests.ViewModels
{
    public class WithSimpleIoC
    {
        protected static IMvxIoCProvider IoC;

        private Establish context = () =>
                                        {
                                            MvxSingleton.ClearAllSingletons();
                                            IoC = new MvxSimpleIoCServiceProvider();
                                            var serviceProvider = new MvxServiceProvider(IoC);
                                            IoC.RegisterServiceInstance<IMvxServiceProviderRegistry>(serviceProvider);
                                            IoC.RegisterServiceInstance<IMvxServiceProvider>(serviceProvider);
                                        };
    }

    [Subject(typeof(HomeViewModel))]
    public class when_opening_HomeViewModel: WithSimpleIoC
    {
        private static Mock<ICityProvider> mockCityProvider;
        private static Mock<IWebTools> mockWebTools;
        private static HomeViewModel homeViewModel;
        private static List<City> citiesToReturn;
        private static Mock<ICityForecastProvider> mockCityForecastProvider;
        private static List<CityForecast> cityForecasts;
      

        private Establish context = () =>
                                        {
                                            citiesToReturn = MockCityProvider.GetCurrentCities();
                                            mockCityProvider = new Mock<ICityProvider>();
                                            mockCityProvider.Setup(cp => cp.GetCurrentCitiesAsync())
                                                            .Returns(Task.Run(() => citiesToReturn));
                                            IoC.RegisterServiceInstance(mockCityProvider.Object);

                                            mockCityForecastProvider = new Mock<ICityForecastProvider>();
                                            cityForecasts = new List<CityForecast>();
                                            mockCityForecastProvider.Setup(
                                                cfp => cfp.GetCityForecastsAsync(MoqIt.IsAny<List<City>>()))
                                                                    .Returns(Task.Run(() => cityForecasts));
                                            IoC.RegisterServiceInstance(mockCityForecastProvider.Object);
                                            
                                        };
        private Because of = () =>
                                 {
                                     homeViewModel = new HomeViewModel();
                                     
                                 };

        private ThenIt should_call_CityProvider = () => mockCityProvider.Verify( cp =>  cp.GetCurrentCitiesAsync());
        private ThenIt should_map_Cities_to_property = () => homeViewModel.Cities.ShouldEqual(citiesToReturn);

        private ThenIt should_call_Forecast_for_returned_cities =
            () => mockCityForecastProvider.Verify(cf => cf.GetCityForecastsAsync(citiesToReturn));

        private ThenIt should_map_Forecasts_to_property = () => homeViewModel.CityForecasts.ShouldEqual(cityForecasts);

    }
}
