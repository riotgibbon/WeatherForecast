using Cirrious.MvvmCross.Application;
using Cirrious.MvvmCross.Platform;
using Cirrious.MvvmCross.WindowsPhone.Platform;
using Microsoft.Phone.Controls;
using WeatherForecast.MVVMCore;

namespace WeatherForecast.MVX.WP8
{
    public class Setup
        : MvxBaseWindowsPhoneSetup
    {
        public Setup(PhoneApplicationFrame rootFrame) 
            : base(rootFrame)
        {
        }

        protected override Cirrious.MvvmCross.Interfaces.IoC.IMvxIoCProvider CreateIocProvider()
        {
            return new MvxAutofacIoCServiceProvider();
        }
        protected override MvxApplication CreateApp()
        {
            return new WeatherForecastApp();
        }

        protected override void InitializeDefaultTextSerializer()
        {
            Cirrious.MvvmCross.Plugins.Json.PluginLoader.Instance.EnsureLoaded(true);
        }

        protected override void AddPluginsLoaders(MvxLoaderPluginRegistry registry)
        {
            registry.AddConventionalPlugin<Cirrious.MvvmCross.Plugins.Visibility.WindowsPhone.Plugin>();
            base.AddPluginsLoaders(registry);
        }
    }
}
