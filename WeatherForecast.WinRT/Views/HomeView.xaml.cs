using WeatherForecast.MVVMCore.ViewModels;
using WeatherForecast.MVX.WinRT.Common;
using Windows.UI.Xaml;

// The Items Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234233

namespace WeatherForecast.MVX.WinRT.Views
{
    /// <summary>
    /// A page that displays a collection of item previews.  In the Split Application this page
    /// is used to display and select one of the available groups.
    /// </summary>
    public sealed partial class HomeView : LayoutAwarePage
    {

        public HomeView()
        {
            this.InitializeComponent();
        }

        public new HomeViewModel ViewModel
        {
            get { return (HomeViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }


    }
}
