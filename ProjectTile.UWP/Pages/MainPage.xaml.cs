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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ProjectTile.UWP.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void OnNavViewLoaded(object sender, RoutedEventArgs e)
        {
            this.NavView.SelectedItem = this.HomeNavItem;
        }


        private void OnNavViewSelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            NavigateMenuItem(args.IsSettingsSelected, (args.SelectedItem as NavigationViewItem).Tag as string);
        }

        private void NavigateMenuItem(bool isSettings, string name)
        {
            if (isSettings)
            {
                this.NavView.Header = "Settings";
                this.ContentFrame.Navigate(typeof(SettingsPage));
                return;
            }


            switch (name.ToLower())
            {
                case "home":
                    this.NavView.Header = "Home";
                    this.ContentFrame.Navigate(typeof(HomePage));
                    break;
                case "theme":
                    this.NavView.Header = "Theme";
                    this.ContentFrame.Navigate(typeof(ThemePage));
                    break;
                case "apps":
                    this.NavView.Header = "Apps & Styles";
                    this.ContentFrame.Navigate(typeof(AppsPage));
                    break;
            }
        }
    }
}