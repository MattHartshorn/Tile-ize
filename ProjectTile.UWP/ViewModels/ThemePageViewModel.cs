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
            get;
            set;
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
                "#E61818",
                "#1867E6",
            };
            this.RecentBackgroundImages = new ObservableCollection<string>
            {
                "ms-appx:///Assets/bg1.png"
            };
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

        }

        private void OnClearStylesCommandAction()
        {
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
