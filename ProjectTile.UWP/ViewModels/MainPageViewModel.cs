using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.ServiceLocation;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ProjectTile.UWP.Services;
using ProjectTile.UWP.Views.Pages;

namespace ProjectTile.UWP.ViewModels
{
    class MainPageViewModel : ViewModelBase
    {
        #region Fields
        private readonly INavigationService _navigationService;

        private ObservableCollection<NavigationMenuItemViewModel> _navMenuItems;
        private object _selectedNavItem;
        private string _header;
        private string _toggleAllAppsBtnText;
        private bool _isAllAppsPanelOpen;
        private bool _isAllAppsPanelEnabled;
        private bool _allAppsPanelOpenStateCache;
        private bool _isSaveRequired;
#       endregion

        #region Constructor
        public MainPageViewModel()
        {
            this.IsSaveRequired = false;
            this.IsAllAppsPanelEnabled = true;

            this._navMenuItems = new ObservableCollection<NavigationMenuItemViewModel>
            {
                new NavigationMenuItemViewModel("Home", "\uE10F", NavigationPageKeys.Home),
                new NavigationMenuItemViewModel("Theme", "\uE771", NavigationPageKeys.Theme),
                new NavigationMenuItemViewModel("App Styling", "\uED63", NavigationPageKeys.Styles)
            };

            this._navigationService = ServiceLocator.Current.GetInstance<INavigationService>();
            this.AllAppsToggleCommand = new RelayCommand(OnAllAppsToggleCommandAction, () => this.IsAllAppsPanelEnabled);
            this.SaveCommand = new RelayCommand(OnSaveCommandAction, () => this.IsSaveRequired);
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

        public ObservableCollection<NavigationMenuItemViewModel> NavigationMenuItems
        {
            get { return this._navMenuItems; }
            set
            {
                this._navMenuItems = value;
                RaisePropertyChanged(nameof(NavigationMenuItems));
            }
        }

        public object SelectedNavigationItem
        {
            get { return this._selectedNavItem; }
            set
            {
                this._selectedNavItem = value;
                RaisePropertyChanged(nameof(SelectedNavigationItem));
                OnSelectedNavigationItemChanged();
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

        public bool IsSaveRequired
        {
            get { return this._isSaveRequired; }
            set
            {
                this._isSaveRequired = value;
                RaisePropertyChanged(nameof(IsSaveRequired));
            }
        }

        public RelayCommand AllAppsToggleCommand
        {
            get;
        }

        public RelayCommand SaveCommand
        {
            get;
        }
        #endregion

        #region Private Methods
        private void OnSelectedNavigationItemChanged()
        {
            var selectedItem =  this.SelectedNavigationItem as NavigationMenuItemViewModel;
            if (selectedItem != null)
            {
                this.IsAllAppsPanelEnabled = true;
                this.IsAllAppsPanelOpen = this._allAppsPanelOpenStateCache;

                switch (selectedItem.Tag)
                {
                    case NavigationPageKeys.Home:
                        this.Header = "Home";
                        break;
                    case NavigationPageKeys.Theme:
                        this.Header = "Theme";
                        break;
                    case NavigationPageKeys.Styles:
                        this.Header = "App Styling";
                        break;
                }

                this._navigationService.NavigateTo(selectedItem.Tag as string);
            }
            else
            {
                // Settings navigation item clicked
                this.Header = "Settings";
                this._allAppsPanelOpenStateCache = this.IsAllAppsPanelOpen;
                this.IsAllAppsPanelEnabled = false;
                this.IsAllAppsPanelOpen = false;
                this._navigationService.NavigateTo(NavigationPageKeys.Settings);
            }
        }

        private void OnAllAppsToggleCommandAction()
        {
            this.IsAllAppsPanelOpen = !this.IsAllAppsPanelOpen;
        }

        private void OnSaveCommandAction()
        {
            //TODO: Save the data
            this.IsSaveRequired = false;
        }
        #endregion
    }
}
