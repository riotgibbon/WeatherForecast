using Cirrious.MvvmCross.Core;
using Cirrious.MvvmCross.Interfaces.IoC;
using Cirrious.MvvmCross.Interfaces.ServiceProvider;
using Cirrious.MvvmCross.Interfaces.Views;
using Cirrious.MvvmCross.Platform;
using Cirrious.MvvmCross.Views;
using Machine.Specifications;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherForecast.Core.Domain;
using WeatherForecast.Core.Interfaces;
using WeatherForecast.Core.Services;
using WeatherForecast.MVVMCore.IoC;
using WeatherForecast.MVVMCore.Models;
using WeatherForecast.MVVMCore.ViewModels;
using WeatherForecastReader.Tests.Data;
using MoqIt = Moq.It;
using ThenIt = Machine.Specifications.It;

namespace WeatherForecastReader.Tests.ViewModels
{
    public class WithSimpleIoC
    {
        protected static IMvxIoCProvider IoC;
       
        private Establish context = () =>
                                        {
                                            MvxSingleton.ClearAllSingletons();
                                            IoC = new MvxAutofacIoCServiceProvider();
                                            var serviceProvider = new MvxServiceProvider(IoC);
                                            IoC.RegisterServiceInstance<IMvxServiceProviderRegistry>(serviceProvider);
                                            IoC.RegisterServiceInstance<IMvxServiceProvider>(serviceProvider);
                                       
                                        };
    }

    [Subject(typeof (HomeViewModel))]
    public class with_HomeViewModel : WithSimpleIoC
    {
        protected static Mock<ICityProvider> mockCityProvider;
        protected static Mock<IWebTools> mockWebTools;
        protected static HomeViewModel homeViewModel;
        protected static List<City> citiesToReturn;
        protected static Mock<ICityForecastProvider> mockCityForecastProvider;
        protected static List<CityForecast> cityForecasts;
        protected static Mock<IMvxViewDispatcher> mockViewDispatcher;


        private Establish context = () =>
                                        {
                                            citiesToReturn = MockCityProvider.GetCurrentCities();
                                            mockCityProvider = new Mock<ICityProvider>();
                                            mockCityProvider.Setup(cp => cp.GetCurrentCitiesAsync())
                                                            .Returns(Task.Run(() => citiesToReturn));
                                            IoC.RegisterServiceInstance(mockCityProvider.Object);

                                            mockCityForecastProvider = new Mock<ICityForecastProvider>();
                                            cityForecasts = StaticCityProvider.MockCityForecasts;
                                            mockCityForecastProvider.Setup(
                                                cfp => cfp.GetCityForecastsAsync(MoqIt.IsAny<List<City>>()))
                                                                    .Returns(Task.Run(() => cityForecasts));
                                            IoC.RegisterServiceInstance(mockCityForecastProvider.Object);


                                            mockViewDispatcher = new Mock<IMvxViewDispatcher>();
                                            var mockViewDispatcherProvider = new Mock<IMvxViewDispatcherProvider>();
                                            mockViewDispatcherProvider.Setup(vdp => vdp.Dispatcher)
                                                                      .Returns(mockViewDispatcher.Object);
                                            IoC.RegisterServiceInstance(mockViewDispatcherProvider.Object);
                                        };

        
    }

    [Subject(typeof(HomeViewModel))]
    public class when_opening_HomeViewModel:with_HomeViewModel
    {
        private Because of = () => homeViewModel = new HomeViewModel();
        private ThenIt should_call_CityProvider = () => mockCityProvider.Verify( cp =>  cp.GetCurrentCitiesAsync());
        private ThenIt should_map_Cities_to_property = () => homeViewModel.Cities.ShouldEqual(citiesToReturn);

        private ThenIt should_call_Forecast_for_returned_cities =
            () => mockCityForecastProvider.Verify(cf => cf.GetCityForecastsAsync(citiesToReturn));

        private ThenIt should_map_Forecasts_to_property = () => 
            homeViewModel.CityForecasts[0].Item.ShouldEqual(cityForecasts[0]);

    }
    //TODO - not valid
    [Subject(typeof(HomeViewModel))]
    public class when_selecting_City : with_HomeViewModel
    {


        protected static CityForecast SelectedCityForecast;

        private Because of = () =>
            {
                homeViewModel = new HomeViewModel();
                homeViewModel.CityForecasts[0].Command.Execute(null);
            };
        private ThenIt should_call_RequestNavigate =
            () =>
                mockViewDispatcher.Verify(vd => vd.RequestNavigate(MoqIt.IsAny<MvxShowViewModelRequest>()));

        private ThenIt should_call_RequestNavigate_to_CityViewModel =
            () => mockViewDispatcher.Verify(
                vd => vd.RequestNavigate(MoqIt.Is<MvxShowViewModelRequest>(request => request.ViewModelType == typeof(CityViewModel))));

        private ThenIt should_call_RequestNavigate_with_forecastJson_Parameter =
           () => mockViewDispatcher.Verify(
               vd => vd.RequestNavigate(MoqIt.Is<MvxShowViewModelRequest>(request => request.ParameterValues.First().Key == "forecastJson")));
    }
}
