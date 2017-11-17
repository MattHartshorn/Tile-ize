using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using ProjectTile.UWP.Views.Pages;
using GalaSoft.MvvmLight.Views;


namespace ProjectTile.UWP.Services
{
    class NavigationService : INavigationService
    {
        #region Fields
        private readonly Dictionary<string, Type> _pageIndex;
        private string _currentPageKey;
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
        #endregion

        #region Public Methods
        public void Configure(string key, Type pageType)
        {
            this._pageIndex.Add(key, pageType);
        }

        public void NavigateTo(string pageKey)
        {
            var frame = Window.Current.Content as Frame;
            frame.Navigate(this._pageIndex[pageKey]);
            this.CurrentPageKey = pageKey;
        }

        public void NavigateTo(string pageKey, object parameter)
        {
            var frame = Window.Current.Content as Frame;
            frame.Navigate(this._pageIndex[pageKey], parameter);
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

        #region Private Static Members
        private static void Go(bool isForward)
        {
            var frame = Window.Current.Content as Frame;

            if (isForward)
            {
                frame.GoForward();
            }
            else
            {
                frame.GoBack();
            }
        }
        #endregion
    }
}
