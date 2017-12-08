using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using ProjectTile.UWP.Views.Pages;


namespace ProjectTile.UWP.Services
{
    class NavigationService : INavigationService
    {
        #region Fields
        private readonly Dictionary<string, Type> _pageIndex;
        private string _currentPageKey;
        private Frame _navigationFrame;
        #endregion

        #region Constructor
        public NavigationService()
        {
            this._pageIndex = new Dictionary<string, Type>();
        }
        #endregion

        #region Properties
        public string CurrentPageKey
        {
            get { return this._currentPageKey; }
            private set { this._currentPageKey = value; }
        }

        public Frame NavigationFrame
        {
            get { return this._navigationFrame ?? Window.Current.Content as Frame; }
            set { this._navigationFrame = value ?? throw new ArgumentNullException(); }
        }
        #endregion

        #region Public Methods
        public void Configure(string key, Type pageType)
        {
            this._pageIndex.Add(key, pageType);
        }

        public void NavigateTo(string pageKey)
        {
            this.NavigationFrame.Navigate(this._pageIndex[pageKey]);
            this.CurrentPageKey = pageKey;
        }

        public void NavigateTo(string pageKey, object parameter)
        {
            this.NavigationFrame.Navigate(this._pageIndex[pageKey], parameter);
            this.CurrentPageKey = pageKey;
        }

        /// <summary>
        /// Navigates to the most recent item in forward navigation history, if a Frame manages its own navigation history.
        /// </summary>
        public void GoForward()
        {
            // Frame.CanGoForward()?
            Go(true);
        }
        
        /// <summary>
        /// Navigates to the most recent item in back navigation history, if a Frame manages its own navigation history.
        /// </summary>
        public void GoBack()
        {
            // Frame.CanGoBack()?
            Go(false);
        }
        #endregion

        #region Private Members
        private void Go(bool isForward)
        {
            if (isForward)
            {
                this.NavigationFrame.GoForward();
            }
            else
            {
                this.NavigationFrame.GoBack();
            }
        }
        #endregion
    }
}
