using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ProjectTile.UWP.Services;
using ProjectTile.UWP.Views.Pages;

namespace ProjectTile.UWP.ViewModels
{
    class MainPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        private string _header;
        private string _toggleAllAppsBtnText;
        private bool _isAllAppsPanelOpen;
        private bool _isAllAppsPanelEnabled;
        private bool _allAppsPanelOpenStateCache;


        public MainPageViewModel(INavigationService navigationService)
        {
            if (navigationService == null)
                throw new ArgumentNullException();

            this._navigationService = navigationService;
            this.NavigateCommand = new RelayCommand<string>(OnNavigateCommandAction);
        }


        public string Header
        {
            get { return this._header; }
            set
            {
                this._header = value;
                RaisePropertyChanged(nameof(Header));
            }
        }

        public string ToggleAllAppsBtnText
        {
            get { return this._toggleAllAppsBtnText; }
            set
            {
                this._toggleAllAppsBtnText = value;
                RaisePropertyChanged(nameof(ToggleAllAppsBtnText));
            }
        }

        public bool IsAllAppsPanelOpen
        {
            get { return this._isAllAppsPanelOpen; }
            set
            {
                this._isAllAppsPanelOpen = value;
                RaisePropertyChanged(nameof(IsAllAppsPanelOpen));
            }
        }

        public bool IsAllAppsPanelEnabled
        {
            get { return this._isAllAppsPanelEnabled; }
            set
            {
                this._isAllAppsPanelEnabled = value;
                RaisePropertyChanged(nameof(IsAllAppsPanelEnabled));
            }
        }

        public RelayCommand<string> NavigateCommand
        {
            get;
        }


        private void OnNavigateCommandAction(string pageTag)
        {
            if (pageTag == "settings")
            {
                this.Header = "Settings";
                this._allAppsPanelOpenStateCache = this.IsAllAppsPanelOpen;
                this.IsAllAppsPanelEnabled = false;
                this.IsAllAppsPanelOpen = false;
                return;
            }

            this.IsAllAppsPanelEnabled = true;
            this.IsAllAppsPanelOpen = this._allAppsPanelOpenStateCache;

            switch (pageTag)
            {
                case "home":
                    this.Header = "Home";
                    this._navigationService.Navigate(typeof(HomePageView));
                    break;
                case "theme":
                    this.Header = "Theme";
                    this._navigationService.Navigate(typeof(ThemePageView));
                    break;
                case "styles":
                    this.Header = "App Styling";
                    this._navigationService.Navigate(typeof(StylesPageView));
                    break;
            }
        }
    }
}
