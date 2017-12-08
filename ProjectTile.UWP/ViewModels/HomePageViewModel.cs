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
        #region Private Fields
        private readonly MainPageViewModel _mainPageViewModel;

        private string _currentThemeName;
        private int _currentThemeAppCount;
        private string _currentThemeBackgroundSource;
        private ObservableCollection<string> _currentThemeAppColors;
        private string _selectedAppName;
        private Visibility _isSavedThemesVisible;
        private ObservableCollection<ThemeItemViewModel> _savedThemesSource;
        private ObservableCollection<ThemeItemViewModel> _defaultThemesSource;
        private ThemeItemViewModel _selectedSavedTheme;
        private ThemeItemViewModel _selectedDefaultTheme;
        private bool _isSaveEnabled;
        #endregion

        #region Constructor
        public HomePageViewModel()
        {
            this._mainPageViewModel = ServiceLocator.Current.GetInstance<MainPageViewModel>();

            this.NavigateEditThemeCommand = new RelayCommand(OnNavigateEditThemeCommandAction);
            this.NavigateEditAppStyleCommand = new RelayCommand(OnNavigateEditAppStyleCommandAction);
            this.ApplyCommand = new RelayCommand(OnApplyCommandAction);
            this.SaveAsCommand = new RelayCommand(OnSaveAsCommandAction);
            this.SaveCommand = new RelayCommand(OnSaveCommandAction);

            this._isSavedThemesVisible = Visibility.Collapsed;
            this._defaultThemesSource = new ObservableCollection<ThemeItemViewModel>
            {
                new ThemeItemViewModel()
                {
                    ThemeName = "Default Theme",
                    StyledAppCount = 0,
                },
                new ThemeItemViewModel()
                {
                    ThemeName = "Empty Theme",
                    StyledAppCount = 0,
                }
            };
            InitData();
        }
        #endregion

        #region Properties
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

        public string CurrentThemeBackgroundSource
        {
            get { return this._currentThemeBackgroundSource; }
            set
            {
                this._currentThemeBackgroundSource = value;
                RaisePropertyChanged(nameof(CurrentThemeBackgroundSource));
            }
        }

        public ObservableCollection<string> CurrentThemeAppColors
        {
            get { return this._currentThemeAppColors; }
            set
            {
                this._currentThemeAppColors = value;
                RaisePropertyChanged(nameof(CurrentThemeAppColors));
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

        public ObservableCollection<ThemeItemViewModel> SavedThemesSource
        {
            get { return this._savedThemesSource; }
            set
            {
                this._savedThemesSource = value;
                RaisePropertyChanged(nameof(SavedThemesSource));
                this.IsSavedThemesVisible = (value != null && value.Count > 0) ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        public ThemeItemViewModel SelectedSavedTheme
        {
            get { return this._selectedSavedTheme; }
            set
            {
                this._selectedSavedTheme = value;
                RaisePropertyChanged(nameof(SelectedSavedTheme));
            }
        }

        public ObservableCollection<ThemeItemViewModel> DefaultThemesSource
        {
            get { return this._defaultThemesSource; }
            set
            {
                this._defaultThemesSource = value;
                RaisePropertyChanged(nameof(DefaultThemesSource));
            }
        }

        public ThemeItemViewModel SelectedDefaultTheme
        {
            get { return this._selectedDefaultTheme; }
            set
            {
                this._selectedDefaultTheme = value;
                RaisePropertyChanged(nameof(SelectedDefaultTheme));
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

        public bool IsSaveEnabled
        {
            get { return this._isSaveEnabled; }
            set
            {
                this._isSaveEnabled = value;
                RaisePropertyChanged(nameof(IsSaveEnabled));
            }
        }

        public RelayCommand ApplyCommand
        {
            get;
        }

        public RelayCommand SaveCommand
        {
            get;
        }

        public RelayCommand SaveAsCommand
        {
            get;
        }
        #endregion

        #region Private Methods
        private void InitData()
        {
            this.CurrentThemeName = "Test Theme";
            this.CurrentThemeAppColors = new ObservableCollection<string>{
                "#E61818",
                "#1867E6",
            };
            this.CurrentThemeAppCount = 2;
            this.CurrentThemeBackgroundSource = "ms-appx:///Assets/bg1.png";

            this.SavedThemesSource = new ObservableCollection<ThemeItemViewModel>
            {
                new ThemeItemViewModel()
                {
                    ThemeName = "Test Theme",
                    StyledAppCount = 2,
                    AppColorHexItems = new ObservableCollection<string>{
                        "#1867E6",
                        "#326336",
                    },
                    ImageSourceUri = "ms-appx:///Assets/bg1.png"
                }
            };
        }

        private void OnNavigateEditThemeCommandAction()
        {
            this._mainPageViewModel.SelectNavigationItem(NavigationPageKeys.Theme);
        }

        private void OnNavigateEditAppStyleCommandAction()
        {
            this._mainPageViewModel.SelectNavigationItem(NavigationPageKeys.Styles);
        }

        private void OnApplyCommandAction()
        {

        }

        private void OnSaveCommandAction()
        {

        }

        private void OnSaveAsCommandAction()
        {

        }
        #endregion
    }
}
