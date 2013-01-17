using Cirrious.MvvmCross.Application;
using Cirrious.MvvmCross.ExtensionMethods;
using Cirrious.MvvmCross.Interfaces.ServiceProvider;
using Cirrious.MvvmCross.Interfaces.ViewModels;
using WeatherForecast.Core;
using WeatherForecast.Core.Interfaces;
using WeatherForecast.Core.Services;
using WeatherForecast.MVVMCore.Models;
using WeatherForecast.MVVMCore.Service;

namespace WeatherForecast.MVVMCore
{
    public class WeatherForecastApp
        : MvxApplication
        , IMvxServiceProducer
    {
        public WeatherForecastApp()
        {
            InitaliseServices();
            InitialiseStartNavigation();
            InitialisePlugIns();
        }

        
        
        private void InitaliseServices()
        {

            this.RegisterServiceType<ICityProvider,StaticCityProvider>();
           this.RegisterServiceType<IWebTools, PortableWebTools>();
           this.RegisterServiceType<ICityForecastProvider, CityForecastProvider>();
        }

        private void InitialiseStartNavigation()
        {
            var startApplicationObject = new StartNavigation();
            this.RegisterServiceInstance<IMvxStartNavigation>(startApplicationObject);
        }

        private void InitialisePlugIns()
        {
            Cirrious.MvvmCross.Plugins.Visibility.PluginLoader.Instance.EnsureLoaded();
            Cirrious.MvvmCross.Plugins.JsonLocalisation.PluginLoader.Instance.EnsureLoaded();
        }
    }
}
