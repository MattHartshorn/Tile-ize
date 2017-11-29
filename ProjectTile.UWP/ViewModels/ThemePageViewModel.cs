using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.ServiceLocation;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace ProjectTile.UWP.ViewModels
{
    class ThemePageViewModel : ViewModelBase
    {
        private readonly MainPageViewModel _mainPageViewModel;

        private string _toggleAllAppsText;
        private AppViewModel _selectedApp;


        public ThemePageViewModel()
        {
            this.ToggleAllAppsText = "Show All Applications";

            this._mainPageViewModel = ServiceLocator.Current.GetInstance<MainPageViewModel>();
            this._mainPageViewModel.PropertyChanged += OnMainPageViewModelPropertyChanged;

            this.ApplyCommand = new RelayCommand(OnApplyCommandAction);
            this.SaveCommand = new RelayCommand(OnSaveCommandAction);
            this.SaveAsCommand = new RelayCommand(OnSaveAsCommandAction);
            this.DeleteCommand = new RelayCommand(OnDeleteCommandAction);
            this.BrowseCommand = new RelayCommand(OnBrowseCommandAction);
            this.ToggleAllAppsCommand = new RelayCommand(OnToggleAllAppsCommandAction);
            this.ResetStylesCommand = new RelayCommand(OnResetStylesCommandAction);
            this.ClearStylesCommand = new RelayCommand(OnClearStylesCommandAction);

            InitData();
        }


        public string BackgroundImageSource
        {
            get;
            set;
        }

        public ObservableCollection<string> AppColors
        {
            get;
            set;
        }

        public string ThemeName
        {
            get;
            set;
        }

        public ObservableCollection<string> RecentBackgroundImages
        {
            get;
            set;
        }

        public string SelectedRecentBackgroundImage
        {
            get;
            set;
        }

        public string ToggleAllAppsText
        {
            get { return this._toggleAllAppsText; }
            set
            {
                this._toggleAllAppsText = value;
                RaisePropertyChanged(nameof(ToggleAllAppsText));
            }
        }

        public string AppsQueryText
        {
            get;
            set;
        }

        public ObservableCollection<AppViewModel> StyledAppsSource
        {
            get;
            set;
        }

        public bool IsSaveEnabled
        {
            get;
            set;
        }

        public bool IsDeleteEnabled
        {
            get;
            set;
        }

        public bool IsResetStylesEnabled
        {
            get;
            set;
        }

        public bool IsClearStylesEnabled
        {
            get;
            set;
        }

        public AppViewModel SelectedApp
        {
            get { return this._selectedApp; }
            set
            {
                this._selectedApp = value;
                RaisePropertyChanged(nameof(SelectedApp));

                if (value != null)
                {
                    this._mainPageViewModel.SelectNavigationItem(NavigationPageKeys.Styles);
                }
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

        public RelayCommand DeleteCommand
        {
            get;
        }

        public RelayCommand BrowseCommand
        {
            get;
        }

        public RelayCommand ToggleAllAppsCommand
        {
            get;
        }

        public RelayCommand ResetStylesCommand
        {
            get;
        }

        public RelayCommand ClearStylesCommand
        {
            get;
        }


        private void InitData()
        {
            this.ThemeName = "Test Theme";
            this.AppColors = new ObservableCollection<string>{
                "#1867E6",
                "#326336",
            };
            this.RecentBackgroundImages = new ObservableCollection<string>
            {
                "ms-appx:///Assets/bg1.png",
                "ms-appx:///Assets/bg2.png",
            };
            this.StyledAppsSource = new ObservableCollection<AppViewModel>
            {
                new AppViewModel(1)
                {
                    BackgroundColor = "#1867E6",
                    DisplayName = "Demo App",
                    IconSource = "ms-appx:///Assets/Square44x44Logo.scale-100.png"
                },
                new AppViewModel(2)
                {
                    BackgroundColor = "#326336",
                    DisplayName = "Notepad++",
                    IconSource = "ms-appx:///Assets/notepad++.png"
                }
            };
            this.IsResetStylesEnabled = true;
            this.IsClearStylesEnabled = true;
        }

        private void OnToggleAllAppsCommandAction()
        {
            this._mainPageViewModel.IsAllAppsPanelOpen = !this._mainPageViewModel.IsAllAppsPanelOpen;
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

        private void OnDeleteCommandAction()
        {

        }

        private void OnBrowseCommandAction()
        {

        }

        private void OnResetStylesCommandAction()
        {
            this.StyledAppsSource?.Clear();
            this.IsResetStylesEnabled = false;
            this.IsClearStylesEnabled = false;
        }

        private void OnClearStylesCommandAction()
        {
            this.StyledAppsSource?.Clear();
            this.IsResetStylesEnabled = false;
            this.IsClearStylesEnabled = false;
        }

        private void OnMainPageViewModelPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(this._mainPageViewModel.IsAllAppsPanelOpen))
                UpdateToggleAppsText();
        }


        private void UpdateToggleAppsText()
        {
            this.ToggleAllAppsText = (this._mainPageViewModel.IsAllAppsPanelOpen) ? "Hide All Applications" : "Show All Applications";
        }
    }
}
