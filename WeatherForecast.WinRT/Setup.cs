using Cirrious.MvvmCross.Application;
using Cirrious.MvvmCross.WinRT.Platform;
using TwitterSearch.Core;
using Windows.UI.Xaml.Controls;

namespace WeatherForecast.WinRT
{
    public class Setup
        : MvxBaseWinRTSetup
    {
        public Setup(Frame rootFrame)
            : base(rootFrame)
        {
        }

        protected override MvxApplication CreateApp()
        {
            var app = new WeatherForecastApp();
            return app;
        }

        protected override void AddPluginsLoaders(Cirrious.MvvmCross.Platform.MvxLoaderPluginRegistry loaders)
        {
            loaders.AddConventionalPlugin<Cirrious.MvvmCross.Plugins.Visibility.WinRT.Plugin>();
            base.AddPluginsLoaders(loaders);
        }
    }
}
