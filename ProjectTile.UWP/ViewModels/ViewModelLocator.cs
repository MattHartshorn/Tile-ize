using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.ServiceLocation;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using ProjectTile.UWP.Views.Pages;

namespace ProjectTile.UWP.ViewModels
{
    class ViewModelLocator
    {
        public static class NavigationPageNames
        {
            public const string Main = "MAIN";
            public const string Home = "HOME";
            public const string Settings = "SETTINGS";
            public const string Theme = "THEME";
            public const string Styles = "STYLES";
        }

        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            // Setup the navigation
            var nav = new NavigationService();
            nav.Configure(NavigationPageNames.Main, typeof(MainPageView));
            nav.Configure(NavigationPageNames.Settings, typeof(SettingsPageView));
            nav.Configure(NavigationPageNames.Home, typeof(HomePageView));
            nav.Configure(NavigationPageNames.Styles, typeof(StylesPageView));
            nav.Configure(NavigationPageNames.Theme, typeof(ThemePageView));


            if (ViewModelBase.IsInDesignModeStatic)
            {
                // Create design time view services and models
            }
            else
            {
                // Create run time view services and models
            }

            SimpleIoc.Default.Register<INavigationService>(() => nav);
            SimpleIoc.Default.Register<MainPageViewModel>();
        }

        public MainPageViewModel MainPage
        {
            get { return ServiceLocator.Current.GetInstance<MainPageViewModel>(); }
        }
    }
}
