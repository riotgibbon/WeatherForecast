using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Cirrious.MvvmCross.WindowsPhone.Views;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using WeatherForecast.MVVMCore.ViewModels;

namespace WeatherForecast.MVX.WP8.Views
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