using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace ProjectTile.UWP.ViewModels
{
    class ThemeItemViewModel : ViewModelBase
    {
        private string _themeName;
        private string _imageSourceUri;
        private int _styledAppsCount;
        private ObservableCollection<string> _appColorHexItems;


        public string ThemeName
        {
            get;
            set;
        }

        public int StyledAppsCount
        {
            get;
            set;
        }

        public string ImageSourceUri
        {
            get;
            set;
        }

        public ObservableCollection<string> AppColorHexItems
        {
            get;
            set;
        }
    }
}
