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
        private int _styledAppCount;
        private ObservableCollection<string> _appColorHexItems;

        public ThemeItemViewModel()
        {
            this._appColorHexItems = new ObservableCollection<string>();
        }

        public string ThemeName
        {
            get { return this._themeName; }
            set
            {
                this._themeName = value;
                RaisePropertyChanged(nameof(ThemeName));
            }
        }

        public int StyledAppCount
        {
            get { return this._styledAppCount; }
            set
            {
                this._styledAppCount = value;
                RaisePropertyChanged(nameof(StyledAppCount));
            }
        }

        public string ImageSourceUri
        {
            get { return this._imageSourceUri; }
            set
            {
                this._imageSourceUri = value;
                RaisePropertyChanged(nameof(ImageSourceUri));
            }
        }

        public ObservableCollection<string> AppColorHexItems
        {
            get { return this._appColorHexItems; }
            set
            {
                this._appColorHexItems = value;
                RaisePropertyChanged(nameof(AppColorHexItems));
            }
        }
    }
}
