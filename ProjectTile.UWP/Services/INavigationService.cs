using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace ProjectTile.UWP.Services
{
    public interface INavigationService
    {
        string CurrentPageKey { get; }
        Frame NavigationFrame { get; set; }

        void GoBack();
        void NavigateTo(string pageKey);
        void NavigateTo(string pageKey, object parameter);
    }
}
