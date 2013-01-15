using Cirrious.MvvmCross.WindowsPhone.Views;
using WeatherForecast.MVVMCore.ViewModels;

namespace WeatherForecast.WP7.Views
{
    public partial class HomeView 
        : BaseHomeView
    {
        public HomeView()
        {
            InitializeComponent();
        }
    }

    public class BaseHomeView : MvxPhonePage<HomeViewModel>
    {
    }
}