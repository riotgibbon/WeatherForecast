using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WeatherForecast.MVVMCore.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace WeatherForecast.MVX.WinRT.Views
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class CityView : WeatherForecast.MVX.WinRT.Common.LayoutAwarePage
    {
        public CityView()
        {
            this.InitializeComponent();
        }

        

        public new CityViewModel ViewModel
        {
            get { return (CityViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }

       
    }
}
