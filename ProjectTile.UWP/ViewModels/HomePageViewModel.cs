using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.ServiceLocation;
using ProjectTile.UWP.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Windows.UI.Xaml;

namespace ProjectTile.UWP.ViewModels
{
    class HomePageViewModel : ViewModelBase
    {
        private readonly MainPageViewModel _mainPageViewModel;

        private string _currentThemeName;
        private int _currentThemeAppCount;
        private string _selectedAppName;
        private Visibility _isSavedThemesVisible;
        private ObservableCollection<ThemeItemViewModel> _savedThemes;
        private ObservableCollection<ThemeItemViewModel> _defaultThemes;


        public HomePageViewModel()
        {
            this._mainPageViewModel = ServiceLocator.Current.GetInstance<MainPageViewModel>();

            this.NavigateEditThemeCommand = new RelayCommand(OnNavigateEditThemeCommandAction);
            this.NavigateEditAppStyleCommand = new RelayCommand(OnNavigateEditAppStyleCommand);

            this._isSavedThemesVisible = Visibility.Collapsed;
            this._savedThemes = new ObservableCollection<ThemeItemViewModel>();
            this._defaultThemes = new ObservableCollection<ThemeItemViewModel>
            {
                new ThemeItemViewModel()
                {
                    ThemeName = "Empty Theme",
                    StyledAppCount = 0,
                }
            };
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

        public Visibility IsSavedThemesVisible
        {
            get { return this._isSavedThemesVisible; }
            set
            {
                this._isSavedThemesVisible = value;
                RaisePropertyChanged(nameof(IsSavedThemesVisible));
            }
        }

        public ObservableCollection<ThemeItemViewModel> SavedThemes
        {
            get { return this._savedThemes; }
            set
            {
                this._savedThemes = value;
                RaisePropertyChanged(nameof(SavedThemes));
            }
        }

        public ObservableCollection<ThemeItemViewModel> DefaultThemes
        {
            get { return this._defaultThemes; }
            set
            {
                this._defaultThemes = value;
                RaisePropertyChanged(nameof(DefaultThemes));
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
