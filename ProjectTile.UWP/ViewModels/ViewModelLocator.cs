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
            nav.Configure(NavigationPageKeys.SelectApp, typeof(SelectAppPageView));


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
        }

        public MainPageViewModel MainPage
        {
            get { return ServiceLocator.Current.GetInstance<MainPageViewModel>(); }
        }

        public HomePageViewModel HomePage
        {
            get { return ServiceLocator.Current.GetInstance<HomePageViewModel>(); }
        }
    }
}
