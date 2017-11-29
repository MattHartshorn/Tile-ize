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

        private ObservableCollection<NavigationItemViewModel> _navMenuItems;
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

            this._navMenuItems = new ObservableCollection<NavigationItemViewModel>
            {
                new NavigationItemViewModel("Home", "\uE10F", NavigationPageKeys.Home),
                new NavigationItemViewModel("Theme", "\uE771", NavigationPageKeys.Theme),
                new NavigationItemViewModel("Application Styling", "\uE70F", NavigationPageKeys.Styles)
            };

            this.ToggleAllAppsBtnText = "Show All Apps";
            this._navigationService = ServiceLocator.Current.GetInstance<INavigationService>();
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

        public ObservableCollection<NavigationItemViewModel> NavigationMenuItems
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
                this.ToggleAllAppsBtnText = (value) ? "Hide All Apps" : "Show All Apps";

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

        public RelayCommand SaveCommand
        {
            get;
        }
        #endregion

        #region Public Methods
        public bool SelectNavigationItem(string pageKey)
        {
            if (pageKey != null)
            {
                foreach (var item in this._navMenuItems)
                {
                    if (item.Tag.Equals(pageKey))
                    {
                        this.SelectedNavigationItem = item;
                        return true;
                    }
                }
            }
            return false;
        }
        #endregion

        #region Private Methods
        private void OnSelectedNavigationItemChanged()
        {
            var selectedItem = this.SelectedNavigationItem as NavigationItemViewModel;
            string pageKey = (selectedItem != null) ? selectedItem.Tag as string : NavigationPageKeys.Settings;

            if (pageKey == NavigationPageKeys.Settings)
            {
                // Settings navigation item clicked
                this.Header = "Settings";
                this._allAppsPanelOpenStateCache = this.IsAllAppsPanelOpen;
                this.IsAllAppsPanelEnabled = false;
                this.IsAllAppsPanelOpen = false;
                this._navigationService.NavigateTo(NavigationPageKeys.Settings);
            }
            else
            {
                this.IsAllAppsPanelEnabled = true;
                this.IsAllAppsPanelOpen = this._allAppsPanelOpenStateCache;

                switch (pageKey)
                {
                    case NavigationPageKeys.Home:
                        this.Header = "Home";
                        break;
                    case NavigationPageKeys.Theme:
                        this.Header = "Theme";
                        break;
                    case NavigationPageKeys.Styles:
                        this.Header = "Application Styling";
                        break;
                }

                this._navigationService.NavigateTo(pageKey);
            }
        }

        private void OnSaveCommandAction()
        {
            //TODO: Save the data
            this.IsSaveRequired = false;
        }
        #endregion
    }
}
