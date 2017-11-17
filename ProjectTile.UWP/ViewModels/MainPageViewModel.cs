using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.ServiceLocation;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using ProjectTile.UWP.Services;
using ProjectTile.UWP.Views.Pages;

namespace ProjectTile.UWP.ViewModels
{
    class MainPageViewModel : ViewModelBase
    {
        #region Fields
        private readonly INavigationService _navigationService;

        private string _header;
        private string _toggleAllAppsBtnText;
        private bool _isAllAppsPanelOpen;
        private bool _isAllAppsPanelEnabled;
        private bool _allAppsPanelOpenStateCache;
#       endregion

        #region Constructor
        public MainPageViewModel()
        {
            this._navigationService = ServiceLocator.Current.GetInstance<INavigationService>();
            this.NavigateCommand = new RelayCommand<string>(OnNavigateCommandAction);
        }
        #endregion

        #region Properties

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

        #endregion

        #region Private Methods
        private void OnNavigateCommandAction(string pageTag)
        {
            if (pageTag == "settings")
            {
                this.Header = "Settings";
                this._allAppsPanelOpenStateCache = this.IsAllAppsPanelOpen;
                this.IsAllAppsPanelEnabled = false;
                this.IsAllAppsPanelOpen = false;
                this._navigationService.NavigateTo(ViewModelLocator.NavigationPageNames.Settings);
                return;
            }

            this.IsAllAppsPanelEnabled = true;
            this.IsAllAppsPanelOpen = this._allAppsPanelOpenStateCache;

            switch (pageTag)
            {
                case "home":
                    this.Header = "Home";
                    this._navigationService.NavigateTo(ViewModelLocator.NavigationPageNames.Home);
                    break;
                case "theme":
                    this.Header = "Theme";
                    this._navigationService.NavigateTo(ViewModelLocator.NavigationPageNames.Theme);
                    break;
                case "styles":
                    this.Header = "App Styling";
                    this._navigationService.NavigateTo(ViewModelLocator.NavigationPageNames.Styles);
                    break;
            }
        }
        #endregion
    }
}
