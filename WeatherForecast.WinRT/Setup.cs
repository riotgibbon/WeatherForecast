using Cirrious.MvvmCross.Application;
using Cirrious.MvvmCross.Interfaces.ServiceProvider;
using Cirrious.MvvmCross.WinRT.Platform;
using WeatherForecast.MVVMCore;
using Windows.UI.Xaml.Controls;
using Cirrious.MvvmCross.ExtensionMethods;

namespace WeatherForecast.WinRT
{
    public class Setup
        : MvxBaseWinRTSetup
    {
        private WeatherForecastApp _app;

        public Setup(Frame rootFrame)
            : base(rootFrame)
        {
        }


        protected override Cirrious.MvvmCross.Interfaces.IoC.IMvxIoCProvider CreateIocProvider()
        {
            return base.CreateIocProvider();
        }

        protected override void InitializeLastChance()
        {
            
            base.InitializeLastChance();
        }
        protected override MvxApplication CreateApp()
        {
            _app = new WeatherForecastApp();
            return _app;
        }

        protected override void AddPluginsLoaders(Cirrious.MvvmCross.Platform.MvxLoaderPluginRegistry loaders)
        {
            loaders.AddConventionalPlugin<Cirrious.MvvmCross.Plugins.Visibility.WinRT.Plugin>();
            base.AddPluginsLoaders(loaders);
        }
        protected override void InitializeIoC()
        {
            
            base.InitializeIoC();

        }
    }
}
