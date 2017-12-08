using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.ServiceLocation;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using ProjectTile.UWP.Services;
using ProjectTile.UWP.Views.Pages;

namespace ProjectTile.UWP.ViewModels
{
    class ViewModelLocator
    {

        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            // Setup the navigation
            var nav = new NavigationService();
            nav.Configure(NavigationPageKeys.Main, typeof(MainPageView));
            nav.Configure(NavigationPageKeys.Settings, typeof(SettingsPageView));
            nav.Configure(NavigationPageKeys.Home, typeof(HomePageView));
            nav.Configure(NavigationPageKeys.Theme, typeof(ThemePageView));
            nav.Configure(NavigationPageKeys.Styles, typeof(StylesPageView));


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
            SimpleIoc.Default.Register<HomePageViewModel>();
            SimpleIoc.Default.Register<ThemePageViewModel>();
            SimpleIoc.Default.Register<StylesPageViewModel>();
        }

        public MainPageViewModel MainPage
        {
            get { return ServiceLocator.Current.GetInstance<MainPageViewModel>(); }
        }

        public HomePageViewModel HomePage
        {
            get { return ServiceLocator.Current.GetInstance<HomePageViewModel>(); }
        }

        public ThemePageViewModel ThemePage
        {
            get { return ServiceLocator.Current.GetInstance<ThemePageViewModel>(); }
        }

        public StylesPageViewModel StylesPage
        {
            get { return ServiceLocator.Current.GetInstance<StylesPageViewModel>(); }
        }
    }
}
