using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using ProjectTile.Common;
using ProjectTile.UWP.Services;
using Microsoft.Practices.ServiceLocation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ProjectTile.UWP.Views.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPageView : Page
    {
        public MainPageView()
        {
            this.InitializeComponent();
        }

        private void OnNavViewLoaded(object sender, RoutedEventArgs e)
        {
            var navSerivce = ServiceLocator.Current.GetInstance<INavigationService>();
            navSerivce.NavigationFrame = this.ContentFrame;

            this.NavView.SelectedItem = this.NavView.MenuItems[0];
        }
    }
}