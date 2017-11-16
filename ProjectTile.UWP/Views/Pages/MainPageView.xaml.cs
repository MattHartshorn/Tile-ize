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

namespace ProjectTile.UWP.Views.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPageView : Page
    {
        #region Private Fields
        private AppBarToggleButton ToggleAllAppsBtn;
        #endregion

        #region Constructor
        public MainPageView()
        {
            this.InitializeComponent();
        }
        #endregion

        #region Private Methods
        private void NavigateMenuItem(bool isSettings, string name)
        {
            if (isSettings)
            {
                this.NavView.Header = "Settings";
                this.MainContentSplitView.IsPaneOpen = false;
                this.ToggleAllAppsBtn.IsEnabled = false;
                this.ContentFrame.Navigate(typeof(SettingsPageView));
                return;
            }

            this.ToggleAllAppsBtn.IsEnabled = true;
            SetAllAppsPanelOpenState();

            switch (name.ToLower())
            {
                case "home":
                    this.NavView.Header = "Home";
                    this.ContentFrame.Navigate(typeof(HomePageView));
                    break;
                case "theme":
                    this.NavView.Header = "Theme";
                    this.ContentFrame.Navigate(typeof(ThemePageView));
                    break;
                case "styles":
                    this.NavView.Header = "App Styling";
                    this.ContentFrame.Navigate(typeof(StylesPageView));
                    break;
            }
        }

        private List<FrameworkElement> GetChildren(DependencyObject parent)
        {
            List<FrameworkElement> controls = new List<FrameworkElement>();

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); ++i)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                if (child is FrameworkElement)
                {
                    controls.Add(child as FrameworkElement);
                }
                controls.AddRange(GetChildren(child));
            }

            return controls;
        }

        private void SetAllAppsPanelOpenState()
        {
            this.MainContentSplitView.IsPaneOpen = this.ToggleAllAppsBtn.IsChecked.HasValue ? this.ToggleAllAppsBtn.IsChecked.Value : false;

            this.ToggleAllAppsBtn.Label = (this.MainContentSplitView.IsPaneOpen) ? "Hide Apps" : "Show Apps";
        }
        #endregion

        #region Event Handler Methods
        private void OnNavViewLoaded(object sender, RoutedEventArgs e)
        {
            // Find the App Bar buttons
            var controls = GetChildren(this.NavView);
            ToggleAllAppsBtn = controls.FirstOrDefault(ctrl => ctrl.Name == "ToggleAllAppBtn") as AppBarToggleButton;

            this.NavView.SelectedItem = this.HomeNavItem;
        }

        private void OnNavViewSelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            NavigateMenuItem(args.IsSettingsSelected, (args.SelectedItem as NavigationViewItem).Tag as string);
        }

        private void OnToggleAppsPanelCheckedChanged(object sender, RoutedEventArgs e)
        {
            SetAllAppsPanelOpenState();
        }

        #endregion
    }
}