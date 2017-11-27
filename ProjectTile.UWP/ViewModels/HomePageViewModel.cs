using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.ServiceLocation;
using ProjectTile.UWP.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace ProjectTile.UWP.ViewModels
{
    class HomePageViewModel : ViewModelBase
    {
        private readonly MainPageViewModel _mainPageViewModel;

        private string _currentThemeName;
        private int _currentThemeAppCount;
        private string _selectedAppName;


        public HomePageViewModel()
        {
            this._mainPageViewModel = ServiceLocator.Current.GetInstance<MainPageViewModel>();

            this.NavigateEditThemeCommand = new RelayCommand(OnNavigateEditThemeCommandAction);
            this.NavigateEditAppStyleCommand = new RelayCommand(OnNavigateEditAppStyleCommand);
        }


        public string CurrentThemeName
        {
            get { return this._currentThemeName; }
            set
            {
                this._currentThemeName = value;
                RaisePropertyChanged(nameof(CurrentThemeName));
            }
        }

        public int CurrentThemeAppCount
        {
            get { return this._currentThemeAppCount; }
            set
            {
                this._currentThemeAppCount = value;
                RaisePropertyChanged(nameof(CurrentThemeAppCount));
            }
        }

        public string SelectedAppName
        {
            get { return this._selectedAppName ?? "No App Selected"; }
            set
            {
                this._selectedAppName = value;
                RaisePropertyChanged(nameof(SelectedAppName));
            }
        }

        public RelayCommand NavigateEditThemeCommand
        {
            get;
        }

        public RelayCommand NavigateEditAppStyleCommand
        {
            get;
        }


        private void OnNavigateEditThemeCommandAction()
        {
            this._mainPageViewModel.SelectNavigationItem(NavigationPageKeys.Theme);
        }

        private void OnNavigateEditAppStyleCommand()
        {
            this._mainPageViewModel.SelectNavigationItem(NavigationPageKeys.Styles);
        }
    }
}
